using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Stave.Models;

namespace Stave.Endpoints.Authentication
{
    public class VerifyEndpoint
    {
        public class VerifyEndpointRequest
        {
            public string Token {get; set;}
        }

        public class VerifyEndpointResponse
        {
            public string Message {get; set;}
            public bool Status {get; set;}
        }

        public static VerifyEndpointResponse VerifyEndpointAction(VerifyEndpointRequest req, StaveContext db)
        {
            var res = new VerifyEndpointResponse();

            var findToken = db.Sessions
            .SingleOrDefault(x => x.Token == req.Token && x.IsValid);

            if (findToken == null)
            {
                res.Status = false;
                res.Message = "Token not valid";
            }
            else
            {
                res.Status = true;
                res.Message = "Token is valid";
            }

            return res;
        }
    }
}