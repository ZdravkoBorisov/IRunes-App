using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Controllers
{
   public class PackagesController : Controller
    {
        public HttpResponse Details()
        {
            return this.View();
        }

        public HttpResponse Create()
        {
            return this.View();
        }

        public HttpResponse Delivered()
        {
            return this.View();
        }

        public HttpResponse Pending()
        {
            return this.View();
        }
    }
}
