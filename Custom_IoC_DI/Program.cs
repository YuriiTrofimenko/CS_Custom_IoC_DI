using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Custom_IoC_DI
{
    class Program
    {
        /* Task
        - определить еще один пользовательский атрибут: InjectionCandidate;
        - установить такой атрибут над заголовком одного из классов, реализующих интрефейс IUserService;
        - доработать класс контейнера внедрения зависимостей так, чтобы он выбирал из всех
        реализаций интерфейса, которым протипизировано поле для внедрения, только одну -
        заданную классом с атрибутом InjectionCandidate;
        - создать особый класс - конфигурацию соответствия интерфейсов внедряемых типов
        и их реализаций, где программист-пользователь контейнера сможет указать, например,
        что поля типа IUserService нужно инициализировать ссылкой на объекты типа UserService,
        а если такое сопопоставление контейнером не будет найдено - пусть работает автосканирование,
        как сейчас (подбирается один класс реализации, помечнный атрибутом InjectionCandidate) */
        static void Main(string[] args)
        {
            // IClass c1 = new MyClass();
            /* Type myClassType = Type.GetType("Custom_IoC_DI.MyClass");
            IClass c1 = ((IClass)myClassType
                .GetConstructor(Type.EmptyTypes)
                .Invoke(null)
            );

            c1.Data = "Some Data";

            c1.PrintInfo();

            FieldInfo idFieldInfo =
                myClassType.GetField("id", BindingFlags.Instance | BindingFlags.NonPublic);
            idFieldInfo.SetValue(c1, 120);

            // c1.PrintInfo();
            MethodInfo printMethodInfo =
                myClassType.GetMethod("PrintInfo", BindingFlags.Instance | BindingFlags.Public);
            printMethodInfo.Invoke(c1, null); */

            // Управляемый объект
            UserController userController = new UserController();
            // Управляющий контейнер
            Container container = new Container();
            // Активация всех внедрений зависимостей
            // в поля управляемого объекта
            container.Inject(userController);
            // Проверка успешности внедрения зависимотей:
            // методы GetTop3UserIds и DeleteUser
            // требуют наличия внедренного ресурса,
            // иначе будет выброшено исключение NullReferenceException
            userController.GetTop3UserIds(new int[] { 1, 9, 7, 2 });
            userController.DeleteUser(new { Id = 122, Name = "User1" });
        }
    }
}
