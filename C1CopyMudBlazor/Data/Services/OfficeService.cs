using C1CopyMudBlazor.Data.Entities;
using C1CopyMudBlazor.Data.Interfaces;

namespace C1CopyMudBlazor.Data.Services;

public class OfficeService : IOfficeService
{
    private readonly ApplicationContext _dbContext;
    public OfficeService(ApplicationContext context)
    {
        _dbContext = context;
    }
    public void DeleteOffice(int id)
    {
        
        var office = _dbContext.Offices.FirstOrDefault(x => x.ID == id);
        if(office!=null)
        {
            _dbContext.Offices.Remove(office);
            _dbContext.SaveChanges();
        }
    }
    public Office GetOfficeById(int id)
    {
        var office = _dbContext.Offices.SingleOrDefault(x => x.ID == id);
        return office;
    }
    public List<Office> GetOffices()
    {
        return _dbContext.Offices.ToList();
    }
    public void SaveOffice(Office office)
    {
        if (office.ID == 0) _dbContext.Offices.Add(office);
        else _dbContext.Offices.Update(office);
        _dbContext.SaveChanges();
    }
}