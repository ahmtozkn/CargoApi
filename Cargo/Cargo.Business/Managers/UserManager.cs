using Cargo.Business.Dtos;
using Cargo.Business.Services;
using Cargo.Data.Entities;
using Cargo.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Business.Managers
{
    public class UserManager : IUserService
    {
        private readonly IRepository<EmployeeEntity> _employeeRepository;


        public UserManager(IRepository<EmployeeEntity> employeeRepository)
        {
            _employeeRepository = employeeRepository;
                
        }

        public List<UserInfoDto> GetAllUser()
        {
            var userInfoEntity = _employeeRepository.GetAll(); 
             var userInfoDto=userInfoEntity.Select(x => new UserInfoDto
            {
               Id = x.Id,
               Email = x.Email,
               FirstName = x.FirstName,
               LastName = x.LastName,


            }).ToList();
            return userInfoDto;
           

           
        }

        public UserInfoDto LoginUser(LoginUserDto loginUserDto)
        {
            var employeeEntity=_employeeRepository.GetAll().FirstOrDefault(x=>x.Email==loginUserDto.Email && x.Password==loginUserDto.Password);

            if (employeeEntity is null) 
            {
                return null;
            }

            var userInfoDto = new UserInfoDto()
            {
                Email = employeeEntity.Email,
                FirstName = employeeEntity.FirstName,
                LastName = employeeEntity.LastName,
                Id = employeeEntity.Id,
            };
            return userInfoDto;




        }
        
    }
}
