 namespace YekanPedia.FileManagement.Proxy
{
    using System.Configuration;
    public static class AppSettings {
        public static bool ClientValidationEnabled => bool.Parse(ConfigurationManager.AppSettings["ClientValidationEnabled"]);
        public static bool UnobtrusiveJavaScriptEnabled => bool.Parse(ConfigurationManager.AppSettings["UnobtrusiveJavaScriptEnabled"]);
        public static string HostAddress => ConfigurationManager.AppSettings["HostAddress"];
    }
}