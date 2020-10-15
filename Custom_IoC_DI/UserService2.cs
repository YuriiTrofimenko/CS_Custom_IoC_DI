using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_IoC_DI
{
    // [Service]
    class UserService2 : IUserService
    {
        public void Top3UsersIds(int[] usersIds)
        {
            System.Console.WriteLine("UserService2 Top3UsersIds");
            usersIds.Take(3).ToList().ForEach(Console.WriteLine);
        }

        public void DeleteUser(object user)
        {
            System.Console.WriteLine("UserService2 DeleteUser");
            Console.WriteLine(user.ToString() + " Deleted");
        }
    }
}
