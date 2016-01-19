namespace YekanPedia.FileManagement.Proxy.Services
{
    using System.ServiceModel;
    using Model;
    using System.Collections.Generic;

    [ServiceContract]
    public interface IFilesProxy
    {
        [OperationContract]
        List<FileInfo> GetListFiles(string address);

        [OperationContract]
        string CreateDirectory(string address);

        [OperationContract]
        long GetDirectorySize();

        [OperationContract]
        string UploadImage(PostedImageFile file);

        [OperationContract]
        FileInfo UploadDocument(PostedFile file);

        [OperationContract]
        bool OverrideDocument(PostedFile file, string address);

        [OperationContract]
        bool DeleteFile(string address);
    }
}
