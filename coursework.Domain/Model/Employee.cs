namespace coursework.Domain.Model
{
    public class Employee
    {
        public int Id { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string PassportSerial { get; set; }

        public string PassportNum { get; set; }

        public int PayBonus { get; set; }

        public string Login { get; set; }

        public Position Position { get; set; }

        public DateTime Birthday { get; set; }

        public DateOnly Hiredate { get; set; }

        public string Education { get; set; }

        public Workshop Workshop { get; set; }

        public Employee(int id, string lastname, string firstname, string middlename, string passportSerial, string passportNum, int payBonus, string login, Position position, DateTime birthday, DateOnly hiredate, string education, Workshop workshop)
        {
            Id = id;
            Lastname = lastname;
            Firstname = firstname;
            Middlename = middlename;
            PassportSerial = passportSerial;
            PassportNum = passportNum;
            PayBonus = payBonus;
            Login = login;
            Position = position;
            Birthday = birthday;
            Hiredate = hiredate;
            Education = education;
            Workshop = workshop;
        }

        public Employee() { }
    }
}
