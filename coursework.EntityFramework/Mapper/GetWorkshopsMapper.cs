using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.Mapper
{
    public class GetWorkshopsMapper(IDbContextFactory<KursovaiaContext> dbContextFactory, GetPositionByIdUseCase getPositionByIdUseCase)
    {
        public async Task<Workshop> MapFromModel(GetWorkshop workshop)
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            var res = await db.TbEmployees.FindAsync(workshop.WorkshopChief);
            return new Workshop(workshop.WorkshopId.GetValueOrDefault(), workshop.WorkshopName, new Employee(res.EmployeeId, res.EmployeeLastname, res.EmployeeFirstname, res.EmployeeMiddlename, res.EmployeePassportSerial, res.EmployeePassportNum, res.EmployeePayBonus, res.EmployeeLogin, await getPositionByIdUseCase.Execute(res.EmployeePositionId), res.EmployeeBirthday.ToDateTime(TimeOnly.MinValue), res.EmployeeHiredate, res.EmployeeEducation, null), workshop.WorkshopChiefPhone, workshop.WorkshopStaffCount);
        }
    }
}
