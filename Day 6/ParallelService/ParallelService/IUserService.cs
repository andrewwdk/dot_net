using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelService
{
     interface IUserService
    {
        void Add(User user);

        Task<User> Get(int userId);
    }
}
