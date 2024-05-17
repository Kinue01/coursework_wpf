namespace coursework.Domain.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public string Adderss { get; set; }
        public int Cost { get; set; }
        public int ProdCount { get; set; }
        public DateOnly Date { get; set; }
        public string Status { get; set; }

        public Order(int id, string fio, string adderss, int cost, int prodCount, DateOnly date, string status)
        {
            Id = id;
            Fio = fio;
            Adderss = adderss;
            Cost = cost;
            ProdCount = prodCount;
            Date = date;
            Status = status;
        }
    }
}
