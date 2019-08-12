using Moq;
using System;
using TrainingApi.Controllers;
using TrainingApi.Service;
using Xunit;

namespace TrainingApi.Tests
{
    public class TrainingControllerTests
    {

        [Fact]
        public async void NewTrainingShouldReturnOkResult()
        {

            //Arrange  
            var mockTrainingService = new Mock<ITrainingService>();
            var trainingModel = new ViewModel.NewTrainingModel()
            {
                EndDate = DateTime.Now,
                StartDate = DateTime.Now.AddDays(-1),
                Name = "Test Training"
            };

            mockTrainingService.Setup(service => service.CreateTrainingAsync(trainingModel));

            var controller = new TrainingController(mockTrainingService.Object);
           
            //Act  
            var data = await controller.NewTraining(trainingModel);

            //Assert  
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(data);
        }

        [Fact]
        public async void NewTrainingShouldReturnBadRequestResultStatusCode500()
        {

            //Arrange  
            var mockTrainingService = new Mock<ITrainingService>();
            mockTrainingService.Setup(service => service.CreateTrainingAsync(new ViewModel.NewTrainingModel()));

            var controller = new TrainingController(mockTrainingService.Object);
            controller.ModelState.AddModelError("test","error");
           
            //Act  
            var data = await controller.NewTraining(new ViewModel.NewTrainingModel());

            //Assert  
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(data);
        }
    }
}
