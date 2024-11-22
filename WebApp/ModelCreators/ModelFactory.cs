using WebApplication2.Repositories;
using WebApplication2.DBActions;

namespace WebApplication2.ModelCreators
{
    public class ModelFactory
    {
        public chatRepository chatCreator;
        public UserRespository userCreator;
        public messageRepository messageCreator;
        public JobRepository jobCreator;
        public LogRepository logCreator;
        public OfferRepository offerCreator;
        public DBConnection dbConnection;
        public ModelFactory() { dbConnection = DBConnection.getInstance(); }

    }
}
