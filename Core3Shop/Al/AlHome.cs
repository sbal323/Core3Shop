using Core3Shop.Al.Contracts;
using Core3Shop.Bl.Contracts;
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
        public AlHome(IBlService blService,  IBlDictionary<Category> blCategory)
        {
            _blService = blService;
            _blCategory = blCategory;
        }
        public HomeViewModel GetHomeModel()
        {
            var allServices = _blService.GetAll();
            return new HomeViewModel()
            {
                Services = allServices,
                Categories = _blCategory.GetAll().Where(x=> allServices.Any(y=> y.CategoryId == x.Id)).OrderBy(x=>x.Name).ToList()
            };
        }
    }
}
