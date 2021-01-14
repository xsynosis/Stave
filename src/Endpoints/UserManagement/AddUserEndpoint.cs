using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Stave.Models;
using Stave.Utility;

namespace Stave.Endpoints.UserManagement
{
    public class AddUserEndpoint
    {
        public class AddUserEndpointRequest
        {
            public string Token {get; set;}

            public string Firstname {get; set;}
            public string Lastname {get; set;}
            public string Username {get; set;}
            public string Email {get; set;}
            public string Password {get; set;}
            public bool IsAdmin {get; set;}
        }

        public class AddUserEndpointResponse
        {
            public string Message {get; set;}
            public bool Status {get; set;}
        }

        public static AddUserEndpointResponse AddUserEndpointAction(AddUserEndpointRequest req, StaveContext db)
        {
            var res = new AddUserEndpointResponse();

            if (AuthenticationUtility.CheckUserAdminFromToken(req.Token, db) || AuthenticationUtility.CheckUserAdminFromToken(req.Token, db))
            {
                res.Message = "Failed to add user; Either requester is not admin or the token used is invalid";
                res.Status = false;
            }
            else if (db.Users.Where(x => x.Username == req.Username || x.Email == req.Email).ToList().Count != 0)
            {
                res.Message = "Failed to add user; The username or email address is already in use";
                res.Status = false;
            }
            else
            {
                db.Users.Add(new User(){
                    CanLogin = true,
                    Email = req.Email,
                    Firstname = req.Firstname,
                    IsAdmin = req.IsAdmin,
                    Lastname = req.Lastname,
                    Password = req.Password,
                    Username = req.Username
                });

                db.SaveChanges();

                res.Status = true;
                res.Message = "Successfully added user " + req.Username;
            }


            return res;
        }
    }
}