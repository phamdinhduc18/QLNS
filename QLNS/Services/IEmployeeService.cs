using QLNS.DTOs;
using QLNS.Helpers.Models;
using QLNS.Models;
using System;
using System.Threading.Tasks;

namespace QLNS.Services
{
    public interface IEmployeeService: IService<Employees>
    {
        public Task<int> ChangePassword(ChangPasswordDTO dto);
        public Task<Employees> AddEmployee(CreateEmployeeDTO employeeDto);
        public Task<Tuple<Employees, string>> ResetPasswordByAdmin(int userId);

    }
}
