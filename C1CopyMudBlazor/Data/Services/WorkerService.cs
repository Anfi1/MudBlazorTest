using C1CopyMudBlazor.Data.Entities;
using C1CopyMudBlazor.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace C1CopyMudBlazor.Data.Services;

public class WorkerService : IWorkerService
{
    private readonly ApplicationContext _dbContext;
    public WorkerService(ApplicationContext context)
    {
        _dbContext = context;
    }
    public void DeleteWorker(int id)
    {
        
        var worker = _dbContext.Workers.FirstOrDefault(x => x.ID == id);
        if(worker!=null)
        {
            _dbContext.Workers.Remove(worker);
            _dbContext.SaveChanges();
        }
    }

    public Worker GetWorkerById(int id)
    {
        var worker = _dbContext.Workers.SingleOrDefault(x => x.ID == id);
        return worker;
    }
    public List<Worker> GetWorkers()
    {
        return _dbContext.Workers.Include(b=>b.Office).Include(b=>b.Office.Client).ToList();
    }
    public IEnumerable<Worker> GetWorkersByClient(string name)
    {
        return _dbContext.Workers.Include(b=>b.Office).Include(b=>b.Office.Client).Where(b=>b.Office.Client.Name == name).ToList();
    }
    public void SaveWorker(Worker office)
    {
        if (office.ID == 0) _dbContext.Workers.Add(office);
        else _dbContext.Workers.Update(office);
        _dbContext.SaveChanges();
    }
}