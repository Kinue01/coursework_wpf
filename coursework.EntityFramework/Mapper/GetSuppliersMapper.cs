using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetSuppliersMapper
    {
        public Supplier MapFromModel(GetSupplier supplier)
        {
            return new Supplier(supplier.SupplierId.GetValueOrDefault(), supplier.SupplierName, supplier.SupplierAddress, supplier.SupplierPhone, supplier.SupplierEmail, supplier.SupplierContact);
        }
    }
}
