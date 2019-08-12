using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskService.Controllers;
using TrainingApi.Service;
using TrainingApi.ViewModel;

namespace TrainingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : BaseController
    {

        public readonly ITrainingService _trainingService;
        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        /// <summary>
        /// Creates new training
        /// </summary>
        /// <param name="newTrainingModel"></param>
        /// <returns></returns>
        [HttpPost("/new")]
        public async Task<IActionResult> NewTraining(NewTrainingModel newTrainingModel)
        {
            if (!ModelState.IsValid)
            {
                return Error(ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ToString());
            }
            try
            {
                int totalTrainingDays = newTrainingModel.EndDate.Subtract(newTrainingModel.StartDate).Days;
                totalTrainingDays = totalTrainingDays > 0 ? totalTrainingDays : 1;
                await _trainingService.CreateTrainingAsync(newTrainingModel);

                return Success($"Training saved successfully, total training days : {totalTrainingDays}");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "training 1", "training 2" };
        }
    }
}
