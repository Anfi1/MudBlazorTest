using C1CopyMudBlazor.Data.Entities;

namespace C1CopyMudBlazor.Data.Interfaces;

public interface IOfficeService
{
    List<Office> GetOffices();
    Office GetOfficeById(int id);
    Office GetOfficeByName(string name);
    Office GetOfficeByClientName(string client, string office);
    void SaveOffice(Office customer);
    void DeleteOffice(int id);
}