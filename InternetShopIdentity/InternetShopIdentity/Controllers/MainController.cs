using InternetShopIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetShopIdentity.Controllers
{
    public class MainController:Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
    }
}