using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class EmployeeDbRepositoryImpl(IDbContextFactory<KursovaiaContext> kursovaiaContext, TbEmployeeMapper tbMapper, GetEmpsMapper getMapper) : EmployeeDbRepository
    {
        public async Task<bool> AddEmployee(Employee employee, User user)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            using var transaction = await db.Database.BeginTransactionAsync();
            try
            {
                await db.TbUsers.AddAsync(new TbUser
                {
                    UserLogin = user.Login,
                    UserEmail = user.Email,
                    UserPassword = user.Password,
                    UserRoleId = user.Role,
                    UserPhone = user.PhoneNumber,
                    UserImage = user.imgstr
                });

                await transaction.CreateSavepointAsync("save1");

                await db.TbEmployees.AddAsync(new TbEmployee
                {
                    EmployeeLastname = employee.Lastname,
                    EmployeeFirstname = employee.Firstname,
                    EmployeeMiddlename = employee.Middlename,
                    EmployeePassportNum = employee.PassportNum,
                    EmployeePassportSerial = employee.PassportSerial,
                    EmployeePayBonus = employee.PayBonus,
                    EmployeeLogin = employee.Login,
                    EmployeeBirthday = DateOnly.FromDateTime(employee.Birthday),
                    EmployeeEducation = employee.Education,
                    EmployeeHiredate = employee.Hiredate,
                    EmployeeId = employee.Id,
                    EmployeePositionId = employee.Position.PositionId,
                    EmployeeWorkshopId = employee.Workshop.WorkshopId
                });

                await db.SaveChangesAsync();

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call delete_employee({id})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async IAsyncEnumerable<Employee> FilterByBirthday(DateOnly date)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            await foreach (var item in db.GetEmps.Where(emp => emp.EmployeeBirthday == date).AsAsyncEnumerable())
                yield return await getMapper.MapFromModel(item);
        }

        public async IAsyncEnumerable<Employee> FilterByFio(string query)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            await foreach (var item in db.GetEmps.Where(emp => emp.EmployeeFirstname.ToLower().Contains(query.ToLower()) || emp.EmployeeLastname.ToLower().Contains(query.ToLower()) || emp.EmployeeMiddlename.ToLower().Contains(query.ToLower())).AsAsyncEnumerable())
                yield return await getMapper.MapFromModel(item);
        }

        public async Task<Employee> GetEmployee(string login)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            return await tbMapper.MapFromModel(db.TbEmployees.FromSqlRaw($"select * from get_emp_by_login('{login}')").ToList()[0]);
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            return await tbMapper.MapFromModel(await db.TbEmployees.FindAsync(id));
        }

        public async IAsyncEnumerable<Employee> GetEmployees()
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            await foreach (var item in db.GetEmps.AsAsyncEnumerable())
                yield return await getMapper.MapFromModel(item);
        }

        public async Task<bool> UpdateEmployee(Employee employee, User user)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            using var transaction = await db.Database.BeginTransactionAsync();
            try
            {
                var users = await db.TbUsers.Where(usr => usr.UserLogin == user.Login).ToListAsync();
                var usr = users.FirstOrDefault();
                if (usr != null)
                {
                    usr.UserLogin = user.Login;
                    usr.UserEmail = user.Email;
                    usr.UserPassword = user.Password;
                    usr.UserRoleId = user.Role;
                    usr.UserPhone = user.PhoneNumber;
                    usr.UserImage = user.imgstr;
                }

                await transaction.CreateSavepointAsync("save1");

                var emp = await db.TbEmployees.FindAsync(employee.Id);
                if (emp != null)
                {
                    emp.EmployeeLastname = employee.Lastname;
                    emp.EmployeeFirstname = employee.Firstname;
                    emp.EmployeeMiddlename = employee.Middlename;
                    emp.EmployeePassportNum = employee.PassportNum;
                    emp.EmployeePassportSerial = employee.PassportSerial;
                    emp.EmployeePayBonus = employee.PayBonus;
                    emp.EmployeeLogin = employee.Login;
                    emp.EmployeeBirthday = DateOnly.FromDateTime(employee.Birthday);
                    emp.EmployeeEducation = employee.Education;
                    emp.EmployeeHiredate = employee.Hiredate;
                    emp.EmployeeId = employee.Id;
                    emp.EmployeePositionId = employee.Position.PositionId;
                    emp.EmployeeWorkshopId = employee.Workshop.WorkshopId;
                }

                await db.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
