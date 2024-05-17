namespace coursework.Domain.Model
{
    public class Workshop
    {
        public int WorkshopId { get; set; }

        public string WorkshopName { get; set; } = null!;

        public Employee WorkshopChief { get; set; } = null!;

        public string WorkshopChiefPhone { get; set; } = null!;

        public int? WorkshopStaffCount { get; set; }

        public Workshop(int workshopId, string workshopName, Employee workshopChief, string workshopChiefPhone, int? workshopStaffCount)
        {
            WorkshopId = workshopId;
            WorkshopName = workshopName;
            WorkshopChief = workshopChief;
            WorkshopChiefPhone = workshopChiefPhone;
            WorkshopStaffCount = workshopStaffCount;
        }
    }
}
