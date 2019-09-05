﻿using Core3Shop.Al.Contracts;
using Core3Shop.Bl.Contracts;
using Core3Shop.Models;
using Core3Shop.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Shop.Al
{
    public class AlService : IAlService
    {
        public IBlService BlService { get; private set; }
        private readonly IBlDictionary<Frequency> _blFrequency;
        private readonly IBlDictionary<Category> _blCategory;
        public AlService(IBlService blService, IBlDictionary<Frequency> blFrequency, IBlDictionary<Category> blCategory)
        {
            this.BlService = blService;
            _blFrequency = blFrequency;
            _blCategory = blCategory;
        }
        private IEnumerable<SelectListItem> GetCategoriesForDropDown()
        {
            return _blCategory.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
        private IEnumerable<SelectListItem> GetFrequenciesForDropDown()
        {
            return _blFrequency.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
        public ServiceViewModel GetServiceModel(int? id)
        {
            var model = new ServiceViewModel()
            {
                CategoriesList = GetCategoriesForDropDown(),
                FrequencyList = GetFrequenciesForDropDown(),
                Service = new Service()
            };
            if (id != null)
            {
                model.Service = BlService.Get(id.Value);
            }
            return model;
        }

        public ServiceViewModel GetServiceModel(Service service)
        {
            return new ServiceViewModel()
            {
                CategoriesList = GetCategoriesForDropDown(),
                FrequencyList = GetFrequenciesForDropDown(),
                Service = service
            };
        }
        public void ProcessServiceFiles(string webRootPath, IFormFileCollection files, Service service)
        {
            if (service.Id != 0)
            {
                if (files.Count > 0 && service.ImageUrl != null)
                {
                    var oldImagePath = Path.Combine(webRootPath, service.ImageUrl.TrimStart('\\'));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }
            }
            if (files.Count > 0)
            {
                string fileName = $@"\images\services\{Guid.NewGuid().ToString()}{Path.GetExtension(files[0].FileName)}";
                using (var fileStream = new FileStream(Path.Combine(webRootPath, fileName.TrimStart('\\')), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                service.ImageUrl = fileName;
            }
        }
    }
}
