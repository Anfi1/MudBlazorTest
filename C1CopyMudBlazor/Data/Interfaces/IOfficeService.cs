using C1CopyMudBlazor.Data.Entities;

namespace C1CopyMudBlazor.Data.Interfaces;

public interface IOfficeService
{
    List<Office> GetOffices();
    Office GetOfficeById(int id);
    void SaveOffice(Office customer);
    void DeleteOffice(int id);
}