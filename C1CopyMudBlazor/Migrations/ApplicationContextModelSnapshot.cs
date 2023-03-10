﻿// <auto-generated />
using System;
using C1CopyMudBlazor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace C1CopyMudBlazor.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccountRole", b =>
                {
                    b.Property<int>("AccountsID")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("AccountsID", "RoleID");

                    b.HasIndex("RoleID");

                    b.ToTable("AccountRole");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.LegalEntities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("BuhID")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<int?>("DirID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UNP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BuhID");

                    b.HasIndex("ClientID");

                    b.HasIndex("DirID");

                    b.ToTable("LegalEntities");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.Office", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Cabinet")
                        .HasColumnType("bigint");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.Tech", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("IPAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventaryID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfficeID")
                        .HasColumnType("int");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkPlaceID")
                        .HasColumnType("int");

                    b.Property<int?>("WorkerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("OfficeID");

                    b.HasIndex("WorkPlaceID");

                    b.HasIndex("WorkerID");

                    b.ToTable("Teches");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.WorkPlace", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("OfficeID")
                        .HasColumnType("int");

                    b.Property<string>("WorkplaceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("OfficeID");

                    b.ToTable("WorkPlaces");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.Worker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AnyDesk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnyDeskPass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailPass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("FIOEng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfficeID")
                        .HasColumnType("int");

                    b.Property<string>("OwnPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassAD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneLog")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneOutsideNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhonePass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkPlaceID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("OfficeID");

                    b.HasIndex("WorkPlaceID");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AccountRole", b =>
                {
                    b.HasOne("C1CopyMudBlazor.Data.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("C1CopyMudBlazor.Data.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.LegalEntities", b =>
                {
                    b.HasOne("C1CopyMudBlazor.Data.Entities.Worker", "Buh")
                        .WithMany()
                        .HasForeignKey("BuhID");

                    b.HasOne("C1CopyMudBlazor.Data.Entities.Client", "Client")
                        .WithMany("LegalEntitie")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("C1CopyMudBlazor.Data.Entities.Worker", "Dir")
                        .WithMany()
                        .HasForeignKey("DirID");

                    b.Navigation("Buh");

                    b.Navigation("Client");

                    b.Navigation("Dir");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.Office", b =>
                {
                    b.HasOne("C1CopyMudBlazor.Data.Entities.Client", "Client")
                        .WithMany("Offices")
                        .HasForeignKey("ClientID");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.Tech", b =>
                {
                    b.HasOne("C1CopyMudBlazor.Data.Entities.Worker", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("C1CopyMudBlazor.Data.Entities.Office", "Office")
                        .WithMany("Teches")
                        .HasForeignKey("OfficeID");

                    b.HasOne("C1CopyMudBlazor.Data.Entities.WorkPlace", "WorkPlace")
                        .WithMany("teches")
                        .HasForeignKey("WorkPlaceID");

                    b.HasOne("C1CopyMudBlazor.Data.Entities.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerID");

                    b.Navigation("Client");

                    b.Navigation("Office");

                    b.Navigation("WorkPlace");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.WorkPlace", b =>
                {
                    b.HasOne("C1CopyMudBlazor.Data.Entities.Office", "Office")
                        .WithMany("WorkPlaces")
                        .HasForeignKey("OfficeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.Worker", b =>
                {
                    b.HasOne("C1CopyMudBlazor.Data.Entities.Client", null)
                        .WithMany("Workers")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("C1CopyMudBlazor.Data.Entities.Office", "Office")
                        .WithMany("Workers")
                        .HasForeignKey("OfficeID");

                    b.HasOne("C1CopyMudBlazor.Data.Entities.WorkPlace", "WorkPlace")
                        .WithMany()
                        .HasForeignKey("WorkPlaceID");

                    b.Navigation("Office");

                    b.Navigation("WorkPlace");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.Client", b =>
                {
                    b.Navigation("LegalEntitie");

                    b.Navigation("Offices");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.Office", b =>
                {
                    b.Navigation("Teches");

                    b.Navigation("WorkPlaces");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("C1CopyMudBlazor.Data.Entities.WorkPlace", b =>
                {
                    b.Navigation("teches");
                });
#pragma warning restore 612, 618
        }
    }
}
