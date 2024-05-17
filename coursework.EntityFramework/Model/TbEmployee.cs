namespace coursework.EntityFramework.Model;

public partial class TbEmployee
{
    public int EmployeeId { get; set; }

    public string EmployeeLastname { get; set; } = null!;

    public string EmployeeFirstname { get; set; } = null!;

    public string EmployeeMiddlename { get; set; } = null!;

    public string EmployeePassportSerial { get; set; } = null!;

    public string EmployeePassportNum { get; set; } = null!;

    public int EmployeePayBonus { get; set; }

    public string EmployeeLogin { get; set; } = null!;

    public int EmployeePositionId { get; set; }

    public DateOnly EmployeeBirthday { get; set; }

    public DateOnly EmployeeHiredate { get; set; }

    public string EmployeeEducation { get; set; } = null!;

    public int EmployeeWorkshopId { get; set; }

    public virtual TbUser EmployeeLoginNavigation { get; set; } = null!;

    public virtual TbPosition EmployeePosition { get; set; } = null!;

    public virtual TbWorkshop EmployeeWorkshop { get; set; } = null!;

    public virtual ICollection<TbCartOrder> TbCartOrders { get; set; } = new List<TbCartOrder>();

    public virtual ICollection<TbWorkshop> TbWorkshops { get; set; } = new List<TbWorkshop>();
}
