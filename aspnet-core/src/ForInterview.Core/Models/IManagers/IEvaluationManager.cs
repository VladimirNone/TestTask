using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForInterview.Models.IManagers
{
    public interface IEvaluationManager : IDomainService, IManager<Evaluation>
    {
        /// <summary>
        /// Try to find the evaluation in DB
        /// </summary>
        /// <param name="evaluation">The entity will be searched in DB</param>
        /// <returns>(entity was found, entity)</returns>
        Task<(bool, Evaluation)> TryFindEvaluation(Evaluation evaluation);
    }
}
