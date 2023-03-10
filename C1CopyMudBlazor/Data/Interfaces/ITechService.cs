using C1CopyMudBlazor.Data.Entities;

namespace C1CopyMudBlazor.Data.Interfaces;

public interface ITechService
{
    List<Tech> GetTeches();
    Tech GetTechById(int id);
    List<Tech> GetTechByWorkplace(int id);
    List<Tech> GetTechByClientID(int id);
    List<Tech> GetTechByOffice(int id);
    List<Tech> GetTechByWorkerID(int id);
    void SaveTech(Tech customer);
    void DeleteTech(int id);
}