namespace YekanPedia.FileManagement.Proxy.Services
{
    using System;
    using System.Collections.Generic;
    using Model;
    using System.Web;
    using IO = System.IO;
    public class FilesProxy : IFilesProxy
    {
        public List<FileInfo> GetListFiles(string address)
        {
            return new List<FileInfo> {
                new FileInfo {  DirectLink="asdfdas.mp3" , Extension="mp3"},
                new FileInfo { DirectLink = "asdfdas.docx",Extension="docx" },
                new FileInfo {DirectLink="asdfdas.pdf",Extension="pdf" }
            };
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
    }
}
