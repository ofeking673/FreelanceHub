using AlexProject.Models;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using WebApplication2.ModelCreators;

namespace WebApplication2.Repositories
{
    public class UserRespository : Repository, IRepository<User>
    {
        public UserRespository() : base(dbContext:DBActions.DBConnection.getInstance())
        { }


        public List<User> GetAll() {
            string sql = @"SELECT * FROM USER";
            var results = new List<User>();
            using(var reader = dbContext.Read(sql))
            {
                while (reader.Read())
                {
                    results.Add(UserCreator.CreateModel(reader));
                }
            }

            return results;

        }
        public User GetById(string id) {
            string sql = @$"SELECT * FROM USER WHERE ID=@ID";
            dbContext.addParameter("@ID", id);
            var res = dbContext.Read(sql);
            dbContext.clearParams();
            return UserCreator.CreateModel(res);
        }
        public string GetLastID() {
            string sql = @$"SELECT ID FROM USER ORDER BY ID ORD DESC LIMIT 1";
            return Convert.ToString(dbContext.Read(sql)[0]);
        }
        public bool Create(User user) {
            string sql = $@"INSERT INTO USER(USERNAME, PASSWORD_HASH, EMAIL, PROFILE_PICTURE) VALUES(@username,@password ,@email, @profile)";
            dbContext.addParameter("@username", user.Username);
            dbContext.addParameter("@password", user.PasswordHash);
            dbContext.addParameter("@email", user.Email);
            dbContext.addParameter("@profile", user.ProfilePictureLink);

            var save = dbContext.create(sql);
            dbContext.clearParams();
            return save == 1;
        }
        public bool Update(User model) {
            string sql = @"UPDATE USER SET USERNAME=@user, PASSWORD_HASH=@pass, EMAIL=@email, PROFILE_PICTURE=@pfp WHERE ID=@id";
            dbContext.addParameter("@user", model.Username);
            dbContext.addParameter("@pass", model.PasswordHash);
            dbContext.addParameter("@email", model.Email);
            dbContext.addParameter("@pfp", model.ProfilePictureLink);
            dbContext.addParameter("@id", Convert.ToString(model.Id));
            var res = dbContext.update(sql);
            dbContext.clearParams();
            return res == 1;
        }
        public bool Delete(string ID)
        {
            string sql = $@"DELETE FROM USER WHERE ID=@ID";
            dbContext.addParameter("@ID", ID);
            var save = dbContext.delete(sql);
            dbContext.clearParams();
            return save == 1;
        }
    }

    public class JobRepository : Repository, IRepository<Job>
    {
        public JobRepository() : base(dbContext: DBActions.DBConnection.getInstance())
        {}


        public List<Job> GetAll() {
            string sql = @"SELECT * FROM JOBS";
            var results = new List<Job>();
            using (var reader = dbContext.Read(sql))
            {
                while (reader.Read())
                {
                    results.Add(JobCreator.CreateModel(reader));
                }
            }

            return results;
        }
        public Job GetById(string id) {
            string sql = @"SELECT * FROM JOBS WHERE ID=@ID";
            dbContext.addParameter("@ID", id);
            var res = dbContext.Read(sql);
            dbContext.clearParams();
            return JobCreator.CreateModel(res);
        }
        public string GetLastID() {
            string sql = @"SELECT ID FROM JOBS ORDER BY ID ORD DESC LIMIT 1";
            var res = dbContext.Read(sql);
            return Convert.ToString(res[0]);
        }
        public bool Create(Job job) {
            string sql = @"INSERT INTO JOBS(CREATOR_ID, PRICE, THEME, DESCRIPTION) VALUES(@creator, @price, @theme, @desc)";
            dbContext.addParameter("@creator", job.UserId);
            dbContext.addParameter("@price", job.price);
            dbContext.addParameter("@theme", Convert.ToString(job.Theme));
            dbContext.addParameter("@desc", job.Description);
            var res = dbContext.create(sql);
            dbContext.clearParams();
            return res == 1;
        }
        public bool Update(Job model) {
            string sql = @"UPDATE JOB SET CREATOR_ID=@creator, PRICE=@price, THEME=@theme, DESCRIPTION=@desc WHERE ID=@id";
            dbContext.addParameter("@creator", model.UserId);
            dbContext.addParameter("@price", model.price);
            dbContext.addParameter("@theme", Convert.ToString(model.Theme));
            dbContext.addParameter("@desc", model.Description);
            dbContext.addParameter("@id", Convert.ToString(model.Id));
            var res = dbContext.update(sql);
            dbContext.clearParams();
            return res == 1;
        }
        public bool Delete(string ID) {
            string sql = $@"DELETE FROM JOBS WHERE ID=@ID";
            dbContext.addParameter("@ID", ID);
            var save = dbContext.delete(sql);
            dbContext.clearParams();
            return save == 1;
        }
    }

    public class chatRepository : Repository, IRepository<Chat>
    {
        public chatRepository() : base(dbContext: DBActions.DBConnection.getInstance())
        { }


        public List<Chat> GetAll() {
            string sql = @"SELECT * FROM CHAT";
            var results = new List<Chat>();
            using (var reader = dbContext.Read(sql))
            {
                while (reader.Read())
                {
                    results.Add(chatCreator.CreateModel(reader));
                }
            }

            return results;
        }
        public Chat GetById(string id) {
            string sql = @"SELECT * FROM CHAT WHERE ID=@ID";
            dbContext.addParameter("@ID", id);
            var save = dbContext.Read(sql);
            return chatCreator.CreateModel(save);
        }
        public string GetLastID() {
            string sql = @"SELECT ID FROM CHAT ORDER BY ID ORD DESC LIMIT 1";
            var res = dbContext.Read(sql);
            return Convert.ToString(res[0]);
        }
        public bool Create(Chat chat) {
            string sql = @"INSERT INTO CHAT(SELLER_ID, USER_ID, JOB_ID) VALUES(@creator, @user, @job)";
            dbContext.addParameter("@creator", Convert.ToString(chat.SellerId));
            dbContext.addParameter("@price", Convert.ToString(chat.UserId));
            dbContext.addParameter("@job", Convert.ToString(chat.jobId));

            var res = dbContext.create(sql);
            dbContext.clearParams();
            return res == 1;
        }
        public bool Update(Chat model)
        {
            string sql = @"UPDATE CHAT SET SELLER_ID=@seller, USER_ID=@user, JOB_ID=@job WHERE ID=@id";
            dbContext.addParameter("@seller", Convert.ToString(model.SellerId));
            dbContext.addParameter("@user", Convert.ToString(model.UserId));
            dbContext.addParameter("@job", Convert.ToString(model.jobId));
            dbContext.addParameter("@id", Convert.ToString(model.Id));
            var res = dbContext.update(sql);
            dbContext.clearParams();
            return res == 1;
        }

        public bool Delete(string ID) {
            string sql = @"DELETE FROM CHAT WHERE ID=@ID";
            dbContext.addParameter("@ID", ID);
            var res = dbContext.delete(sql);
            dbContext.clearParams();
            return res == 1;
        }
    }

    public class messageRepository : Repository, IRepository<Message>
    {
        public messageRepository() : base(dbContext: DBActions.DBConnection.getInstance())
        { }


        public List<Message> GetAll() {
            string sql = @"SELECT * FROM MESSAGE";
            var results = new List<Message>();
            using (var reader = dbContext.Read(sql))
            {
                while (reader.Read())
                {
                    results.Add(MessageCreator.CreateModel(reader));
                }
            }
            return results;
        }
        public Message GetById(string id) {
            string sql = @"SELECT * FROM MESSAGE WHERE ID=@ID";
            dbContext.addParameter("@ID", id);
            var res = dbContext.Read(sql);
            dbContext.clearParams();
            return MessageCreator.CreateModel(res);
        }
        public string GetLastID() {
            string sql = @"SELECT ID FROM MESSAGE ORDER BY ID ORD DESC LIMIT 1";
            var res = dbContext.Read(sql);
            return Convert.ToString(res[0]);
        }
        public bool Create(Message model)
        {
            string sql = @"INSERT INTO MESSAGE(AUTHOR_ID, DEST_USER_ID, CHAT_ID, CONTENT, TIMESTAMP) VALUES(@author, @dest, @chat, @content, @time)";
            dbContext.addParameter("@author", model.Author);
            dbContext.addParameter("@dest", model.Destination);
            dbContext.addParameter("@chat", model.chatId);
            dbContext.addParameter("@content", model.Content);
            dbContext.addParameter("@time", Convert.ToString(model.timeStamp));
            dbContext.addParameter("@id", Convert.ToString(model.Id));

            var res = dbContext.create(sql);
            dbContext.clearParams();
            return res == 1;
        }

        public bool Update(Message model) {
            string sql = @"UPDATE MESSAGE SET AUTHOR_ID=@author, DEST_USER_ID=@dest, CHAT_ID=@chat, CONTENT=@content, TIMESTAMP=@time WHERE ID=@id";
            dbContext.addParameter("@author", model.Author);
            dbContext.addParameter("@dest", model.Destination);
            dbContext.addParameter("@chat", model.chatId);
            dbContext.addParameter("@content", model.Content);
            dbContext.addParameter("@time", Convert.ToString(model.timeStamp));
            dbContext.addParameter("@id", Convert.ToString(model.Id));
            var res = dbContext.update(sql);
            dbContext.clearParams();
            return res == 1;
        }
        public bool Delete(string ID) {
            string sql = @"DELETE FROM MESSAGE WHERE ID=@ID";
            dbContext.addParameter("@ID", ID);
            var res = dbContext.delete(sql);
            dbContext.clearParams();
            return res == 1;
        }
    }

    public class LogRepository : Repository, IRepository<Log>
    {
        public LogRepository() : base(dbContext: DBActions.DBConnection.getInstance())
        { }


        public List<Log> GetAll() {
            string sql = @"SELECT * FROM LOGS";
            var results = new List<Log>();
            using (var reader = dbContext.Read(sql))
            {
                while (reader.Read())
                {
                    results.Add(LogCreator.CreateModel(reader));
                }
            }
            return results;
        }
        public Log GetById(string id) {
            string sql = @"SELECT * FROM LOGS WHERE ID=@ID";
            dbContext.addParameter("@ID", id);
            var res = dbContext.Read(sql);
            dbContext.clearParams();
            return LogCreator.CreateModel(res);
        }
        public string GetLastID() {
            string sql = @"SELECT ID FROM LOGS ORDER BY ID ORD DESC LIMIT 1";
            var res = dbContext.Read(sql);
            return Convert.ToString(res[0]);
        }
        public bool Create(Log model) {
            string sql = @"INSERT INTO LOGS(TIMESTAMP, LOG_PATH) VALUES(@time, @path)";
            dbContext.addParameter("@time", Convert.ToString(model.Time));
            dbContext.addParameter("@path", model.path);
            var res = dbContext.create(sql);
            dbContext.clearParams();
            return res == 1;
        }
        public bool Update(Log model) {
            string sql = @"UPDATE LOGS SET TIMESTAMP=@time, LOG_PATH=@path WHERE ID=@id";
            dbContext.addParameter("@time", Convert.ToString(model.Time));
            dbContext.addParameter("@path", model.path);
            var res = dbContext.update(sql);
            dbContext.clearParams();
            return res == 1;
        }
        public bool Delete(string ID) {
            string sql = @"DELETE FROM LOGS WHERE ID=@id";
            dbContext.addParameter("@id", ID);
            var res = dbContext.delete(sql);
            dbContext.clearParams();
            return res == 1;
        }
    }

    public class OfferRepository : Repository, IRepository<Offer>
    {
        public OfferRepository() : base(dbContext: DBActions.DBConnection.getInstance())
        { }


        public List<Offer> GetAll() {
            string sql = @"SELECT * FROM LOGS";
            var results = new List<Offer>();
            using (var reader = dbContext.Read(sql))
            {
                while (reader.Read())
                {
                    results.Add(OfferCreator.CreateModel(reader));
                }
            }
            return results;
        }
        public Offer GetById(string id) {
            string sql = @"SELECT * FROM OFFER WHERE ID=@ID";
            dbContext.addParameter("@ID", id);
            var res = dbContext.Read(sql);
            dbContext.clearParams();
            return OfferCreator.CreateModel(res);
        }
        public string GetLastID()
        {
            string sql = @"SELECT ID FROM OFFER ORDER BY ID ORD DESC LIMIT 1";
            var res = dbContext.Read(sql);
            return Convert.ToString(res[0]);
        }
        public bool Create(Offer model) {
            string sql = @"INSERT INTO OFFER(AUTHOR_ID, SELLER_ID, JOB_ID, NEW_PRICE, NEW_CHAT_ID) VALUES(@author, @seller, @job, @price, @chatId)";
            dbContext.addParameter("@author", Convert.ToString(model.userId));
            dbContext.addParameter("@seller", Convert.ToString(model.sellerId));
            dbContext.addParameter("@job", Convert.ToString(model.jobId));
            dbContext.addParameter("@price", Convert.ToString(model.newPrice));
            dbContext.addParameter("@chatId", Convert.ToString(model.chatId));
            var res = dbContext.create(sql);
            dbContext.clearParams();
            return res == 1;

        }
        public bool Update(Offer model) {
            string sql = @"UPDATE OFFER SET AUTHOR_ID= @author, SELLER_ID=@seller, JOB_ID=@job, NEW_PRICE=@price, NEW_CHAT_ID=@chat WHERE ID=@id";
            dbContext.addParameter("@author", Convert.ToString(model.userId));
            dbContext.addParameter("@seller", Convert.ToString(model.sellerId));
            dbContext.addParameter("@job", Convert.ToString(model.jobId));
            dbContext.addParameter("@price", Convert.ToString(model.newPrice));
            dbContext.addParameter("@chat", Convert.ToString(model.chatId));
            dbContext.addParameter("@id", Convert.ToString(model.Id));
            var res = dbContext.update(sql);
            dbContext.clearParams();
            return res == 1;
        }
        public bool Delete(string ID) {
            string sql = @"DELETE FROM OFFER WHERE ID=@id";
            dbContext.addParameter("@id", ID);
            var res = dbContext.delete(sql);
            dbContext.clearParams();
            return res == 1;
        }
    }
}
