using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using My_Uber.DTOs;
using My_Uber.Repositories.Contract;
using My_Uber.Services;

namespace My_Uber.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
      
        private readonly IMapper _mapper;

        public UserService( IUserRepository userRepository, IMapper mapper)
        {
           
            _userRepository = userRepository;
          
            _mapper = mapper;
        }


        public List<UserDTO> GetAll()
        {
            var users = _userRepository.GetAll().ToList();
            var dtos = _mapper.Map<List<UserDTO>>(users);
            return dtos;
        }
       

    }
}
