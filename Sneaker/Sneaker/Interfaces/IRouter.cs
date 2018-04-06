using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sneaker.Interfaces
{
    interface IRouter
    {
        Task RouteAsync(RouteContext context);
        VirtualPathData GetVirtualPath(VirtualPathContext context);
    }
}
