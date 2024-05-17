namespace coursework.Domain.Model
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string SupplierAddress { get; set; }

        public string SupplierPhone { get; set; }

        public string? SupplierEmail { get; set; }

        public string SupplierContact { get; set; }

        public Supplier(int supplierId, string supplierName, string supplierAddress, string supplierPhone, string? supplierEmail, string supplierContact)
        {
            SupplierId = supplierId;
            SupplierName = supplierName;
            SupplierAddress = supplierAddress;
            SupplierPhone = supplierPhone;
            SupplierEmail = supplierEmail;
            SupplierContact = supplierContact;
        }
    }
}
