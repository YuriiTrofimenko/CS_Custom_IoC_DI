using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_IoC_DI
{
    class Container
    {
        public void Inject(object controller) {
            // TODO Найти в объекте controller все поля, помеченные аннотацией Inject
            // и проинициализировать объектом должного типа
        }
        private void Validate(object service)
        {
            // TODO Вызывать этот метод при выполнении каждого внедрения
            // и проверять, есть ли у объекта внедряемого типа аннотация Service.
            // Если нет - выбрасывать исключение, если есть - печатать в консоль информацию об успехе проверки
        }
    }
}
