using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingApi.Database;
using TrainingApi.ViewModel;
using TrainingApi.DbModel;

namespace TrainingApi.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly TrainingDbContext _dbContext;
        public TrainingService(TrainingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTrainingAsync(NewTrainingModel trainingModel)
        {

            _dbContext.Add<Training>(new Training()
            {
                EndDate = trainingModel.EndDate,
                StartDate = trainingModel.StartDate,
                Name = trainingModel.Name,
                CreatedDate = DateTime.Now
            });

            await _dbContext.SaveChangesAsync();
        }
    }
}
