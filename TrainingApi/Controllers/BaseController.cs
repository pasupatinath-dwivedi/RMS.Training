using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainingApi.Common;

namespace TaskService.Controllers
{
    public class BaseController : ControllerBase
    {
 
        [NonAction]
        public IActionResult Success(string message)
        {
            return new OkObjectResult(new
            { Message = message, Status = Microsoft.AspNetCore.Http.StatusCodes.Status200OK });
        }


        [NonAction]
        public IActionResult Error(string message)
        {

            return new BadRequestObjectResult(new Response<dynamic>
            { Message = message, Status = Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError });

        }

    }

}
