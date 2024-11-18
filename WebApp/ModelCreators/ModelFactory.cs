using WebApplication2.Repositories;

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
        public ModelFactory() { }

    }
}
