using Abp.Domain.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ForInterview.Models.IManagers;

namespace ForInterview.Models.Managers
{
    class EvaluationManager : Manager<Evaluation>, IEvaluationManager
    {
        public EvaluationManager(IRepository<Evaluation> repository)
            : base(repository)
        {
        }

        public async Task<(bool,Evaluation)> TryFindEvaluation(Evaluation evaluation)
        {
            var res = await repository.FirstOrDefaultAsync(x => x.PostId == evaluation.PostId && x.EvaluatorId == evaluation.EvaluatorId);
            return (res != null, res);
        }
    }
}
