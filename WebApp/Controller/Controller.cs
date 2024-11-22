using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebApplication2.ModelCreators;
using WebApplication2.DBActions;
using AlexProject.ViewModels;

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
            factory = new ModelFactory();
        }

        [HttpGet]
        public AdHub GetAds()
        {
            AdHub adHub = new AdHub();
            _DbContext.openConnection();
            adHub.adList = factory.jobCreator.GetAll();
            _DbContext.closeConnection();
            adHub.sortingTheme = Theme.None;
            adHub.Page = 1;
            return adHub;
        }

        [HttpGet("{id}")]
        public AdView GetAdView(string id)
        {
            AdView adView = new AdView();
            _DbContext.openConnection();
            adView.job = factory.jobCreator.GetById(id);
            _DbContext.closeConnection();
            return adView;
        }

    }
}
