using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class TbSupplierMapper
    {
        public Supplier MapFromModel(TbSupplier supplier)
        {
            return new Supplier(supplier.SupplierId, supplier.SupplierName, supplier.SupplierAddress, supplier.SupplierPhone, supplier.SupplierEmail, supplier.SupplierContact);
        }
    }
}
