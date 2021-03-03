using AutoMapper;
using QLNS.DTOs;
using QLNS.Helpers;
using QLNS.Helpers.Models;
using QLNS.Models;
using QLNS.Repositories;
using System;
using System.Threading.Tasks;

namespace QLNS.Services
{
    public class EmployeeService : GenericService<Employees>, IEmployeeService
    {
        private readonly EmployeeRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeService(EmployeeRepository repository, IMapper mapper) : base(repository)
        {
            _repo = repository;
            _mapper = mapper;
        }

        public async Task<Employees> AddEmployee(CreateEmployeeDTO employeeDto)
        {
            var newEmployee = _mapper.Map<Employees>(employeeDto);
            newEmployee.PasswordSalt = Salt.Create();
            newEmployee.PasswordHash = Hash.Create(Constants.PASSWORD, newEmployee.PasswordSalt);
            var user =  await _repo.CreateAsync(newEmployee);
            return user;
        }

        public async Task<int> ChangePassword(ChangPasswordDTO dto)
        {
            var user = _repo.FindOne(x=>x.EmployeeId.Equals(dto.id));
            if (user == null) return -1;
            var dateCreate = user.DateCreateNewPassword;
            if (!Hash.Validate(dto.CurrentPassword, user.PasswordSalt, user.PasswordHash))
                return 0;
            var salt = Salt.Create();
            var passwordhash = Hash.Create(dto.NewPassword, salt);
            user.PasswordSalt = salt;
            user.PasswordHash = passwordhash;
            user.DateCreateNewPassword = DateTime.Now;
            await _repo.SaveAsync();
            return 1;
        }
        public async Task<Tuple<Employees, string>>  ResetPasswordByAdmin(int id)
        {
            var user = await _repo.GetAsync(id);
            if (null == user) return null;
            var newPassword = Password.Random();

            var salt = Salt.Create();

            user.PasswordHash = Hash.Create(newPassword, salt);
            user.PasswordSalt = salt;
            user.DateCreateNewPassword = DateTime.Now;

            await _repo.UpdateAsync(id, user);

            return new Tuple<Employees, string>(user,newPassword);
        }

    }
}