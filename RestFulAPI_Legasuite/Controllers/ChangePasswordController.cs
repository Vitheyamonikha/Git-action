using Microsoft.AspNetCore.Mvc;

namespace RestFulAPI_Legasuite.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ChangePasswordController : Controller
    {
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
