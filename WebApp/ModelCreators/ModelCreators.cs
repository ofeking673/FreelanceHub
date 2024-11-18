using AlexProject.Models;
using System.Data;

namespace WebApplication2.ModelCreators
{
    public class UserCreator : IModelCreator<User>
    {
        public static User CreateModel(IDataReader src)
        {
            User user = new User()
            {
                Id = Convert.ToInt16(src["ID"]),
                PasswordHash = Convert.ToString(src["PASSWORD_HASH"]),
                Username = Convert.ToString(src["USERNAME"]),
                ProfilePictureLink = Convert.ToString(src["PROFILE_PICTURE"]),
                Email = Convert.ToString(src["EMAIL"])
            };

            return user;
        }
    }

    public class MessageCreator : IModelCreator<Message>
    {
        public static Message CreateModel(IDataReader src)
        {
            Message message = new Message()
            {
                Id = Convert.ToInt16(src["ID"]),
                chatId = Convert.ToString(src["CHAT_ID"]),
                Author = Convert.ToString(src["AUTHOR_ID"]),
                Content = Convert.ToString(src["CONTENT"]),
                timeStamp = Convert.ToDateTime(src["TIMESTAMP"]),
                Destination = Convert.ToString(src["DEST_USER_ID"])
            };
            return message;
        }
    }

    public class JobCreator : IModelCreator<Job>
    {
        public static Job CreateModel(IDataReader src)
        {
            Job job = new Job()
            {
                Id = Convert.ToInt16(src["ID"]),
                UserId = Convert.ToString(src["CREATOR_ID"]),
                price = Convert.ToString(src["PRICE"]),
                Description = Convert.ToString(src["DESCRIPTION"])
            };

            string themeText = Convert.ToString(src["THEME"]);
            if (Enum.TryParse(themeText, true, out Theme theme))
            {
                job.Theme = theme;
            }
            else
            {
                job.Theme = Theme.Teaching;
            }

            return job;
        }
    }

    public class chatCreator : IModelCreator<Chat>
    {
        public static Chat CreateModel(IDataReader src)
        {
            Chat chat = new Chat()
            {
                Id = Convert.ToInt16(src["ID"]),
                UserId = Convert.ToInt16(src["USER_ID"]),
                SellerId = Convert.ToInt16(src["SELLER_ID"]),
            };
            return chat;

        }
    }
    
    public class OfferCreator : IModelCreator<Offer>
    {
        public static Offer CreateModel(IDataReader src)
        {
            Offer offer = new Offer()
            {
                Id = Convert.ToInt16(src["ID"]),
                newPrice = Convert.ToInt16(src["NEW_PRICE"]),
                userId = Convert.ToInt16(src["AUTHOR_ID"]),
                jobId = Convert.ToInt16(src["JOB_ID"])
            };
            return offer;
        }
    }

    public class LogCreator : IModelCreator<Log> {
        public static Log CreateModel(IDataReader src)
        {
            Log log = new Log()
            {
                Id = Convert.ToInt16(src["ID"]),
                Time = Convert.ToDateTime(src["TIMESTAMP"]),
                path = Convert.ToString(src["LOG_PATH"])
            };
            return log;
        }
    }
}
