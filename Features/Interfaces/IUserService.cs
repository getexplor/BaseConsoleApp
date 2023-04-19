using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Interfaces
{
    public interface IUserService
    {
        void GetAllUser();
        string GetUserById(Guid Id);
    }
}
