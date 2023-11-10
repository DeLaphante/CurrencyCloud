using System.Collections.Generic;

namespace CurrencyCloud.Models.API.Response
{
    internal class AuthInvalidResponse
    {
        public string error_code { get; set; }
        public ErrorMessages error_messages { get; set; }
    }

    public class ApiKey
    {
        public string code { get; set; }
        public string message { get; set; }
        public Params @params { get; set; }
    }

    public class ErrorMessages
    {
        public List<ApiKey> api_key { get; set; }
    }

    public class Params
    {
        public int length { get; set; }
    }
}
