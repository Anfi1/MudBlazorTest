using C1CopyMudBlazor.Data.Entities;
using C1CopyMudBlazor.Pages;

namespace C1CopyMudBlazor.Data.Interfaces;

public interface ILegalEntitiesService
{
    List<LegalEntities> GetLegalEntities();
    IEnumerable<LegalEntities> GetLegalEntitiesByClient(string legal);
    LegalEntities GetLegalEntitiesById(int id);
    LegalEntities GetLegalEntitiesByName(string name);
    void SaveLegalEntities(LegalEntities legal);
    void DeleteLegalEntities(int id);
}