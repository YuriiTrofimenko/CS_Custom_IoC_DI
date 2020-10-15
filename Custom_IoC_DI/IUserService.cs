using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_IoC_DI
{
    public interface IUserService
    {
        void Top3UsersIds(int[] usersIds);

        void DeleteUser(object user);
    }
}