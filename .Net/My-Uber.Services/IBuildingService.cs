using My_Uber.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My_Uber.Services
{
    public interface IBuildingService
    {
        Task<List<BuildingDTO>> GetAllAsync();
        Task<BuildingDTO> GetByIdAsync(int id);
        Task<BuildingDTO> CreateAsync(BuildingDTO buildingDto);
        Task<bool> UpdateAsync(BuildingDTO buildingDto);
        Task<bool> DeleteAsync(int id);
    }
}
