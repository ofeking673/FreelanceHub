using WebApplication2.Repositories;
using WebApplication2.DBActions;
using System.Security.Cryptography;

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

        public static ModelFactory? instance = null;

        public static ModelFactory getInstance()
        {
            if (instance == null)
            {
                instance = new ModelFactory();
            }
            return instance;
        }
        private ModelFactory() {
            dbConnection = DBConnection.getInstance();
            chatCreator = new chatRepository();
            logCreator = new LogRepository();
            userCreator = new UserRespository();
            messageCreator = new messageRepository();
            jobCreator = new JobRepository();
            offerCreator = new OfferRepository();

        }

        public static string GetStringSha256Hash(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }


    }
}
