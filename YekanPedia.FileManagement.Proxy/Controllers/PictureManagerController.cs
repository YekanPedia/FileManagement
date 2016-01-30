namespace YekanPedia.FileManagement.Proxy.Controllers
{
    using System.Web.Mvc;
    using Extension;
    using IO = System.IO;

    public partial class PictureManagerController : Controller
    {
        [HttpGet, Route("PictureManager/Content/{userPictures}/{year:int}/{month:int}/{size:int}/{fileName}/{extension}")]
        public virtual ActionResult Content(int year, int month, int size, string fileName, string extension)
        {
            string path = Server.MapPath($"~/UserPictures/{year}/{month}/{fileName}.{extension.ToLower()}");
            if (!IO.File.Exists(path))
            {
                return RedirectToAction(MVC.Error.NotFound());
            }
            return File(ImageManager.Scale(path, size, size), ImageManager.getContentType(path));
        }
    }
}