using System;
using System.Web.Mvc;
using System.Web.Http;
using ArenaDataAccess;
using System.Web.Http.Cors;
using ArendaServices.Models;

namespace ArendaServices.Controllers
{
        [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SubscriptionsController : ApiController
    {
        // Intial DB connection 
        ArenaDBEntities arenaDBEntities = new ArenaDBEntities();

        // POST: Subscribe a user to mailing list
        public ErrorReporting SubscribeUser([FromBody] Subscription subscription)
        {
            try
            {

                arenaDBEntities.Subscriptions.Add(subscription);
                arenaDBEntities.SaveChanges();

                return new ErrorReporting()  {  Error = false,   ErrorDetail = null,  Results = subscription.ID };
            } 
            catch(Exception e)
            {
                return new ErrorReporting(){  Error = true, ErrorDetail = e.Message + ", Should the problem persist, please contact support.", Results = null };

            }
        }
    }
}