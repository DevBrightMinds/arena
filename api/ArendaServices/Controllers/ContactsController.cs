using System;
using System.Web.Mvc;
using System.Web.Http;
using ArenaDataAccess;
using System.Web.Http.Cors;
using ArendaServices.Models;
using System.ComponentModel.DataAnnotations;

namespace ArendaServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactsController : ApiController
    {
        // Intial DB connection 
        ArenaDBEntities arenaDBEntities = new ArenaDBEntities();

        // POST: Subscribe a user to mailing list
        public ErrorReporting AddUserDetails([FromBody] Contact contact)
        {

            try
            {
               
                if (!string.IsNullOrEmpty(contact.Email) ||
                    !string.IsNullOrEmpty(contact.Content) ||
                    !string.IsNullOrEmpty(contact.Phone.ToString()) ||
                    !string.IsNullOrEmpty(contact.Names))
                {
                    return new ErrorReporting() { Error = true, ErrorDetail = "Please fill in all required fields.", Results = null };
                }
                else if (!IsValidEmail(contact.Email))
                {
                    return new ErrorReporting() { Error = true, ErrorDetail = "Please provide a valid email address.", Results = null };
                } else if()
                {
                    return new ErrorReporting() { Error = true, ErrorDetail = "The email address '" + contact.Email + "' already exists.", Results = null };
                }
                else
                {

                    arenaDBEntities.Contacts.Add(contact);
                    arenaDBEntities.SaveChanges();

                    return new ErrorReporting() { Error = false, ErrorDetail = null, Results = contact.ID };

                }              
            } 
            catch(Exception e)
            {
                return new ErrorReporting(){  Error = true, ErrorDetail = e.Message + ", Should the problem persist, please contact support.", Results = null };

            }
        }

        public bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}