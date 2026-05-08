using Campaign_Demo_Wahtsapp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Campaign_Demo_Wahtsapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateCampaign(CreateCampaignRequest request)
        {

            return Ok();
        }
    }
}
