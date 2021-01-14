using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Stave.Models;

namespace Stave.Utility
{
    public class AuthenticationUtility
    {
        public static bool CheckUserToken(string token, StaveContext db)
        {
            return db.Sessions.SingleOrDefault(x => x.Token == token && x.IsValid) is null ? false : true;
        }

        public static bool CheckUserAdminFromToken(string token, StaveContext db)
        {
            return db.Sessions.Include(x => x.UserDetails).SingleOrDefault(x => x.Token == token && x.IsValid && x.UserDetails.IsAdmin) is null ? false : true;
        }
    }
}