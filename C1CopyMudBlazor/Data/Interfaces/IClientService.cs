using C1CopyMudBlazor.Data.Entities;

namespace C1CopyMudBlazor.Data.Interfaces;

public interface IClientService
{
    List<Client> GetClients();
    Client GetClientById(int id);
    void SaveClient(Client Client);
    void DeleteClient(int id);
}