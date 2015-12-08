namespace YekanPedia.FileManagement.Proxy.Controllers
{
    using System.Web.Mvc;
    using Extension;

    public class PictureManagerController : Controller
    {
        [HttpGet, Route("PictureManager/Content/{userPictures}/{year:int}/{month:int}/{size:int}/{fileName}/{extension}")]
        public FileContentResult Content(int year, int month, int size, string fileName, string extension)
        {
            string path = Server.MapPath($"~/UserPictures/{year}/{month}/{fileName}.{extension}");
            return File(ImageManager.Scale(path, size, size), ImageManager.getContentType(path));
        }
    }
}