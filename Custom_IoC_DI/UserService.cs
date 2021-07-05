using System;
using System.Linq;

namespace Custom_IoC_DI
{
    [InjectionCandidate]
    class UserService : IUserService
    {
        public void Top3UsersIds(int[] usersIds)
        {
            usersIds.Take(3).ToList().ForEach(Console.WriteLine);
        }

        public void DeleteUser(object user)
        {
            Console.WriteLine(user.ToString() + " Deleted");
        }
    }
}
