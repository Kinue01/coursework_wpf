using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.Model;

public partial class KursovaiaContext : DbContext
{
    public KursovaiaContext()
    {
    }

    public KursovaiaContext(DbContextOptions<KursovaiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GetCartOrder> GetCartOrders { get; set; }

    public virtual DbSet<GetClient> GetClients { get; set; }

    public virtual DbSet<GetEmp> GetEmps { get; set; }

    public virtual DbSet<GetIngred> GetIngreds { get; set; }

    public virtual DbSet<GetIngredsExpense> GetIngredsExpenses { get; set; }

    public virtual DbSet<GetIngredsOnWarehouse> GetIngredsOnWarehouses { get; set; }

    public virtual DbSet<GetIngredsType> GetIngredsTypes { get; set; }

    public virtual DbSet<GetOrder> GetOrders { get; set; }

    public virtual DbSet<GetOrderStatus> GetOrderStatuses { get; set; }

    public virtual DbSet<GetPayType> GetPayTypes { get; set; }

    public virtual DbSet<GetPose> GetPoses { get; set; }

    public virtual DbSet<GetProd> GetProds { get; set; }

    public virtual DbSet<GetRole> GetRoles { get; set; }

    public virtual DbSet<GetSupplier> GetSuppliers { get; set; }

    public virtual DbSet<GetTimesheet> GetTimesheets { get; set; }

    public virtual DbSet<GetWorkshop> GetWorkshops { get; set; }

    public virtual DbSet<TbCartOrder> TbCartOrders { get; set; }

    public virtual DbSet<TbClient> TbClients { get; set; }

    public virtual DbSet<TbEmployee> TbEmployees { get; set; }

    public virtual DbSet<TbIngredient> TbIngredients { get; set; }

    public virtual DbSet<TbIngredientType> TbIngredientTypes { get; set; }

    public virtual DbSet<TbIngredientsExpense> TbIngredientsExpenses { get; set; }

    public virtual DbSet<TbIngredientsOnWarehouse> TbIngredientsOnWarehouses { get; set; }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbOrderStatus> TbOrderStatuses { get; set; }

    public virtual DbSet<TbPayType> TbPayTypes { get; set; }

    public virtual DbSet<TbPosition> TbPositions { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    public virtual DbSet<TbProductComposition> TbProductCompositions { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbSupplier> TbSuppliers { get; set; }

    public virtual DbSet<TbTimesheet> TbTimesheets { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<TbWorkshop> TbWorkshops { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=kursovaia;Username=postgres;Password=Dtkjcbgtl2016");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GetCartOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_cart_orders");

            entity.Property(e => e.CartOrderId).HasColumnName("cart_order_id");
            entity.Property(e => e.CartProdCount).HasColumnName("cart_prod_count");
            entity.Property(e => e.CartProdProduceDate).HasColumnName("cart_prod_produce_date");
            entity.Property(e => e.CartProdEmployeeId).HasColumnName("cart_prod_employee_id");
            entity.Property(e => e.ProductId).HasColumnName("cart_product_id");
        });

        modelBuilder.Entity<GetClient>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_clients");

            entity.Property(e => e.ClientBirthday).HasColumnName("client_birthday");
            entity.Property(e => e.ClientFirstname)
                .HasMaxLength(30)
                .HasColumnName("client_firstname");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ClientLastname)
                .HasMaxLength(30)
                .HasColumnName("client_lastname");
            entity.Property(e => e.ClientLogin)
                .HasMaxLength(50)
                .HasColumnName("client_login");
            entity.Property(e => e.ClientMiddlename)
                .HasMaxLength(30)
                .HasColumnName("client_middlename");
            entity.Property(e => e.ClientRegDate).HasColumnName("client_reg_date");
        });

        modelBuilder.Entity<GetEmp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_emps");

            entity.Property(e => e.EmployeeBirthday).HasColumnName("employee_birthday");
            entity.Property(e => e.EmployeeEducation)
                .HasMaxLength(20)
                .HasColumnName("employee_education");
            entity.Property(e => e.EmployeeFirstname)
                .HasMaxLength(20)
                .HasColumnName("employee_firstname");
            entity.Property(e => e.EmployeeHiredate).HasColumnName("employee_hiredate");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EmployeeLastname)
                .HasMaxLength(20)
                .HasColumnName("employee_lastname");
            entity.Property(e => e.EmployeeLogin).HasColumnName("employee_login");
            entity.Property(e => e.EmployeeMiddlename)
                .HasMaxLength(20)
                .HasColumnName("employee_middlename");
            entity.Property(e => e.EmployeePassportNum)
                .HasMaxLength(4)
                .HasColumnName("employee_passport_num");
            entity.Property(e => e.EmployeePassportSerial)
                .HasMaxLength(6)
                .HasColumnName("employee_passport_serial");
            entity.Property(e => e.PositionId)
                .HasMaxLength(20)
                .HasColumnName("employee_position_id");
            entity.Property(e => e.WorkshopId)
                .HasMaxLength(20)
                .HasColumnName("employee_workshop_id");
            entity.Property(e => e.EmployeePayBonus).HasColumnName("employee_pay_bonus");
        });

        modelBuilder.Entity<GetIngred>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_ingreds");

            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.IngredientName)
                .HasMaxLength(20)
                .HasColumnName("ingredient_name");
            entity.Property(e => e.IngredientWeight).HasColumnName("ingredient_weight");
            entity.Property(e => e.TypeId).HasColumnName("ingredient_type_id");
        });

        modelBuilder.Entity<GetIngredsExpense>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_ingreds_expense");
            entity.Property(e => e.SupplyDate).HasColumnName("supply_date");
            entity.Property(e => e.IngredientId)
                .HasColumnName("ingredient_id");
            entity.Property(e => e.ProductId)
                .HasColumnName("product_id");
            entity.Property(e => e.SupplierId)
                .HasColumnName("supplier_id");
            entity.Property(e => e.Count)
                .HasColumnName("count");
           
        });

        modelBuilder.Entity<GetIngredsOnWarehouse>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_ingreds_on_warehouse");

            entity.Property(e => e.IngredientCount).HasColumnName("ingredient_count");
            entity.Property(e => e.IngredientId)
                .HasColumnName("ingredient_id");
            entity.Property(e => e.IngredientUpTo).HasColumnName("ingredient_up_to");
            entity.Property(e => e.SupplierId)
                .HasColumnName("supplier_id");
            entity.Property(e => e.SupplyDate).HasColumnName("supply_date");
        });

        modelBuilder.Entity<GetIngredsType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_ingreds_types");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(60)
                .HasColumnName("type_name");
            entity.Property(e => e.TypeStorageHumidity).HasColumnName("type_storage_humidity");
            entity.Property(e => e.TypeStorageTemp).HasColumnName("type_storage_temp");
        });

        modelBuilder.Entity<GetOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_orders");

            entity.Property(e => e.Concat).HasColumnName("concat");
            entity.Property(e => e.OrderAddress)
                .HasMaxLength(200)
                .HasColumnName("order_address");
            entity.Property(e => e.OrderCost).HasColumnName("order_cost");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderProductCount).HasColumnName("order_product_count");
            entity.Property(e => e.StatusName)
                .HasMaxLength(20)
                .HasColumnName("status_name");
            entity.Property(e => e.TypeName).HasColumnName("type_name");
        });

        modelBuilder.Entity<GetOrderStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_order_status");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(20)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<GetPayType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_pay_types");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(20)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<GetPose>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_poses");

            entity.Property(e => e.PositionBasePay).HasColumnName("position_base_pay");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionTitle)
                .HasMaxLength(20)
                .HasColumnName("position_title");
        });

        modelBuilder.Entity<GetProd>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_prods");

            entity.Property(e => e.ProductCarbohydrates).HasColumnName("product_carbohydrates");
            entity.Property(e => e.ProductFats).HasColumnName("product_fats");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(150)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPrice).HasColumnName("product_price");
            entity.Property(e => e.ProductProteins).HasColumnName("product_proteins");
            entity.Property(e => e.ProductWeight).HasColumnName("product_weight");
            entity.Property(e => e.ProductImage).HasColumnName("product_image");
        });

        modelBuilder.Entity<GetRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<GetSupplier>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_suppliers");

            entity.Property(e => e.SupplierAddress)
                .HasMaxLength(150)
                .HasColumnName("supplier_address");
            entity.Property(e => e.SupplierContact)
                .HasMaxLength(160)
                .HasColumnName("supplier_contact");
            entity.Property(e => e.SupplierEmail)
                .HasMaxLength(320)
                .HasColumnName("supplier_email");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(20)
                .HasColumnName("supplier_name");
            entity.Property(e => e.SupplierPhone)
                .HasMaxLength(11)
                .HasColumnName("supplier_phone");
        });

        modelBuilder.Entity<GetTimesheet>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_timesheet");

            entity.Property(e => e.TimesheetEmployeeId).HasColumnName("timesheet_employee_id");
            entity.Property(e => e.TimesheetEndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timesheet_end_date");
            entity.Property(e => e.TimesheetStartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timesheet_start_date");
        });

        modelBuilder.Entity<GetWorkshop>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_workshops");

            entity.Property(e => e.WorkshopChief)
                .HasColumnName("workshop_chief");
            entity.Property(e => e.WorkshopChiefPhone)
                .HasMaxLength(11)
                .HasColumnName("workshop_chief_phone");
            entity.Property(e => e.WorkshopId).HasColumnName("workshop_id");
            entity.Property(e => e.WorkshopName)
                .HasMaxLength(20)
                .HasColumnName("workshop_name");
            entity.Property(e => e.WorkshopStaffCount).HasColumnName("workshop_staff_count");
        });

        modelBuilder.Entity<TbCartOrder>(entity =>
        {
            entity.HasKey(e => new { e.CartOrderId, e.CartProductId }).HasName("tb_cart_order_pkey");

            entity.ToTable("tb_cart_order");

            entity.Property(e => e.CartOrderId).HasColumnName("cart_order_id");
            entity.Property(e => e.CartProductId).HasColumnName("cart_product_id");
            entity.Property(e => e.CartProdCount).HasColumnName("cart_prod_count");
            entity.Property(e => e.CartProdEmployeeId).HasColumnName("cart_prod_employee_id");
            entity.Property(e => e.CartProdProduceDate).HasColumnName("cart_prod_produce_date");

            entity.HasOne(d => d.CartOrder).WithMany(p => p.TbCartOrders)
                .HasForeignKey(d => d.CartOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_cart_order_cart_order_id_fkey");

            entity.HasOne(d => d.CartProdEmployee).WithMany(p => p.TbCartOrders)
                .HasForeignKey(d => d.CartProdEmployeeId)
                .HasConstraintName("tb_cart_order_cart_prod_employee_id_fkey");

            entity.HasOne(d => d.CartProduct).WithMany(p => p.TbCartOrders)
                .HasForeignKey(d => d.CartProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_cart_order_cart_product_id_fkey");
        });

        modelBuilder.Entity<TbClient>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("tb_client_pkey");

            entity.ToTable("tb_client");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ClientBirthday).HasColumnName("client_birthday");
            entity.Property(e => e.ClientFirstname)
                .HasMaxLength(30)
                .HasColumnName("client_firstname");
            entity.Property(e => e.ClientLastname)
                .HasMaxLength(30)
                .HasColumnName("client_lastname");
            entity.Property(e => e.ClientLogin)
                .HasMaxLength(50)
                .HasColumnName("client_login");
            entity.Property(e => e.ClientMiddlename)
                .HasMaxLength(30)
                .HasColumnName("client_middlename");
            entity.Property(e => e.ClientRegDate).HasColumnName("client_reg_date");

            entity.HasOne(d => d.ClientLoginNavigation).WithMany(p => p.TbClients)
                .HasForeignKey(d => d.ClientLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_client_client_login_fkey");
        });

        modelBuilder.Entity<TbEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("tb_employee_pkey");

            entity.ToTable("tb_employee");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EmployeeBirthday).HasColumnName("employee_birthday");
            entity.Property(e => e.EmployeeEducation)
                .HasMaxLength(20)
                .HasColumnName("employee_education");
            entity.Property(e => e.EmployeeFirstname)
                .HasMaxLength(20)
                .HasColumnName("employee_firstname");
            entity.Property(e => e.EmployeeHiredate).HasColumnName("employee_hiredate");
            entity.Property(e => e.EmployeeLastname)
                .HasMaxLength(20)
                .HasColumnName("employee_lastname");
            entity.Property(e => e.EmployeeLogin)
                .HasMaxLength(50)
                .HasColumnName("employee_login");
            entity.Property(e => e.EmployeeMiddlename)
                .HasMaxLength(20)
                .HasColumnName("employee_middlename");
            entity.Property(e => e.EmployeePassportNum)
                .HasMaxLength(4)
                .HasColumnName("employee_passport_num");
            entity.Property(e => e.EmployeePassportSerial)
                .HasMaxLength(6)
                .HasColumnName("employee_passport_serial");
            entity.Property(e => e.EmployeePayBonus).HasColumnName("employee_pay_bonus");
            entity.Property(e => e.EmployeePositionId).HasColumnName("employee_position_id");
            entity.Property(e => e.EmployeeWorkshopId).HasColumnName("employee_workshop_id");

            entity.HasOne(d => d.EmployeeLoginNavigation).WithMany(p => p.TbEmployees)
                .HasForeignKey(d => d.EmployeeLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_employee_employee_login_fkey");

            entity.HasOne(d => d.EmployeePosition).WithMany(p => p.TbEmployees)
                .HasForeignKey(d => d.EmployeePositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_employee_employee_position_id_fkey");

            entity.HasOne(d => d.EmployeeWorkshop).WithMany(p => p.TbEmployees)
                .HasForeignKey(d => d.EmployeeWorkshopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_employee_employee_workshop_id_fkey");
        });

        modelBuilder.Entity<TbIngredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("tb_ingredient_pkey");

            entity.ToTable("tb_ingredient");

            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.IngredientName)
                .HasMaxLength(20)
                .HasColumnName("ingredient_name");
            entity.Property(e => e.IngredientTypeId).HasColumnName("ingredient_type_id");
            entity.Property(e => e.IngredientWeight).HasColumnName("ingredient_weight");

            entity.HasOne(d => d.IngredientType).WithMany(p => p.TbIngredients)
                .HasForeignKey(d => d.IngredientTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ingredient_ingredient_type_id_fkey");
        });

        modelBuilder.Entity<TbIngredientType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("tb_ingredient_type_pkey");

            entity.ToTable("tb_ingredient_type");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(60)
                .HasColumnName("type_name");
            entity.Property(e => e.TypeStorageHumidity).HasColumnName("type_storage_humidity");
            entity.Property(e => e.TypeStorageTemp).HasColumnName("type_storage_temp");
        });

        modelBuilder.Entity<TbIngredientsExpense>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_ingredients_expense");

            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.SupplyDate).HasColumnName("supply_date");

            entity.HasOne(d => d.TbProductComposition).WithMany()
                .HasForeignKey(d => new { d.ProductId, d.IngredientId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ingredients_expense_product_id_ingredient_id_fkey");

            entity.HasOne(d => d.TbIngredientsOnWarehouse).WithMany()
                .HasForeignKey(d => new { d.IngredientId, d.SupplierId, d.SupplyDate })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ingredients_expense_ingredient_id_supplier_id_supply_da_fkey");
        });

        modelBuilder.Entity<TbIngredientsOnWarehouse>(entity =>
        {
            entity.HasKey(e => new { e.IngredientId, e.SupplierId, e.SupplyDate }).HasName("tb_ingredients_on_warehouse_pkey");

            entity.ToTable("tb_ingredients_on_warehouse");

            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.SupplyDate).HasColumnName("supply_date");
            entity.Property(e => e.IngredientCount).HasColumnName("ingredient_count");
            entity.Property(e => e.IngredientUpTo).HasColumnName("ingredient_up_to");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.TbIngredientsOnWarehouses)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ingredients_on_warehouse_ingredient_id_fkey");

            entity.HasOne(d => d.Supplier).WithMany(p => p.TbIngredientsOnWarehouses)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ingredients_on_warehouse_supplier_id_fkey");
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("tb_order_pkey");

            entity.ToTable("tb_order");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderAddress)
                .HasMaxLength(200)
                .HasColumnName("order_address");
            entity.Property(e => e.OrderClientId).HasColumnName("order_client_id");
            entity.Property(e => e.OrderCost).HasColumnName("order_cost");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderPaytypeId).HasColumnName("order_paytype_id");
            entity.Property(e => e.OrderProductCount).HasColumnName("order_product_count");
            entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");

            entity.HasOne(d => d.OrderClient).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.OrderClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_order_order_client_id_fkey");

            entity.HasOne(d => d.OrderPaytype).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.OrderPaytypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_order_order_paytype_id_fkey");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_order_order_status_id_fkey");
        });

        modelBuilder.Entity<TbOrderStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("tb_order_status_pkey");

            entity.ToTable("tb_order_status");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(20)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<TbPayType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("tb_pay_type_pkey");

            entity.ToTable("tb_pay_type");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(20)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<TbPosition>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("tb_position_pkey");

            entity.ToTable("tb_position");

            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionBasePay).HasColumnName("position_base_pay");
            entity.Property(e => e.PositionTitle)
                .HasMaxLength(20)
                .HasColumnName("position_title");
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("tb_product_pkey");

            entity.ToTable("tb_product");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductCarbohydrates).HasColumnName("product_carbohydrates");
            entity.Property(e => e.ProductFats).HasColumnName("product_fats");
            entity.Property(e => e.ProductName)
                .HasMaxLength(150)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPrice).HasColumnName("product_price");
            entity.Property(e => e.ProductProteins).HasColumnName("product_proteins");
            entity.Property(e => e.ProductWeight).HasColumnName("product_weight");
            entity.Property(e => e.ProductImage).HasDefaultValue("prodDefault.png").HasColumnName("product_image");
        });

        modelBuilder.Entity<TbProductComposition>(entity =>
        {
            entity.HasKey(e => new { e.CompositionProductId, e.CompositionIngredientId }).HasName("tb_product_composition_pkey");

            entity.ToTable("tb_product_composition");

            entity.Property(e => e.CompositionProductId).HasColumnName("composition_product_id");
            entity.Property(e => e.CompositionIngredientId).HasColumnName("composition_ingredient_id");
            entity.Property(e => e.CompositionIngredientCount).HasColumnName("composition_ingredient_count");

            entity.HasOne(d => d.CompositionProduct).WithMany(p => p.TbProductCompositions)
                .HasForeignKey(d => d.CompositionProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_product_composition_composition_product_id_fkey");
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("tb_role_pkey");

            entity.ToTable("tb_role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<TbSupplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("tb_supplier_pkey");

            entity.ToTable("tb_supplier");

            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.SupplierAddress)
                .HasMaxLength(150)
                .HasColumnName("supplier_address");
            entity.Property(e => e.SupplierContact)
                .HasMaxLength(160)
                .HasColumnName("supplier_contact");
            entity.Property(e => e.SupplierEmail)
                .HasMaxLength(320)
                .HasColumnName("supplier_email");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(20)
                .HasColumnName("supplier_name");
            entity.Property(e => e.SupplierPhone)
                .HasMaxLength(11)
                .HasColumnName("supplier_phone");
        });

        modelBuilder.Entity<TbTimesheet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_timesheet");

            entity.Property(e => e.TimesheetEmployeeId).HasColumnName("timesheet_employee_id");
            entity.Property(e => e.TimesheetEndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timesheet_end_date");
            entity.Property(e => e.TimesheetStartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timesheet_start_date");

            entity.HasOne(d => d.TimesheetEmployee).WithMany()
                .HasForeignKey(d => d.TimesheetEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_timesheet_timesheet_employee_id_fkey");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.UserLogin).HasName("tb_user_pkey");

            entity.ToTable("tb_user");

            entity.Property(e => e.UserLogin)
                .HasMaxLength(50)
                .HasColumnName("user_login");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(320)
                .HasColumnName("user_email");
            entity.Property(e => e.UserPassword).HasColumnName("user_password");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(11)
                .HasColumnName("user_phone");
            entity.Property(e => e.UserRoleId)
                .HasDefaultValue(1)
                .HasColumnName("user_role_id");
            entity.Property(e => e.UserImage)
                .HasDefaultValue("default.png")
                .HasColumnName("user_image");

            entity.HasOne(d => d.UserRole).WithMany(p => p.TbUsers)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_user_user_role_id_fkey");
        });

        modelBuilder.Entity<TbWorkshop>(entity =>
        {
            entity.HasKey(e => e.WorkshopId).HasName("tb_workshop_pkey");

            entity.ToTable("tb_workshop");

            entity.Property(e => e.WorkshopId).HasColumnName("workshop_id");
            entity.Property(e => e.WorkshopChiefPhone)
                .HasMaxLength(11)
                .HasColumnName("workshop_chief_phone");
            entity.Property(e => e.WorkshopName)
                .HasMaxLength(20)
                .HasColumnName("workshop_name");
            entity.Property(e => e.WorkshopStaffCount).HasColumnName("workshop_staff_count");
            entity.Property(e => e.WorkshopChief)
                .HasColumnName("workshop_chief");

            entity.HasOne(d => d.WorkshopEmployeeChief).WithMany(p => p.TbWorkshops)
                .HasForeignKey(d => d.WorkshopChief)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_workshop_workshop_chief_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
