using Core3Shop.Bl.Contracts;
using Core3Shop.Models;
using Core3Shop.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Core3Shop.Al.Contracts
{
    public interface IAlService
    {
        IBlService BlService { get; }

        ServiceViewModel GetServiceModel(int? id);
        ServiceViewModel GetServiceModel(Service service);
        void ProcessServiceFiles(string webRootPath, IFormFileCollection files, Service service);
    }
}