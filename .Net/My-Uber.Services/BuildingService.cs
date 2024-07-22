using AutoMapper;
using Models;
using My_Uber.DTOs;
using My_Uber.Repositories.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Uber.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public BuildingService(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<List<BuildingDTO>> GetAllAsync()
        {
            var buildings = await _buildingRepository.GetAllAsync();
            return _mapper.Map<List<BuildingDTO>>(buildings.ToList());
        }

        public async Task<BuildingDTO> GetByIdAsync(int id)
        {
            var building = await _buildingRepository.GetByIdAsync(id);
            return _mapper.Map<BuildingDTO>(building);
        }

        public async Task<BuildingDTO> CreateAsync(BuildingDTO buildingDto)
        {
            var building = _mapper.Map<BuildingModel>(buildingDto);
            await _buildingRepository.AddAsync(building);
            await _buildingRepository.SaveChangesAsync();
            return _mapper.Map<BuildingDTO>(building);
        }

        public async Task<bool> UpdateAsync(BuildingDTO buildingDto)
        {
            var existingBuilding = await _buildingRepository.GetByIdAsync(buildingDto.Id);
            if (existingBuilding == null)
            {
                return false;
            }

            var updatedBuilding = _mapper.Map<BuildingModel>(buildingDto);
            await _buildingRepository.UpdateAsync(updatedBuilding);
            await _buildingRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var building = await _buildingRepository.GetByIdAsync(id);
            if (building == null)
            {
                return false;
            }

            await _buildingRepository.DeleteAsync(building);
            await _buildingRepository.SaveChangesAsync();
            return true;
        }
    }
}
