using Core3Shop.Al.Contracts;
using Core3Shop.Bl.Contracts;
using Core3Shop.Managers;
using Core3Shop.Models;
using Core3Shop.Models.ViewModels;
using Core3Shop.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Shop.Al
{
    public class AlHome : IAlHome
    {
        private readonly IBlService _blService;
        private readonly IBlDictionary<Category> _blCategory;
        private IHttpContextAccessor _httpContextAccessor;
        public AlHome(IBlService blService,  IBlDictionary<Category> blCategory, IHttpContextAccessor httpContextAccessor)
        {
            _blService = blService;
            _blCategory = blCategory;
            _httpContextAccessor = httpContextAccessor;
        }
        public HomeViewModel GetHomeModel()
        {
            var allServices = _blService.GetAll();
            return new HomeViewModel()
            {
                Services = allServices.Select(x=> x.ServiceModel).ToList(),
                Categories = _blCategory.GetAll().Where(x=> allServices.Any(y=> y.ServiceModel.CategoryId == x.Id)).OrderBy(x=>x.Name).ToList()
            };
        }
        public ServiceDetailsViewModel GetServiceDetailsModel(int id)
        {
            var service = _blService.Get(id);
            var session = new SessionManager(_httpContextAccessor.HttpContext);
            var cart = session.GetCart();
            return new ServiceDetailsViewModel()
            {
                Service = service,
                IsInCart = cart.Contains(service.ServiceModel.Id)
            };
        }
    }
}
