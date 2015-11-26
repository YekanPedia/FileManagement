namespace YekanPedia.FileManagement.Proxy.Controllers
{
    using System.Web.Mvc;
    using ManagementSystem.InfraStructure.Date;
    using System.IO;

    public class ApiController : Controller
    {
        [HttpGet]
        public JsonResult Remove()
        {
            var date = PersianDateTime.Now.AddDays(-8);
            var address = $"~/Files/{date.Year}/{date.Month}/{date.Day}";
            try
            {
                var dir = new DirectoryInfo(Server.MapPath(address));
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir.Delete(true);
                return Json(true,JsonRequestBehavior.AllowGet);
            }
            catch (IOException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}