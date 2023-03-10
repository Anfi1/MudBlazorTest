using C1CopyMudBlazor.Data.Entities;

namespace C1CopyMudBlazor.Data.Interfaces;

public interface IWorkPlaceService
{
    List<WorkPlace> GetWorkPlaces();
    IEnumerable<WorkPlace> GetWorkPlacesByOfficeID(int id);
    IEnumerable<WorkPlace> GetWorkPlacesByClientID(int id);
    WorkPlace GetWorkPlaceById(int id);
    void SaveWorkPlace(WorkPlace customer);
    void DeleteWorkPlace(int id);
}