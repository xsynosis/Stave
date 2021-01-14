using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stave.Endpoints.Authentication;

namespace Stave.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        StaveContext _context;

        public AuthenticationController (StaveContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public LoginEndpoint.LoginEndpointResponse Login(LoginEndpoint.LoginEndpointRequest req)
        {
            return LoginEndpoint.LoginEndpointAction(req, _context);
        }

        [HttpPost]
        [Route("logout")]
        public LogoutEndpoint.LogoutEndpointResponse Logout(LogoutEndpoint.LogoutEndpointRequest req)
        {
            return LogoutEndpoint.LogoutEndpointAction(req, _context);
        }

        [HttpPost]
        [Route("verify")]
        public VerifyEndpoint.VerifyEndpointResponse Verify(VerifyEndpoint.VerifyEndpointRequest req)
        {
            return VerifyEndpoint.VerifyEndpointAction(req, _context);
        }
    }
}