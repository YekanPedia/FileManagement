namespace YekanPedia.FileManagement.Proxy.Controllers
{
    using System.Web.Mvc;
    public partial class ErrorController : Controller
    {
        [HttpGet]
        public virtual ActionResult NotFound()
        {
            return View();
        }
    }
}