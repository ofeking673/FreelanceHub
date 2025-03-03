using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebApplication2.ModelCreators;
using WebApplication2.DBActions;
using AlexProject.ViewModels;
using AlexProject.Models;
using WebApplication2.Repositories;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        DBConnection _DbContext { get; set; }
        ModelFactory factory { get; set; }

        public UserController()
        {
            _DbContext = DBConnection.getInstance();
            factory = ModelFactory.getInstance();
        }

        [HttpPost("CreateJob")]
        public bool CreateJob(string userId, string price="0", string theme="None", string description="Job example", string name="Job")
        {
            try
            {
                _DbContext.openConnection();
                Job job = new Job()
                {
                    Description = description,
                    Theme = (Theme)Enum.Parse(typeof(Theme), theme),
                    Name = name,
                    price = price,
                    UserId = userId
                };

                return factory.jobCreator.Create(job);
            } catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _DbContext.closeConnection();
            }
        }

        [HttpGet("GetChat")]
        public OpenChat GetChat(string userId, string job_id)
        {
            try
            {
                _DbContext.openConnection();
                OpenChat chat = new OpenChat();
                chat.chat = factory.chatCreator.getByJobIdUserId(job_id, userId);
                chat.chat.jobId = int.Parse(job_id);
                chat.chat.Messages = factory.messageCreator.GetAllInChat(chat.chat.Id);
                return chat;
            }
            catch (Exception ex) {
                return null;
            }
            finally { _DbContext.closeConnection(); }
        }

        [HttpPost("CreateOffer")]
        public bool createOffer(int userId, int jobId, int newPrice) 
        {
            try
            {
                Offer offer = new Offer() { userId = userId, jobId = jobId, newPrice = newPrice };
                return factory.offerCreator.Create(offer);
            } catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("SendMessage")]
        public bool SendMessage(int userId, string message, int jobId, int chatId) 
        {
            try
            {
                _DbContext.openConnection();
                Message msg = new Message() { Author = userId.ToString(), chatId = chatId.ToString(), Content = message, timeStamp = DateTime.Now };
                //msg.Destination
                msg.Destination = factory.jobCreator.GetById(jobId.ToString()).UserId;

                return factory.messageCreator.Create(msg);
            } catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _DbContext.closeConnection();
            }
        }
    }
}
