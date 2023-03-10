using C1CopyMudBlazor.Data.Entities;
using C1CopyMudBlazor.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace C1CopyMudBlazor.Data.Services;

public class LegalEntitiesService : ILegalEntitiesService
{
    private readonly ApplicationContext _dbContext;
    public LegalEntitiesService(ApplicationContext context)
    {
        _dbContext = context;
    }
    public List<LegalEntities> GetLegalEntities()
    {
        return _dbContext.LegalEntities.ToList();
    }

    public IEnumerable<LegalEntities> GetLegalEntitiesByClient(string client)
    {
        return _dbContext.LegalEntities.Include(b=>b.Client).Where(b=>b.Client.Name == client).ToList();
    }

    public LegalEntities GetLegalEntitiesById(int id)
    {
        var LegalEntitie = _dbContext.LegalEntities.FirstOrDefault(x => x.ID == id);
        return LegalEntitie;
    }
    public LegalEntities GetLegalEntitiesByName(string name)
    {
        var LegalEntitie = _dbContext.LegalEntities.Include(b=>b.Client).Include(b=>b.Buh)
            .Include(b=>b.Dir).SingleOrDefault(x => x.Name == name);
        return LegalEntitie;
    }

    public void SaveLegalEntities(LegalEntities legal)
    {
        if (legal.ID == 0) _dbContext.LegalEntities.Add(legal);
        else _dbContext.LegalEntities.Update(legal);
        _dbContext.SaveChanges();
    }

    public void DeleteLegalEntities(int id)
    {
        var worker = _dbContext.LegalEntities.FirstOrDefault(x => x.ID == id);
        if(worker!=null)
        {
            _dbContext.LegalEntities.Remove(worker);
            _dbContext.SaveChanges();
        }
    }
}