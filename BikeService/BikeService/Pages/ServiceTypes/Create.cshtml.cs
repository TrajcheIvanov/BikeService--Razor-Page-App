using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeService.Mappings;
using BikeService.Services.interfaces;
using BikeService.Utility;
using BikeService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeService.Pages.ServiceTypes
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class CreateModel : PageModel
    {

        private readonly IServiceTypesService _serviceTypeService;

        public CreateModel(IServiceTypesService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        [BindProperty]
        public ServiceTypeViewModel ServiceType { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _serviceTypeService.Create(ServiceType.ToDomainModel());
                return RedirectToPage("./Index", new { successMessage = $"Successfully Created service type with name: {ServiceType.Name}" });
            }

            return Page();
        }
    }
}
