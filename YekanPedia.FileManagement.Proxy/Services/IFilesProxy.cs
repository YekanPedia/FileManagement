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
    }
}
