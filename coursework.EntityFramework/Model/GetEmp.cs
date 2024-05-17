namespace coursework.EntityFramework.Model;

public partial class GetEmp
{
    public int? EmployeeId { get; set; }

    public string? EmployeeLastname { get; set; }

    public string? EmployeeFirstname { get; set; }

    public string? EmployeeMiddlename { get; set; }

    public string? EmployeePassportNum { get; set; }

    public string? EmployeePassportSerial { get; set; }
    public int? EmployeePayBonus { get; set; }

    public string? EmployeeLogin { get; set; }

    public int? PositionId { get; set; }

    public DateOnly? EmployeeBirthday { get; set; }

    public DateOnly? EmployeeHiredate { get; set; }

    public string? EmployeeEducation { get; set; }

    public int? WorkshopId { get; set; }
}
