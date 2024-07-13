

using Models;
using My_Uber.Context.Context;
using My_Uber.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Uber.Repositories.Repositories
{
    public class UserRepository : Repository.GenericRepository<User>, IUserRepository
    {
        MyUberDbContext uberDbContext;
        public UserRepository(MyUberDbContext _uberDbContext) : base(_uberDbContext)
        {
            uberDbContext = _uberDbContext;
        }
    }
}
