using ELearning_Core.Model;
using ELearning_Core.Shared;

namespace ELearning.API
{
    public interface IMasterServiceAPI
    {
        public Task<Result<List<Subject>>> GetSubjectsList();
    }
}

