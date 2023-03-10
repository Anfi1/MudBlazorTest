using C1CopyMudBlazor.Data.Entities;
using C1CopyMudBlazor.Data.Interfaces;

namespace C1CopyMudBlazor.Data.Services;

public class TechService : ITechService
{
    private readonly ApplicationContext _dbContext;
    public TechService(ApplicationContext context)
    {
        _dbContext = context;
    }
    public void DeleteTech(int id)
    {
        
        var tech = _dbContext.Teches.FirstOrDefault(x => x.ID == id);
        if(tech!=null)
        {
            _dbContext.Teches.Remove(tech);
            _dbContext.SaveChanges();
        }
    }
    public Tech GetTechById(int id)
    {
        var tech = _dbContext.Teches.SingleOrDefault(x => x.ID == id);
        return tech;
    }
    public List<Tech> GetTechByClientID(int id)
    {
        var tech = _dbContext.Teches.Where(x => x.ClientID == id).ToList();
        return tech;
    }
    public List<Tech> GetTechByWorkplace(int id)
    {
        var tech = _dbContext.Teches.Where(x => x.WorkPlaceID == id).ToList();
        return tech;
    }
    public List<Tech> GetTechByOffice(int id)
    {
        var tech = _dbContext.Teches.Where(x => x.OfficeID == id).ToList();
        return tech;
    }
    public List<Tech> GetTechByWorkerID(int id)
    {
        var tech = _dbContext.Teches.Where(x => x.WorkerID == id).ToList();
        return tech;
    }
    public List<Tech> GetTeches()
    {
        return _dbContext.Teches.ToList();
    }
    public void SaveTech(Tech tech)
    {
        if (tech.ID == 0) _dbContext.Teches.Add(tech);
        else _dbContext.Teches.Update(tech);
        _dbContext.SaveChanges();
    }
}