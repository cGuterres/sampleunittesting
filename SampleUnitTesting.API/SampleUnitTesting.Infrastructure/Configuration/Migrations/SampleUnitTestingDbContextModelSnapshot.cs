﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleUnitTesting.Infrastructure;

#nullable disable

namespace SampleUnitTesting.Infrastructure.Configuration.Migrations
{
    [DbContext(typeof(SampleUnitTestingDbContext))]
    partial class SampleUnitTestingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AttendantCustomer", b =>
                {
                    b.Property<int>("AttendantsId")
                        .HasColumnType("int");

                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.HasKey("AttendantsId", "CustomersId");

                    b.HasIndex("CustomersId");

                    b.ToTable("AttendantCustomer", "SampleUnitTesting");
                });

            modelBuilder.Entity("SampleUnitTesting.Domain.Attendant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 5, 8, 5, 15, 13, 666, DateTimeKind.Utc).AddTicks(4408));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 5, 8, 5, 15, 13, 666, DateTimeKind.Utc).AddTicks(4525));

                    b.HasKey("Id");

                    b.ToTable("Attendants", "SampleUnitTesting");
                });

            modelBuilder.Entity("SampleUnitTesting.Domain.AttendantCustomer", b =>
                {
                    b.Property<int>("AttendantId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("AttendantId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("AttendantCustomer", (string)null);
                });

            modelBuilder.Entity("SampleUnitTesting.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 5, 8, 5, 15, 13, 666, DateTimeKind.Utc).AddTicks(5173));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 5, 8, 5, 15, 13, 666, DateTimeKind.Utc).AddTicks(5280));

                    b.HasKey("Id");

                    b.ToTable("Customers", "SampleUnitTesting");
                });

            modelBuilder.Entity("AttendantCustomer", b =>
                {
                    b.HasOne("SampleUnitTesting.Domain.Attendant", null)
                        .WithMany()
                        .HasForeignKey("AttendantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleUnitTesting.Domain.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SampleUnitTesting.Domain.AttendantCustomer", b =>
                {
                    b.HasOne("SampleUnitTesting.Domain.Attendant", "Attendant")
                        .WithMany("AttendantCustomers")
                        .HasForeignKey("AttendantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleUnitTesting.Domain.Customer", "Customer")
                        .WithMany("AttendantCustomers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendant");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SampleUnitTesting.Domain.Attendant", b =>
                {
                    b.Navigation("AttendantCustomers");
                });

            modelBuilder.Entity("SampleUnitTesting.Domain.Customer", b =>
                {
                    b.Navigation("AttendantCustomers");
                });
#pragma warning restore 612, 618
        }
    }
}
