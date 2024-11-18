using System.Data.Entity;
using WebApplication2.DBActions;
using WebApplication2.ModelCreators;

namespace WebApplication2.Repositories
{
    public class Repository
    {
        protected DBConnection dbContext;
        protected ModelFactory modelFactory;
        public Repository(DBConnection dbContext)
        {
            this.dbContext = dbContext;
            this.modelFactory = modelFactory;
        }

    }
}
