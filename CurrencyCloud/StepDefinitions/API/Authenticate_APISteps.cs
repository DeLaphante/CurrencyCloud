using CurrencyCloud.Configuration;
using CurrencyCloud.EndpointBuilder;
using CurrencyCloud.Models.API.Response;
using CynkyHttp;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace CurrencyCloud.StepDefinitions.API
{
    [Binding]
    public class Authenticate_APISteps
    {
        CynkyClient _CynkyClient;

        ScenarioContext _ScenarioContext;


        public Authenticate_APISteps(ScenarioContext scenarioContext)
        {
            _CynkyClient = scenarioContext.ScenarioContainer.Resolve<CynkyClient>();
            _ScenarioContext = scenarioContext.ScenarioContainer.Resolve<ScenarioContext>();
        }


        [StepDefinition(@"the form data has (.*) loginId and (.*) apiKey")]
        public void GivenTheFormDataHasValidAndValid(string loginId, string apiKey)
        {
            switch (loginId.ToLower())
            {
                case "valid":
                    loginId = ConfigManager.LoginId;
                    break;
                case "invalid":
                    loginId = "asdhasdak";
                    break;
                case "null":
                    loginId = null;
                    break;
                default:
                    throw new Exception("Unknown loginId value!");
            }

            switch (apiKey.ToLower())
            {
                case "valid":
                    apiKey = ConfigManager.ApiKey;
                    break;
                case "invalid":
                    apiKey = "asdhasdak";
                    break;
                case "null":
                    apiKey = null;
                    break;
                default:
                    throw new Exception("Unknown apiKey value!");
            }

            var formData = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("login_id", loginId),
                new KeyValuePair<string, string>("api_key", apiKey)
            };

            _ScenarioContext.Set<List<KeyValuePair<string, string>>>(formData, "formData");
        }

        [StepDefinition(@"a post form data request is sent to the login endpoint")]
        public void WhenAPostFormDataRequestIsSentToTheLoginEndpoint()
        {
            var formData = _ScenarioContext.Get<List<KeyValuePair<string, string>>>("formData");
            _CynkyClient.SendRequest(Method.POSTFORM, AuthenticateEndpointBuilder.GetLoginEndpoint(), formData: formData);
        }

        [StepDefinition(@"a (.*) response should be returned")]
        public void ThenAOKResponseShouldBeReturned(string response)
        {
            switch (response.ToLower())
            {
                case "ok":
                    _CynkyClient.GetStatusCode().Should().Be(HttpStatusCode.OK);
                    if (_CynkyClient.GetResponseBody<AuthResponse>().auth_token != null)
                    {
                        _CynkyClient.GetResponseBody<AuthResponse>().auth_token.Should().NotBeNullOrEmpty();
                        _ScenarioContext.Set<AuthResponse>(_CynkyClient.GetResponseBody<AuthResponse>(), "authToken");
                    }
                    break;
                case "unauthorized":
                    _CynkyClient.GetStatusCode().Should().Be(HttpStatusCode.Unauthorized);
                    _CynkyClient.GetResponseBody<AuthInvalidResponse>().error_code.Should().Be("auth_failed");
                    break;
                case "badrequest":
                    _CynkyClient.GetStatusCode().Should().Be(HttpStatusCode.BadRequest);
                    _CynkyClient.GetResponseBody<AuthInvalidResponse>().error_code.Should().Be("auth_invalid_user_login_details");
                    break;
                case "empty":
                    _CynkyClient.GetStatusCode().Should().Be(HttpStatusCode.OK);
                    _CynkyClient.GetResponseBody().Should().Be("{}");
                    break;
                default:
                    throw new Exception("Unknown response value!");
            }
        }

        [Given(@"a (.*) auth token is added as a header")]
        public void GivenTheAuthTokenIsAddedAsAHeader(string authToken)
        {
            switch (authToken.ToLower())
            {
                case "valid":
                    _CynkyClient.AddHeader("X-Auth-Token", _ScenarioContext.Get<AuthResponse>("authToken").auth_token);
                    break;
                case "invalid":
                    _CynkyClient.AddHeader("X-Auth-Token", "asdasd");
                    break;
                case "empty":
                    _CynkyClient.AddHeader("X-Auth-Token", string.Empty);
                    break;
                case "none":
                    break;
                default:
                    throw new Exception("Unknown auth token value!");
            }

        }

        [When(@"a post request is sent  to the logout endpoint")]
        public void WhenAPostRequestIsSentToTheLogoutEndpoint()
        {
            _CynkyClient.SendRequest(Method.POST, AuthenticateEndpointBuilder.GetLogoutEndpoint());
        }

    }
}
