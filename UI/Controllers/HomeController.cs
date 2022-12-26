using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Extensions;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedServiceService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceService providedServiceService, IAdvertisementService advertisementService)
        {
            _providedServiceService = providedServiceService;
            _advertisementService = advertisementService;   
        }

        public async Task<IActionResult> Index()
        {
            var list =await  _providedServiceService.GetAllAsync();
            return this.ResponseView(list);
        }
        public async Task<IActionResult> HumanResource()
        {
            var response = await _advertisementService.GetActiveAsync();
            return this.ResponseView(response);
        }
    }
}
