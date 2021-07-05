using System;
using System.Linq;

namespace Custom_IoC_DI
{
    //[InjectionCandidate]
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
