namespace coursework.Domain.Model
{
    public class CartOrder
    {
        public int CartOrderId { get; set; }

        public Product CartProduct { get; set; }

        public int CartProdCount { get; set; }

        public Employee CartProdEmployee { get; set; }

        public DateOnly? CartProdProduceDate { get; set; }

        public CartOrder(int cartOrderId, Product cartProduct, int cartProdCount, Employee cartProdEmployee, DateOnly? cartProdProduceDate)
        {
            CartOrderId = cartOrderId;
            CartProduct = cartProduct;
            CartProdCount = cartProdCount;
            CartProdEmployee = cartProdEmployee;
            CartProdProduceDate = cartProdProduceDate;
        }
    }
}
