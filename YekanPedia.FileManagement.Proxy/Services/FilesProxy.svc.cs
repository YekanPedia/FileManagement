namespace YekanPedia.FileManagement.Proxy.Services
{
    using System;
    using System.Collections.Generic;
    using Model;
    using System.Web;
    using IO = System.IO;
    using System.Linq;
    using Extension;

    public class FilesProxy : IFilesProxy
    {
        public List<FileInfo> GetListFiles(string address)
        {
            string rootPath = "~/Files/";
            var Server = HttpContext.Current.Server;
            var dir = new IO.DirectoryInfo(Server.MapPath($"{rootPath}{address}"));
            bool exists = IO.Directory.Exists(Server.MapPath(rootPath + address));
            if (!exists)
                IO.Directory.CreateDirectory(Server.MapPath(rootPath + address));
            IO.FileInfo[] files = dir.GetFiles();
            return files.Select(X => new FileInfo { DirectLink = $"{AppSettings.HostAddress}/{address}/{X.Name}", Extension = X.Extension }).ToList();
        }
        public string CreateDirectory(string address)
        {
            try
            {
                var Server = HttpContext.Current.Server;
                address = "Files/" + address;
                bool exists = IO.Directory.Exists(Server.MapPath("~/" + address));
                if (!exists)
                    IO.Directory.CreateDirectory(Server.MapPath("~/" + address));
                return address;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public long GetDirectorySize()
        {
            try
            {
                var Server = HttpContext.Current.Server;
                return new IO.DirectoryInfo(Server.MapPath($"~/Files")).GetFiles("*.*", IO.SearchOption.AllDirectories).Sum(file => file.Length);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string UploadImage(PostedImageFile file)
        {
            try
            {
                var Server = HttpContext.Current.Server;
                string address = $"UserPictures/{DateTime.Now.Year}/{DateTime.Now.Month}/";
                string absolateAddress = Server.MapPath($"~/{address}");
                bool exists = IO.Directory.Exists(absolateAddress);
                if (!exists)
                    IO.Directory.CreateDirectory(absolateAddress);
                #region Upload File And Return the Url
                var path = IO.Path.Combine(absolateAddress, "_" + file.FileName);
                IO.File.WriteAllBytes(path, file.Content);
                ImageCropper.Crop(path, IO.Path.Combine(absolateAddress, file.FileName), file.Width, file.Height, file.X, file.Y);
                IO.File.Delete(path);
                return $"http://Files.YekanPedia.org/PictureManager/Content/{address}{{size}}/{file.FileName.Split('.')[0]}/{file.FileName.Split('.')[1]}";
                #endregion
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
