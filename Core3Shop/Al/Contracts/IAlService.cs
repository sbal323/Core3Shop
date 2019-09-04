using Core3Shop.Bl.Contracts;
using Core3Shop.Models.ViewModels;

namespace Core3Shop.Al.Contracts
{
    public interface IAlService
    {
        IBlService BlService { get; }

        ServiceViewModel GetServiceModel(int? id);
    }
}