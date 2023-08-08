using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Dynamic;
using System.Security.Policy;
using Microsoft.AspNetCore.Cors;
using RestFulAPI_Legasuite.Models;
using System.Web.Http.Description;
using RestFulAPI_Legasuite.Common.Configurations;
using RestFulAPI_Legasuite.Common.Model;
using RestFulAPI_Legasuite.Common.Interface;

namespace RestFulAPI_Legasuite.Controllers
{    

    [ApiController]
    [Route("/api/[controller]")]
    public class UpdateAppSettingController : Controller
    {

        private readonly IUpdatePassword _updatePassword;

        public UpdateAppSettingController(IUpdatePassword updatePassword)
        {
            _updatePassword = updatePassword;
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("update")]
        [Consumes("application/json")]

        public void Update([FromBody] UpdatePasswordInputs updatePasswordInputs)
        {

             _updatePassword.UpdateIisEnvironmentalVariable(updatePasswordInputs);
        }        
    }
}
