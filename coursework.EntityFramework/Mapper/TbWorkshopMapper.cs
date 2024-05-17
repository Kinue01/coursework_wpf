using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.Mapper
{
    public class TbWorkshopMapper(IDbContextFactory<KursovaiaContext> dbContextFactory, GetPositionByIdUseCase getPositionByIdUseCase)
    {
        public async Task<Workshop> MapFromModel(TbWorkshop workshop)
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            var employee = await db.TbEmployees.FindAsync(workshop.WorkshopChief);
            var pos = await getPositionByIdUseCase.Execute(employee.EmployeePositionId);
            return new Workshop(workshop.WorkshopId, workshop.WorkshopName, new Employee(employee.EmployeeId, employee.EmployeeLastname, employee.EmployeeFirstname, employee.EmployeeMiddlename, employee.EmployeePassportSerial, employee.EmployeePassportNum, employee.EmployeePayBonus, employee.EmployeeLogin, pos, employee.EmployeeBirthday.ToDateTime(TimeOnly.MinValue), employee.EmployeeHiredate, employee.EmployeeEducation, null), workshop.WorkshopChiefPhone, workshop.WorkshopStaffCount);
        }
    }
}
