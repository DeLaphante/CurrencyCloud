namespace CurrencyCloud.EndpointBuilder
{
    public class AuthenticateEndpointBuilder
    {
        public static string GetLoginEndpoint()
        {
            return "authenticate/api";
        }

        public static string GetLogoutEndpoint()
        {
            return "authenticate/close_session";
        }
    }
}
