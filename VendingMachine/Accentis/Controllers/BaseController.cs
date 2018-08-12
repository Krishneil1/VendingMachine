using Accentis.Business.UoW;
using Accentis.Database.Domain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Accentis.Controllers
{
    public class BaseController : Controller
    {      
        protected readonly IUnitOfWork UnitOfWork;

        public BaseController()
        {
            UnitOfWork = new UnitOfWork(new ApplicationDbContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));           
        }

        public BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;           
        }
    }
}
