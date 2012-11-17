using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Pharmalto.Ecosystem
{
    public class Routes : IRouteProvider
    {
        public IEnumerable<RouteDescriptor> GetRoutes() {
            return new[] {
                new RouteDescriptor {
                    Route = new Route(
                        "Ecosystem",
                        new RouteValueDictionary {
                            {"area", "Pharmalto.Ecosystem"},
                            {"controller", "Home"},
                            {"action", "Index"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Pharmalto.Ecosystem"}
                        },
                        new MvcRouteHandler())
                },
                new RouteDescriptor {
                    Route = new Route(
                        "Ecosystem/Register",
                        new RouteValueDictionary {
                            {"area", "Pharmalto.Ecosystem"},
                            {"controller", "Home"},
                            {"action", "Register"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Pharmalto.Ecosystem"}
                        },
                        new MvcRouteHandler())
                },
                new RouteDescriptor {
                    Route = new Route(
                        "Ecosystem/Login",
                        new RouteValueDictionary {
                            {"area", "Pharmalto.Ecosystem"},
                            {"controller", "Home"},
                            {"action", "Login"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Pharmalto.Ecosystem"}
                        },
                        new MvcRouteHandler())
                },
                new RouteDescriptor {
                    Route = new Route(
                        "Ecosystem/Detail/{id}",
                        new RouteValueDictionary {
                            {"area", "Pharmalto.Ecosystem"},
                            {"controller", "Home"},
                            {"action", "Detail"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Pharmalto.Ecosystem"}
                        },
                        new MvcRouteHandler())
                },
            };
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }
    }
}