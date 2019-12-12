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
        static void Main(string[] args)
        {
            // IClass c1 = new MyClass();
            Type myClassType = Type.GetType("Custom_IoC_DI.MyClass");
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
            printMethodInfo.Invoke(c1, null);

        }
    }
}
