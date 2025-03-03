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

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        DBConnection _DbContext { get; set; }
        ModelFactory factory { get; set; }

        public GuestController()
        {
            this._DbContext = DBConnection.getInstance();
            factory = ModelFactory.getInstance();
        }

        [HttpGet("getAds")]
        public AdHub GetAds(int page=0, string theme = "None", 
            int amountPerPage=9)
        {
            try
            {
                if (page < 0 || amountPerPage < 0) return null;
                AdHub adHub = new AdHub();
                adHub.sortingTheme = (Theme)Enum.Parse(typeof(Theme), theme);


                _DbContext.openConnection();
                List<Job> jobList = factory.jobCreator.GetAll();
                List<Theme> themes = jobList.Select(x => x.Theme).Distinct().ToList();
                adHub.themes = themes;

                List<Job> jobs = factory.jobCreator.GetByTheme(adHub.sortingTheme);
                adHub.adList = jobs.GetRange(Math.Min(page * amountPerPage, Math.Max(jobs.Count - amountPerPage, 0)), Math.Min(amountPerPage, jobs.Count));

                adHub.Page = page+1;
                return adHub;
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

        [HttpGet("getCreator")]
        public AdHub GetCreator(int creatorId=-1, int page=0,
            int amtPerPage=5)
        {
            try
            {
                if(page < 0 || amtPerPage < 0) return null;
                AdHub adHub = new AdHub();
                _DbContext.openConnection();
                List<Job> jobs = factory.jobCreator.getByCreatorId(creatorId.ToString());
                adHub.adList = jobs.GetRange(Math.Min(page * amtPerPage, Math.Max(jobs.Count - amtPerPage, 0)), Math.Min(amtPerPage, jobs.Count));

                adHub.Page = page + 1;
                return adHub;
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

        [HttpPost("login")]
        public string Login([FromForm] string Username, [FromForm] string PasswordHash)
        {
            try
            {
                PasswordHash = factory.userCreator.hashPass(PasswordHash);
                _DbContext.openConnection();
                return factory.userCreator.getCookie(factory.userCreator.GetByUserAndPassword(Username, PasswordHash));
            } catch(Exception)
            {
                return null;
            }
            finally { _DbContext.closeConnection(); }
            
        }

        [HttpPost("signup")]
        public async Task<string> SignUp([FromForm] User user, [FromForm] IFormFile pfpStream) {
            try
            {
                user.PasswordHash = factory.userCreator.hashPass(user.PasswordHash);
                _DbContext.openConnection();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\UserProfiles");
                if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
                path = Path.Combine(path, $"{user.Username}_{pfpStream.FileName}");
                user.ProfilePictureLink = path;

                using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    await pfpStream.CopyToAsync(fileStream);
                };

                 //Write file to folder at username|filename.extension
                factory.userCreator.Create(user);
                user.Id = int.Parse(factory.userCreator.GetLastID());

                return factory.userCreator.getCookie(user);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { _DbContext.closeConnection(); }
        }

        [HttpPost("verifyCookie")]
        public bool VerifyCookie(string cookie)
        {

            return true;
        }
    }
}
