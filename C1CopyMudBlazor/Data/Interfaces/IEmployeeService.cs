using C1CopyMudBlazor.Data.Entities;
using C1CopyMudBlazor.Pages.Clients;

namespace C1CopyMudBlazor.Data.Interfaces;

public interface IWorkerService
{
    List<Worker> GetWorkers();
    IEnumerable<Worker> GetWorkersByClientID(int client);
    Worker GetWorkerById(int id);
    void SaveWorker(Worker customer);
    void DeleteWorker(int id);
}