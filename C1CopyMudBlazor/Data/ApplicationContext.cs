using C1CopyMudBlazor.Data;
using C1CopyMudBlazor.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace C1CopyMudBlazor.Data;
public class ApplicationContext : DbContext
{
    private readonly IConfiguration configuration;
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<LegalEntities> LegalEntities { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Tech> Teches { get; set; }
    public DbSet<WorkPlace> WorkPlaces { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=roflik;", 
            new MySqlServerVersion(new Version(8, 0, 29)));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var ad = new Role{RoleID= 1,Name = "admin"};
        var us = new Role{RoleID=2,Name = "user"};
        modelBuilder.Entity<Role>().HasData(
            ad,
            us
        );
        modelBuilder.Entity<Account>().HasData(
            new Account{ID = 1,Email = "asd",Password = "123",RoleID = 2},
            new Account{ID = 2,Email = "theanfishow@gmail.com",Password = "123",RoleID = 1}
        );
        
        modelBuilder.Entity<Client>().HasData(
            new Client{ID = 1,Name = "Embasy" },
            new Client{ID = 2,Name = "ITbox" }
        );
        modelBuilder.Entity<LegalEntities>().HasData(
            new LegalEntities{ID = 1,Name = "EmbasyLegal", Email = "random@mail.com", ClientID = 1},
            new LegalEntities{ID = 2,Name = "ITboxLegal",Email = "random@mail.com", ClientID = 2}
        );
        modelBuilder.Entity<Office>()
            .HasData(
                new Office { ID = 1, ClientID = 1, Adress = "ул.Полевая д.19", City = "Minsk", OfficeName="Минск",Floor=9, Cabinet = 72},
                new Office { ID = 2, ClientID = 2, Adress = "ул.Полевая д.22", City = "Minsk", OfficeName="КЗ",Floor=2, Cabinet = 22});
        modelBuilder.Entity<Tech>()
            .HasData(
                new Tech() { ID = 1, OfficeID = 1, WorkerID = 1,WorkPlaceID = 1, Type = "PC", InventaryID = "ITB001249", Manufacturer = "Xiaomi", Model = "Lohotron", IPAdress = "192.172.0.19"},
                new Tech() { ID = 2, OfficeID = 1, WorkerID = 1,WorkPlaceID = 2, Type = "Phone", InventaryID = "ITB001229", Manufacturer = "Yeahlink", Model = "Lohotron", IPAdress = "192.172.0.19"},
                new Tech() { ID = 3, OfficeID = 2, WorkerID = 2,WorkPlaceID = 3, Type = "PC", InventaryID = "ITB001439", Manufacturer = "Xiaomi", Model = "Lohotron", IPAdress = "192.172.0.19"}
                );
        modelBuilder.Entity<WorkPlace>()
            .HasData(
                new WorkPlace() {ID = 1, OfficeID = 1, WorkplaceNumber = 1},
                new WorkPlace() {ID = 2, OfficeID = 1, WorkplaceNumber = 2},
                new WorkPlace() {ID = 3, OfficeID = 2, WorkplaceNumber = 1},
                new WorkPlace() {ID = 4, OfficeID = 2, WorkplaceNumber = 2}
     
                );
        modelBuilder.Entity<Worker>()
            .HasData(
                new Worker {ID = 1,OfficeID=1,WorkPlaceID=1,FIO="Харсанов Фарид",Position = "Бух",Email = "f.kharsanov@machinerylogistics.kz",EmailPass = "KhFa9312!",OwnPhoneNumber = "+7758392415", ServerIP = "172.15.0.31",
                    AnyDesk = "611110401",AnyDeskPass = "1410001m!",UserAD = "f.kharsanov@pro-jecta.loc",PassAD="KhFa9312!",
                    FIOEng= "Kharsanov Farid", PhoneLog="2038",PhonePass = "229f6eb1b905f6f4492cfec4b2eb542b",
                    PhoneOutsideNumber = "77273102020"},
                new Worker {ID = 2,OfficeID=2,WorkPlaceID=3,FIO="Поздняк Евгений",Position = "Директор",Email = "e.pozner999@machinerylogistics.kz",EmailPass = "KhFa9312!",OwnPhoneNumber = "+7758392415", ServerIP = "172.15.0.31",
                    AnyDesk = "611110401",AnyDeskPass = "1410001m!",UserAD = "f.kharsanov@pro-jecta.loc",PassAD="KhFa9312!",
                    FIOEng= "Kharsanov Farid", PhoneLog="2038",PhonePass = "229f6eb1b905f6f4492cfec4b2eb542b",
                    PhoneOutsideNumber = "77273102020"}
                );
        /*public int ClientID { get; set; }
    //Human
    [MaxLength(60)]
    public string FIO { get; set; }
    public int OfficeID { get; set; }
    public string? ServerIP { get; set; }
    public int Place { get; set; }
    public string Number { get; set; }
    //Anydesk
    public string AnyDesk { get; set; }
    public string AnyDeskPass { get; set; }
    //PC
    public string TechID { get; set; }
    public string UserAD { get; set; }
    public string PassAD { get; set; }
    public string TechIP { get; set; }
    //Email
    public string FIOEng { get; set; }
    public string Login { get; set; }
    public string EmailPass { get; set; }
    //Phoner
    public string PhoneLog { get; set; }
    public string PhonePass { get; set; }
    public string OutsideNumber { get; set; }
    public string PhoneIP { get; set; }*/

    }
}