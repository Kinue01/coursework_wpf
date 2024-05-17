namespace coursework.Domain.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Login { get; set; }
        public DateOnly RegDate { get; set; }
        public DateOnly? Birthday { get; set; }

        public Client(int id, string lname, string fname, string mname, string login, DateOnly reg, DateOnly? birth) 
        {
            Id = id;
            Lastname = lname;
            Firstname = fname;
            Middlename = mname;
            Login = login;
            Birthday = birth;
            RegDate = reg;
        }

        public Client() { }
    }
}
