namespace PurgoMalumAPI.EndpointBuilder
{
    public class ServiceEndpointBuilder
    {
        public static string GetXmlEndpoint()
        {
            return "service/xml";
        }

        public static string GetJsonEndpoint()
        {
            return "service/json";
        }

        public static string GetPlainEndpoint()
        {
            return "service/plain";
        }

        public static string GetContainsProfanityEndpoint()
        {
            return "service/containsprofanity";
        }

    }
}
