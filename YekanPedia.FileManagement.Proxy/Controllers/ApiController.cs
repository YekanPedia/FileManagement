namespace YekanPedia.FileManagement.Proxy.Controllers
{
    using System.Web.Mvc;
    using ManagementSystem.InfraStructure.Date;
    using System.IO;

    public class ApiController : Controller
    {
        [HttpGet, Route("Api/Remove/{day:int}")]
        public JsonResult Remove(int day)
        {
            var date = PersianDateTime.Now.AddDays(-1 * day);
            var address = $"~/Files/{date.Year}/{date.Month}/{date.Day}";
            try
            {
                var dir = new DirectoryInfo(Server.MapPath(address));
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir.Delete(true);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (IOException ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}