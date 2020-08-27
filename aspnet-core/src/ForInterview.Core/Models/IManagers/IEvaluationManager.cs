using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForInterview.Models.IManagers
{
    public interface IEvaluationManager : IDomainService, IManager<Evaluation>
    {
        Task<(bool, Evaluation)> TryFindEvaluation(Evaluation evaluation);
    }
}
