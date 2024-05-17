using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetEmpsMapper(GetPositionByIdUseCase getPositionByIdUseCase, GetWorkshopByIdUseCase getWorkshopByIdUseCase)
    {
        public async Task<Employee> MapFromModel(GetEmp emp)
        {
            return new Employee(emp.EmployeeId.GetValueOrDefault(), emp.EmployeeLastname, emp.EmployeeFirstname, emp.EmployeeMiddlename, emp.EmployeePassportSerial, emp.EmployeePassportNum, emp.EmployeePayBonus.GetValueOrDefault(),emp.EmployeeLogin, await getPositionByIdUseCase.Execute(emp.PositionId.GetValueOrDefault()), emp.EmployeeBirthday.GetValueOrDefault().ToDateTime(TimeOnly.MinValue), emp.EmployeeHiredate.GetValueOrDefault(), emp.EmployeeEducation, await getWorkshopByIdUseCase.Execute(emp.WorkshopId.GetValueOrDefault()));
        }
    }
}
