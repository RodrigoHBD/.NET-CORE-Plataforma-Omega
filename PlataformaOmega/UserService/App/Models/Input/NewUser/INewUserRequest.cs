using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.App.Models.Input
{
    public interface INewUserRequest
    {
        string Username { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
    }
}
