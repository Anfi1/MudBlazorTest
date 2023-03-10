using C1CopyMudBlazor.Data.Entities;
using C1CopyMudBlazor.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace C1CopyMudBlazor.Data.Services;

public class WorkPlaceService : IWorkPlaceService
{
    private readonly ApplicationContext _dbContext;
    public WorkPlaceService(ApplicationContext context)
    {
        _dbContext = context;
    }

    public void DeleteWorkPlace(int id)
    {
        
        var workPlace = _dbContext.WorkPlaces.FirstOrDefault(x => x.ID == id);
        if(workPlace!=null)
        {
            _dbContext.WorkPlaces.Remove(workPlace);
            _dbContext.SaveChanges();
        }
    }

    public IEnumerable<WorkPlace> GetWorkPlacesByClientID(int id)
    {
        return _dbContext.WorkPlaces.Include(o=>o.Office).Where(x=>x.Office.ClientID ==id).ToList();
    }
    public WorkPlace GetWorkPlaceById(int id)
    {
        var workPlace = _dbContext.WorkPlaces.SingleOrDefault(x => x.ID == id);
        return workPlace;
    }
    public List<WorkPlace> GetWorkPlaces()
    {
        return _dbContext.WorkPlaces.Include(b=>b.Office).ToList();
    }
    public IEnumerable<WorkPlace> GetWorkPlacesByOfficeID(int id)
    {
        return _dbContext.WorkPlaces.Include(t=>t.teches).Where(b=>b.Office.ID == id).ToList();
    }
    
    public void SaveWorkPlace(WorkPlace workPlace)
    {
        if (workPlace.ID == 0) _dbContext.WorkPlaces.Add(workPlace);
        else _dbContext.WorkPlaces.Update(workPlace);
        _dbContext.SaveChanges();
    }
}