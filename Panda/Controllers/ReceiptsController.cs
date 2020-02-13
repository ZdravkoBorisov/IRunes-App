using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Controllers
{
   public class ReceiptsController : Controller
    {
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
