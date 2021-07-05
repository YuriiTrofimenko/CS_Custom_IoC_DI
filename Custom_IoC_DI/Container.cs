using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Custom_IoC_DI
{
    class Container
    {
        public void Inject(object controller) {
            // Найти в объекте controller все поля, помеченные аннотацией Inject
            // и проинициализировать ссылками на объекты должного типа
            Type type = controller.GetType();
            foreach (var item in type.GetFields())
            {
                if (item.GetCustomAttribute<InjectAttribute>() != null)
                {
                  // получение типа поля, в которое нужно произвести внедрение
                  var typeForInject = Type.GetType(item.FieldType.ToString());
                  Object value = null;
                  if(typeForInject.IsInterface) {
                    // найти в проекте класс, реализующий интерфейс

                    var foundImplementations = Assembly.GetExecutingAssembly()
                      .GetTypes()
                      .Where(t => typeForInject.IsAssignableFrom(t) && !t.IsAbstract)
                      .ToList();

                    foundImplementations = 
                        foundImplementations.Where(type => 
                        type.GetCustomAttribute<InjectionCandidate>() != null)
                        .ToList();

                    if (foundImplementations.Count == 0)
                    {
                      throw new Exception($"Implementation for {typeForInject.FullName} not found");
                    } else if (foundImplementations.Count > 1) {
                      throw new Exception($"Multiple implementations for {typeForInject.FullName}");
                    }
                    typeForInject = foundImplementations.Single();
                  }
                  // порождение экземпляра типа поля, в которое нужно произвести внедрение
                  value =
                    typeForInject
                    // получение описания конструктора без параметров
                    .GetConstructor(Type.EmptyTypes)
                    // вызов конструктора без передачи параметров
                    .Invoke(null);
                  // внедрение зависимости:
                  // проинициализировать поле, описанное объектом рефлексии item,
                  // пренадлежащее объекту controller,
                  // выше созданным значением value
                  item.SetValue(controller, value);
                }
            }
        }
        private void Validate(object service)
        {
            // TODO Вызывать этот метод при выполнении каждого внедрения
            // и проверять, есть ли у объекта внедряемого типа аннотация Service.
            // Если нет - выбрасывать исключение, если есть - печатать в консоль информацию об успехе проверки
        }
    }
}
