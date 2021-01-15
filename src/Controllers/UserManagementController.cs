using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stave.Endpoints.UserManagement;

namespace Stave.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserManagementController : ControllerBase
    {
        StaveContext _context;

        public UserManagementController (StaveContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("add")]
        public AddUserEndpoint.AddUserEndpointResponse AddUser(AddUserEndpoint.AddUserEndpointRequest req)
        {
            return AddUserEndpoint.AddUserEndpointAction(req, _context);
        }

        [HttpPost]
        [Route("delete")]
        public DeleteUserEndpoint.DeleteUserEndpointResponse DeleteUser(DeleteUserEndpoint.DeleteUserEndpointRequest req)
        {
            return DeleteUserEndpoint.DeleteUserEndpointAction(req, _context);
        }

    }
}