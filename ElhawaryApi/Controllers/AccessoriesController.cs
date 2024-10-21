using Microsoft.AspNetCore.Mvc;

namespace ElhawaryApi.Controllers
{
    public class AccessoriesController(IAccessoriesService accessoriesService) : Controller
    {
        private readonly IAccessoriesService _accessoriesService = accessoriesService;

        [HttpGet]
        [Route("/api/accessory")]
        public ActionResult<List<AccessoryDTO>> GetAccessories()
        {
            var list = _accessoriesService.GetAccessories();

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }
    }
}
