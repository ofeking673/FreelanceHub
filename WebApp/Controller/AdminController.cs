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
    public class AdminController
    {
        DBConnection _DbContext { get; set; }
        ModelFactory factory { get; set; }
        
        public AdminController()
        {
            _DbContext = DBConnection.getInstance();
            factory = ModelFactory.getInstance();
        }

        [HttpGet]
        public Log GetLatestLog()
        {
            try
            {
                _DbContext.openConnection();
                return factory.logCreator.GetById(factory.logCreator.GetLastID());
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                _DbContext.closeConnection();
            }
        }

        [HttpPost("Recovery")]
        public bool ChangePassword(string oldPassword, string newPassword, string id)
        {
            try
            {
                _DbContext.openConnection();
                return factory.userCreator.changePassword(id, oldPassword, newPassword);
            }
            catch
            {
                return false;
            }
            finally { _DbContext.closeConnection(); }
        }
    }
}
