using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelService
{
     interface IUserService
    {
        Task AddAsync(User user);

        Task<User> GetAsync(int userId);
    }
}
