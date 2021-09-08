using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    { }
}
