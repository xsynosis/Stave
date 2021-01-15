using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Stave.Models;
using Stave.Utility;

namespace Stave.Endpoints.UserManagement
{
    public class DeleteUserEndpoint
    {
        public class DeleteUserEndpointRequest
        {
            public string Token {get; set;}
            public int UserId {get; set;}
        }

        public class DeleteUserEndpointResponse
        {
            public string Message {get; set;}
            public bool Status {get; set;}
        }

        public static DeleteUserEndpointResponse DeleteUserEndpointAction(DeleteUserEndpointRequest req, StaveContext db)
        {
            var res = new DeleteUserEndpointResponse();

            if (!AuthenticationUtility.CheckUserToken(req.Token, db) || !AuthenticationUtility.CheckUserAdminFromToken(req.Token, db))
            {
                res.Status = false;
                res.Message = "Operation failed. Either you're not logged in or you don't have permission to perform that action";
            }
            else
            {
                var findTargetUser = db.Users
                .SingleOrDefault(x => x.UserId == req.UserId);

                if (findTargetUser == null)
                {
                    res.Status = false;
                    res.Message = "Operation failed. Target user does not exist";
                }
                else
                {
                    db.Users.Remove(findTargetUser);
                    db.SaveChanges();

                    res.Status = true;
                    res.Message = "Operation success";
                }
            }

            return res;
        }
    }
}