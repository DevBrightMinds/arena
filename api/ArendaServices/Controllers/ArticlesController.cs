using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using ArenaDataAccess;
using ArendaServices.Models;

namespace ArendaServices.Controllers
{
    public class ArticlesController : ApiController
    {

        ArenaDBEntities arenaDBEntities = new ArenaDBEntities();
        // GET: Articles
    
        public ErrorReporting Get()
        {

            try
            {

                return new ErrorReporting() { Error = false, ErrorDetail = null, Results = arenaDBEntities.Articles.ToList() };
            } 
            catch(Exception e)
            {
                return new ErrorReporting() { Error = true, ErrorDetail = e.Message + " Should the problem persist, please contact support.", Results = null };
            }
        }
    }
}