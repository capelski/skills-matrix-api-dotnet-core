using SkillsMatrixApi.Models;

namespace SkillsMatrixApi.Commons
{
    public class BaseService
    {
        protected readonly SkillsMatrixContext db;

        public BaseService(SkillsMatrixContext context)
        {
            db = context;
        }
    }
}
