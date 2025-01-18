namespace HowClient.Common.Routing;

public static class Rout
{
    private static string _public = "public";
    private static string _authorized = "authorized";
    private static string _dashboard = "dashboard";
    private static string _event = "event";
    private static string _record = "record";
    
    
    public static string Login => "/login";
    public static string LoginIdentity => "/authentication/login";
    public static string LogoutIdentity => "/authentication/logout";
    public static string Registration => "/registration";
    
    public static class Home
    {
        public static string HomePublicPage => $"/{_public}";
        public static string HomePrivatePage => $"/{_authorized}";
    }
    
    public static class Event
    {
        public static string EventPublicPage(int eventId) => $"/{_public}/{_event}/{eventId}/{_record}";
        public static string EventPrivatePage(int eventId) => $"/{_authorized}/{_event}/{eventId}/{_record}";
    }
    
    public static class Dashboard
    {
        public static string PrivatePage => $"/{_authorized}/{_dashboard}";
        public static string EventPrivatePage(int eventId) => $"/{_authorized}/{_dashboard}/{_event}/{eventId}/{_record}";
    }
}