using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class TbEmployeeMapper(GetPositionByIdUseCase getPositionByIdUseCase, GetWorkshopByIdUseCase getWorkshopByIdUseCase)
    {
        public async Task<Employee> MapFromModel(TbEmployee employee)
        {
            Position pos = null;
            Workshop work = null;
            if (employee != null)
            {
                pos = await getPositionByIdUseCase.Execute(employee.EmployeePositionId);
                work = await getWorkshopByIdUseCase.Execute(employee.EmployeeWorkshopId);
            }
            return new Employee(employee.EmployeeId, employee.EmployeeLastname, employee.EmployeeFirstname, employee.EmployeeMiddlename, employee.EmployeePassportSerial, employee.EmployeePassportNum, employee.EmployeePayBonus, employee.EmployeeLogin, pos, employee.EmployeeBirthday.ToDateTime(TimeOnly.MinValue), employee.EmployeeHiredate, employee.EmployeeEducation, work);
        }
    }
}
