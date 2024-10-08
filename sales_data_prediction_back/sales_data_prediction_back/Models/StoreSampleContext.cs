﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sales_data_prediction_back.Models
{
    public partial class StoreSampleContext : DbContext
    {
        public StoreSampleContext()
        {
        }

        public StoreSampleContext(DbContextOptions<StoreSampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CustOrders> CustOrders { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderTotalsByYear> OrderTotalsByYear { get; set; }
        public virtual DbSet<OrderValues> OrderValues { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=StoreSample;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.Categoryid);

                entity.ToTable("Categories", "Production");

                entity.HasIndex(e => e.Categoryname)
                    .HasName("categoryname");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasColumnName("categoryname")
                    .HasMaxLength(15);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<CustOrders>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CustOrders", "Sales");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Ordermonth)
                    .HasColumnName("ordermonth")
                    .HasColumnType("datetime");

                entity.Property(e => e.Qty).HasColumnName("qty");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Custid);

                entity.ToTable("Customers", "Sales");

                entity.HasIndex(e => e.City)
                    .HasName("idx_nc_city");

                entity.HasIndex(e => e.Companyname)
                    .HasName("idx_nc_companyname");

                entity.HasIndex(e => e.Postalcode)
                    .HasName("idx_nc_postalcode");

                entity.HasIndex(e => e.Region)
                    .HasName("idx_nc_region");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(60);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15);

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname")
                    .HasMaxLength(40);

                entity.Property(e => e.Contactname)
                    .IsRequired()
                    .HasColumnName("contactname")
                    .HasMaxLength(30);

                entity.Property(e => e.Contacttitle)
                    .IsRequired()
                    .HasColumnName("contacttitle")
                    .HasMaxLength(30);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(15);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(24);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(24);

                entity.Property(e => e.Postalcode)
                    .HasColumnName("postalcode")
                    .HasMaxLength(10);

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.Empid);

                entity.ToTable("Employees", "HR");

                entity.HasIndex(e => e.Lastname)
                    .HasName("idx_nc_lastname");

                entity.HasIndex(e => e.Postalcode)
                    .HasName("idx_nc_postalcode");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(60);

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(15);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(10);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("hiredate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(20);

                entity.Property(e => e.Mgrid).HasColumnName("mgrid");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(24);

                entity.Property(e => e.Postalcode)
                    .HasColumnName("postalcode")
                    .HasMaxLength(10);

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasMaxLength(15);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(30);

                entity.Property(e => e.Titleofcourtesy)
                    .IsRequired()
                    .HasColumnName("titleofcourtesy")
                    .HasMaxLength(25);

                entity.HasOne(d => d.Mgr)
                    .WithMany(p => p.InverseMgr)
                    .HasForeignKey(d => d.Mgrid)
                    .HasConstraintName("FK_Employees_Employees");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.Orderid, e.Productid });

                entity.ToTable("OrderDetails", "Sales");

                entity.HasIndex(e => e.Orderid)
                    .HasName("idx_nc_orderid");

                entity.HasIndex(e => e.Productid)
                    .HasName("idx_nc_productid");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(4, 3)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Unitprice)
                    .HasColumnName("unitprice")
                    .HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<OrderTotalsByYear>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OrderTotalsByYear", "Sales");

                entity.Property(e => e.Orderyear).HasColumnName("orderyear");

                entity.Property(e => e.Qty).HasColumnName("qty");
            });

            modelBuilder.Entity<OrderValues>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OrderValues", "Sales");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Shipperid).HasColumnName("shipperid");

                entity.Property(e => e.Val)
                    .HasColumnName("val")
                    .HasColumnType("numeric(12, 2)");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Orderid);

                entity.ToTable("Orders", "Sales");

                entity.HasIndex(e => e.Custid)
                    .HasName("idx_nc_custid");

                entity.HasIndex(e => e.Empid)
                    .HasName("idx_nc_empid");

                entity.HasIndex(e => e.Orderdate)
                    .HasName("idx_nc_orderdate");

                entity.HasIndex(e => e.Shippeddate)
                    .HasName("idx_nc_shippeddate");

                entity.HasIndex(e => e.Shipperid)
                    .HasName("idx_nc_shipperid");

                entity.HasIndex(e => e.Shippostalcode)
                    .HasName("idx_nc_shippostalcode");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Freight)
                    .HasColumnName("freight")
                    .HasColumnType("money");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Requireddate)
                    .HasColumnName("requireddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Shipaddress)
                    .IsRequired()
                    .HasColumnName("shipaddress")
                    .HasMaxLength(60);

                entity.Property(e => e.Shipcity)
                    .IsRequired()
                    .HasColumnName("shipcity")
                    .HasMaxLength(15);

                entity.Property(e => e.Shipcountry)
                    .IsRequired()
                    .HasColumnName("shipcountry")
                    .HasMaxLength(15);

                entity.Property(e => e.Shipname)
                    .IsRequired()
                    .HasColumnName("shipname")
                    .HasMaxLength(40);

                entity.Property(e => e.Shippeddate)
                    .HasColumnName("shippeddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Shipperid).HasColumnName("shipperid");

                entity.Property(e => e.Shippostalcode)
                    .HasColumnName("shippostalcode")
                    .HasMaxLength(10);

                entity.Property(e => e.Shipregion)
                    .HasColumnName("shipregion")
                    .HasMaxLength(15);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Custid)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Empid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Employees");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Shipperid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Shippers");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Productid);

                entity.ToTable("Products", "Production");

                entity.HasIndex(e => e.Categoryid)
                    .HasName("idx_nc_categoryid");

                entity.HasIndex(e => e.Productname)
                    .HasName("idx_nc_productname");

                entity.HasIndex(e => e.Supplierid)
                    .HasName("idx_nc_supplierid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Discontinued).HasColumnName("discontinued");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasColumnName("productname")
                    .HasMaxLength(40);

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.Property(e => e.Unitprice)
                    .HasColumnName("unitprice")
                    .HasColumnType("money");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Supplierid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            modelBuilder.Entity<Shippers>(entity =>
            {
                entity.HasKey(e => e.Shipperid);

                entity.ToTable("Shippers", "Sales");

                entity.Property(e => e.Shipperid).HasColumnName("shipperid");

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname")
                    .HasMaxLength(40);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(24);
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.Supplierid);

                entity.ToTable("Suppliers", "Production");

                entity.HasIndex(e => e.Companyname)
                    .HasName("idx_nc_companyname");

                entity.HasIndex(e => e.Postalcode)
                    .HasName("idx_nc_postalcode");

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(60);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15);

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname")
                    .HasMaxLength(40);

                entity.Property(e => e.Contactname)
                    .IsRequired()
                    .HasColumnName("contactname")
                    .HasMaxLength(30);

                entity.Property(e => e.Contacttitle)
                    .IsRequired()
                    .HasColumnName("contacttitle")
                    .HasMaxLength(30);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(15);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(24);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(24);

                entity.Property(e => e.Postalcode)
                    .HasColumnName("postalcode")
                    .HasMaxLength(10);

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
