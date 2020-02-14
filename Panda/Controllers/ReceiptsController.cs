using Panda.Services;
using Panda.ViewModels.Receipts;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Linq;

namespace Panda.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        public HttpResponse Index()
        {
            var viewModel = new ReceiptViewModel();

            return this.View(viewModel);
        }  
    }
}
