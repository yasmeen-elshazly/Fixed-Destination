using My_Uber.Context.Context;
using My_Uber.Repositories.Contract;
using Models;

namespace My_Uber.Repositories.Repositories
{
    public class BuildingRepository : GenericRepository<BuildingModel>, IBuildingRepository
    {
        private readonly MyUberDbContext _uberDbContext;

        public BuildingRepository(MyUberDbContext uberDbContext) : base(uberDbContext)
        {
            _uberDbContext = uberDbContext;
        }
    }
}
