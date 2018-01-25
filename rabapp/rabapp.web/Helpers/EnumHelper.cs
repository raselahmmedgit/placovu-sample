using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rabapp.Helpers
{
    public enum MessageType { info, warn, success, error }

    public enum AppRoles : int
    {
        Admin = 1,
        Employee = 2,
        User = 3
    }

    public enum AppUsers : int
    {
        Admin = 1,
        Employee = 2,
        User = 3
    }
}