using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using diagoback.Models;

namespace diagoback.Models
{
    public partial class diagodbContext : DbContext
    {
        public diagodbContext(DbContextOptions<diagodbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<BillHistories> BillHistories { get; set; }
        public virtual DbSet<BillItemTaxes> BillItemTaxes { get; set; }
        public virtual DbSet<BillItems> BillItems { get; set; }
        public virtual DbSet<BillTotals> BillTotals { get; set; }
        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<Dashboards> Dashboards { get; set; }
        public virtual DbSet<EmailTemplates> EmailTemplates { get; set; }
        public virtual DbSet<FailedJobs> FailedJobs { get; set; }
        public virtual DbSet<FirewallIps> FirewallIps { get; set; }
        public virtual DbSet<FirewallLogs> FirewallLogs { get; set; }
        public virtual DbSet<InvoiceHistories> InvoiceHistories { get; set; }
        public virtual DbSet<InvoiceItemTaxes> InvoiceItemTaxes { get; set; }
        public virtual DbSet<InvoiceItems> InvoiceItems { get; set; }
        public virtual DbSet<InvoiceTotals> InvoiceTotals { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Mediables> Mediables { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<ModuleHistories> ModuleHistories { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<PasswordResets> PasswordResets { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Reconciliations> Reconciliations { get; set; }
        public virtual DbSet<Recurring> Recurring { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<RolePermissions> RolePermissions { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Taxes> Taxes { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Transfers> Transfers { get; set; }
        public virtual DbSet<UserCompanies> UserCompanies { get; set; }
        public virtual DbSet<UserDashboards> UserDashboards { get; set; }
        public virtual DbSet<UserPermissions> UserPermissions { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Widgets> Widgets { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password='';database=diagodb");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.ToTable("accounts");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_accounts_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BankAddress)
                    .HasColumnName("bank_address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.BankName)
                    .HasColumnName("bank_name")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.BankPhone)
                    .HasColumnName("bank_phone")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("currency_code")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.OpeningBalance)
                    .HasColumnName("opening_balance")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<BillHistories>(entity =>
            {
                entity.ToTable("bill_histories");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_bill_histories_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BillId)
                    .HasColumnName("bill_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Notify)
                    .HasColumnName("notify")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<BillItemTaxes>(entity =>
            {
                entity.ToTable("bill_item_taxes");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_bill_item_taxes_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.BillId)
                    .HasColumnName("bill_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BillItemId)
                    .HasColumnName("bill_item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.TaxId)
                    .HasColumnName("tax_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<BillItems>(entity =>
            {
                entity.ToTable("bill_items");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_bill_items_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BillId)
                    .HasColumnName("bill_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DiscountRate)
                    .HasColumnName("discount_rate")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.DiscountType)
                    .IsRequired()
                    .HasColumnName("discount_type")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'''normal'''");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("double(7,2)");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<BillTotals>(entity =>
            {
                entity.ToTable("bill_totals");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_bill_totals_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.BillId)
                    .HasColumnName("bill_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.SortOrder)
                    .HasColumnName("sort_order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Bills>(entity =>
            {
                entity.ToTable("bills");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_bills_company_id_index");

                entity.HasIndex(e => new { e.CompanyId, e.BillNumber, e.DeletedAt })
                    .HasName("5mv_bills_company_id_bill_number_deleted_at_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.BillNumber)
                    .IsRequired()
                    .HasColumnName("bill_number")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.BilledAt).HasColumnName("billed_at");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactAddress)
                    .HasColumnName("contact_address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContactEmail)
                    .HasColumnName("contact_email")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContactId)
                    .HasColumnName("contact_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasColumnName("contact_name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasColumnName("contact_phone")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContactTaxNumber)
                    .HasColumnName("contact_tax_number")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("currency_code")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyRate)
                    .HasColumnName("currency_rate")
                    .HasColumnType("double(15,8)");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DueAt).HasColumnName("due_at");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OrderNumber)
                    .HasColumnName("order_number")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_categories_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.ToTable("companies");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Domain)
                    .HasColumnName("domain")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.ToTable("contacts");

                entity.HasIndex(e => new { e.CompanyId, e.Type })
                    .HasName("5mv_contacts_company_id_type_index");

                entity.HasIndex(e => new { e.CompanyId, e.Type, e.Email, e.DeletedAt })
                    .HasName("5mv_contacts_company_id_type_email_deleted_at_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("currency_code")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Reference)
                    .HasColumnName("reference")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TaxNumber)
                    .HasColumnName("tax_number")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.ToTable("currencies");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_currencies_company_id_index");

                entity.HasIndex(e => new { e.CompanyId, e.Code, e.DeletedAt })
                    .HasName("5mv_currencies_company_id_code_deleted_at_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DecimalMark)
                    .HasColumnName("decimal_mark")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Precision)
                    .HasColumnName("precision")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("double(15,8)");

                entity.Property(e => e.Symbol)
                    .HasColumnName("symbol")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SymbolFirst)
                    .HasColumnName("symbol_first")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ThousandsSeparator)
                    .HasColumnName("thousands_separator")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Dashboards>(entity =>
            {
                entity.ToTable("dashboards");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_dashboards_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<EmailTemplates>(entity =>
            {
                entity.ToTable("email_templates");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_email_templates_company_id_index");

                entity.HasIndex(e => new { e.CompanyId, e.Alias, e.DeletedAt })
                    .HasName("5mv_email_templates_company_id_alias_deleted_at_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasColumnName("alias")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasColumnName("class")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Params)
                    .HasColumnName("params")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<FailedJobs>(entity =>
            {
                entity.ToTable("failed_jobs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Connection)
                    .IsRequired()
                    .HasColumnName("connection");

                entity.Property(e => e.Exception)
                    .IsRequired()
                    .HasColumnName("exception")
                    .HasColumnType("longtext");

                entity.Property(e => e.FailedAt)
                    .HasColumnName("failed_at")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Payload)
                    .IsRequired()
                    .HasColumnName("payload")
                    .HasColumnType("longtext");

                entity.Property(e => e.Queue)
                    .IsRequired()
                    .HasColumnName("queue");
            });

            modelBuilder.Entity<FirewallIps>(entity =>
            {
                entity.ToTable("firewall_ips");

                entity.HasIndex(e => e.Ip)
                    .HasName("5mv_firewall_ips_ip_index");

                entity.HasIndex(e => new { e.Ip, e.DeletedAt })
                    .HasName("5mv_firewall_ips_ip_deleted_at_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Blocked)
                    .HasColumnName("blocked")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<FirewallLogs>(entity =>
            {
                entity.ToTable("firewall_logs");

                entity.HasIndex(e => e.Ip)
                    .HasName("5mv_firewall_logs_ip_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnName("level")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'''medium'''");

                entity.Property(e => e.Middleware)
                    .IsRequired()
                    .HasColumnName("middleware")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Referrer)
                    .HasColumnName("referrer")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Request)
                    .HasColumnName("request")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<InvoiceHistories>(entity =>
            {
                entity.ToTable("invoice_histories");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_invoice_histories_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notify)
                    .HasColumnName("notify")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<InvoiceItemTaxes>(entity =>
            {
                entity.ToTable("invoice_item_taxes");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_invoice_item_taxes_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceItemId)
                    .HasColumnName("invoice_item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.TaxId)
                    .HasColumnName("tax_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<InvoiceItems>(entity =>
            {
                entity.ToTable("invoice_items");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_invoice_items_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DiscountRate)
                    .HasColumnName("discount_rate")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.DiscountType)
                    .IsRequired()
                    .HasColumnName("discount_type")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'''normal'''");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("double(7,2)");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<InvoiceTotals>(entity =>
            {
                entity.ToTable("invoice_totals");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_invoice_totals_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.SortOrder)
                    .HasColumnName("sort_order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.ToTable("invoices");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_invoices_company_id_index");

                entity.HasIndex(e => new { e.CompanyId, e.InvoiceNumber, e.DeletedAt })
                    .HasName("5mv_invoices_company_id_invoice_number_deleted_at_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactAddress)
                    .HasColumnName("contact_address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContactEmail)
                    .HasColumnName("contact_email")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContactId)
                    .HasColumnName("contact_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasColumnName("contact_name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasColumnName("contact_phone")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContactTaxNumber)
                    .HasColumnName("contact_tax_number")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("currency_code")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyRate)
                    .HasColumnName("currency_rate")
                    .HasColumnType("double(15,8)");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DueAt).HasColumnName("due_at");

                entity.Property(e => e.Footer)
                    .HasColumnName("footer")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasColumnName("invoice_number")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.InvoicedAt).HasColumnName("invoiced_at");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OrderNumber)
                    .HasColumnName("order_number")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.ToTable("items");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_items_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.PurchasePrice)
                    .HasColumnName("purchase_price")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SalePrice)
                    .HasColumnName("sale_price")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TaxId)
                    .HasColumnName("tax_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.ToTable("jobs");

                entity.HasIndex(e => new { e.Queue, e.ReservedAt })
                    .HasName("5mv_jobs_queue_reserved_at_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Attempts)
                    .HasColumnName("attempts")
                    .HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.AvailableAt)
                    .HasColumnName("available_at")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Payload)
                    .IsRequired()
                    .HasColumnName("payload")
                    .HasColumnType("longtext");

                entity.Property(e => e.Queue)
                    .IsRequired()
                    .HasColumnName("queue")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.ReservedAt)
                    .HasColumnName("reserved_at")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.ToTable("media");

                entity.HasIndex(e => e.AggregateType)
                    .HasName("5mv_media_aggregate_type_index");

                entity.HasIndex(e => new { e.Disk, e.Directory })
                    .HasName("5mv_media_disk_directory_index");

                entity.HasIndex(e => new { e.Disk, e.Directory, e.Filename, e.Extension, e.DeletedAt })
                    .HasName("5mv_media_disk_directory_filename_extension_deleted_at_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AggregateType)
                    .IsRequired()
                    .HasColumnName("aggregate_type")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Directory)
                    .IsRequired()
                    .HasColumnName("directory")
                    .HasMaxLength(68)
                    .IsUnicode(false);

                entity.Property(e => e.Disk)
                    .IsRequired()
                    .HasColumnName("disk")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasColumnName("extension")
                    .HasMaxLength(28)
                    .IsUnicode(false);

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasMaxLength(121)
                    .IsUnicode(false);

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasColumnName("mime_type")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Mediables>(entity =>
            {
                entity.HasKey(e => new { e.MediaId, e.MediableType, e.MediableId, e.Tag })
                    .HasName("PRIMARY");

                entity.ToTable("mediables");

                entity.HasIndex(e => e.Order)
                    .HasName("5mv_mediables_order_index");

                entity.HasIndex(e => e.Tag)
                    .HasName("5mv_mediables_tag_index");

                entity.HasIndex(e => new { e.MediableId, e.MediableType })
                    .HasName("5mv_mediables_mediable_id_mediable_type_index");

                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.MediableType)
                    .HasColumnName("mediable_type")
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.MediableId)
                    .HasColumnName("mediable_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Tag)
                    .HasColumnName("tag")
                    .HasMaxLength(68)
                    .IsUnicode(false);

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.Mediables)
                    .HasForeignKey(d => d.MediaId)
                    .HasConstraintName("5mv_mediables_media_id_foreign");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasMaxLength(191)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModuleHistories>(entity =>
            {
                entity.ToTable("module_histories");

                entity.HasIndex(e => new { e.CompanyId, e.ModuleId })
                    .HasName("5mv_module_histories_company_id_module_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("module_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasMaxLength(191)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modules>(entity =>
            {
                entity.ToTable("modules");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_modules_company_id_index");

                entity.HasIndex(e => new { e.CompanyId, e.Alias, e.DeletedAt })
                    .HasName("5mv_modules_company_id_alias_deleted_at_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasColumnName("alias")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.ToTable("notifications");

                entity.HasIndex(e => new { e.NotifiableType, e.NotifiableId })
                    .HasName("5mv_notifications_notifiable_type_notifiable_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data");

                entity.Property(e => e.NotifiableId)
                    .HasColumnName("notifiable_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.NotifiableType)
                    .IsRequired()
                    .HasColumnName("notifiable_type")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.ReadAt)
                    .HasColumnName("read_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<PasswordResets>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("password_resets");

                entity.HasIndex(e => e.Email)
                    .HasName("5mv_password_resets_email_index");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(191)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.ToTable("permissions");

                entity.HasIndex(e => e.Name)
                    .HasName("5mv_permissions_name_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("display_name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Reconciliations>(entity =>
            {
                entity.ToTable("reconciliations");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_reconciliations_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClosingBalance)
                    .HasColumnName("closing_balance")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EndedAt).HasColumnName("ended_at");

                entity.Property(e => e.Reconciled)
                    .HasColumnName("reconciled")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.StartedAt).HasColumnName("started_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Recurring>(entity =>
            {
                entity.ToTable("recurring");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_recurring_company_id_index");

                entity.HasIndex(e => new { e.RecurableType, e.RecurableId })
                    .HasName("5mv_recurring_recurable_type_recurable_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Frequency)
                    .IsRequired()
                    .HasColumnName("frequency")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Interval)
                    .HasColumnName("interval")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.RecurableId)
                    .HasColumnName("recurable_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.RecurableType)
                    .IsRequired()
                    .HasColumnName("recurable_type")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.StartedAt).HasColumnName("started_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.ToTable("reports");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_reports_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasColumnName("class")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Settings)
                    .HasColumnName("settings")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<RolePermissions>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PermissionId })
                    .HasName("PRIMARY");

                entity.ToTable("role_permissions");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("5mv_role_permissions_permission_id_foreign");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permission_id")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("5mv_role_permissions_permission_id_foreign");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("5mv_role_permissions_role_id_foreign");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.Name)
                    .HasName("5mv_roles_name_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("display_name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sessions");

                entity.HasIndex(e => e.Id)
                    .HasName("5mv_sessions_id_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("id")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LastActivity)
                    .HasColumnName("last_activity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Payload)
                    .IsRequired()
                    .HasColumnName("payload");

                entity.Property(e => e.UserAgent)
                    .HasColumnName("user_agent")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.ToTable("settings");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_settings_company_id_index");

                entity.HasIndex(e => new { e.CompanyId, e.Key })
                    .HasName("5mv_settings_company_id_key_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Taxes>(entity =>
            {
                entity.ToTable("taxes");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_taxes_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'''normal'''");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.ToTable("transactions");

                entity.HasIndex(e => new { e.CompanyId, e.Type })
                    .HasName("5mv_transactions_company_id_type_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("double(15,4)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactId)
                    .HasColumnName("contact_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("currency_code")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyRate)
                    .HasColumnName("currency_rate")
                    .HasColumnType("double(15,8)");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DocumentId)
                    .HasColumnName("document_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaidAt).HasColumnName("paid_at");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasColumnName("payment_method")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Reconciled)
                    .HasColumnName("reconciled")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Reference)
                    .HasColumnName("reference")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Transfers>(entity =>
            {
                entity.ToTable("transfers");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("5mv_transfers_company_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ExpenseTransactionId)
                    .HasColumnName("expense_transaction_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IncomeTransactionId)
                    .HasColumnName("income_transaction_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<UserCompanies>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CompanyId, e.UserType })
                    .HasName("PRIMARY");

                entity.ToTable("user_companies");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserType)
                    .HasColumnName("user_type")
                    .HasMaxLength(191)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserDashboards>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.DashboardId, e.UserType })
                    .HasName("PRIMARY");

                entity.ToTable("user_dashboards");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.DashboardId)
                    .HasColumnName("dashboard_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserType)
                    .HasColumnName("user_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserPermissions>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PermissionId, e.UserType })
                    .HasName("PRIMARY");

                entity.ToTable("user_permissions");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("5mv_user_permissions_permission_id_foreign");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permission_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserType)
                    .HasColumnName("user_type")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("5mv_user_permissions_permission_id_foreign");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId, e.UserType })
                    .HasName("PRIMARY");

                entity.ToTable("user_roles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("5mv_user_roles_role_id_foreign");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserType)
                    .HasColumnName("user_type")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("5mv_user_roles_role_id_foreign");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => new { e.Email, e.DeletedAt })
                    .HasName("5mv_users_email_deleted_at_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LandingPage)
                    .HasColumnName("landing_page")
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'''dashboard'''");

                entity.Property(e => e.LastLoggedInAt)
                    .HasColumnName("last_logged_in_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasColumnName("locale")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'''en-GB'''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Widgets>(entity =>
            {
                entity.ToTable("widgets");

                entity.HasIndex(e => new { e.CompanyId, e.DashboardId })
                    .HasName("5mv_widgets_company_id_dashboard_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasColumnName("class")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DashboardId)
                    .HasColumnName("dashboard_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Settings)
                    .HasColumnName("settings")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<diagoback.Models.UserItem> UserItem { get; set; }
    }
}
