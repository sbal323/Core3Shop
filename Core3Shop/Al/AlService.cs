using Core3Shop.Al.Contracts;
using Core3Shop.Bl.Contracts;
using Core3Shop.Models;
using Core3Shop.Models.ViewModels;
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
    public class AlService : IAlService
    {
        public IBlService BlService { get; private set; }
        private readonly IBlDictionary<Frequency> _blFrequency;
        private readonly IBlDictionary<Category> _blCategory;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AlService(IBlService blService, IBlDictionary<Frequency> blFrequency, IBlDictionary<Category> blCategory, IWebHostEnvironment webHostEnvironment)
        {
            this.BlService = blService;
            _blFrequency = blFrequency;
            _blCategory = blCategory;
            _webHostEnvironment = webHostEnvironment;
        }
        public ServiceViewModel GetServiceModel(int? id)
        {
            var model = GetServiceModel(new Service()); 

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
        public void Upsert(IFormFileCollection files, Service service)
        {
            ProcessServiceFiles(_webHostEnvironment.WebRootPath, files, service);
            BlService.Save(service);
        }
        public void Delete(int id, string imagePath)
        {
            DeletePreviousImageFile(_webHostEnvironment.WebRootPath, imagePath);
            BlService.Delete(id);
        }
        private void ProcessServiceFiles(string webRootPath, IFormFileCollection files, Service service)
        {
            if (service.Id != 0 && files.Count > 0)
            {
                DeletePreviousImageFile(webRootPath, service.ImageUrl);
            }
            SaveNewImageFile(webRootPath, files, service);
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
        private void DeletePreviousImageFile(string webRootPath, string imagePath)
        {
            if (imagePath != null)
            {
                var oldImagePath = Path.Combine(webRootPath, imagePath.TrimStart('\\'));
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
            }
        }
        private void SaveNewImageFile(string webRootPath, IFormFileCollection files, Service service)
        {
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
