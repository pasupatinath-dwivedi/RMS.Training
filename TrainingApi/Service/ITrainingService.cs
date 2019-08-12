using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingApi.ViewModel;

namespace TrainingApi.Service
{
    public interface ITrainingService
    {
        /// <summary>
        /// Create new training
        /// </summary>
        /// <param name="trainingModel"></param>
        /// <returns></returns>
        Task CreateTrainingAsync(NewTrainingModel trainingModel);
    }
}
