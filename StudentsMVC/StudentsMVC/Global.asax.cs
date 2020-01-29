using StudentsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StudentsMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static int classroomsIdCount;
        public static int addressesIdCount;
        public static int studentsIdCount;

        public static IList<Classroom> classroomList = new List<Classroom>();
        public static IList<Address> addressList = new List<Address>();
        public static IList<Student> studentList = new List<Student>();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
