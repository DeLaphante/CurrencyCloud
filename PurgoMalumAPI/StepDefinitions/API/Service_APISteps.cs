using CynkyHttp;
using FluentAssertions;
using PurgoMalumAPI.EndpointBuilder;
using PurgoMalumAPI.Models.API.Response;
using Reqnroll;
using System;
using System.Net;

namespace PurgoMalumAPI.StepDefinitions.API
{
    [Binding]
    public class Service_APISteps
    {
        CynkyClient _CynkyClient;
        ScenarioContext _ScenarioContext;

        public Service_APISteps(ScenarioContext scenarioContext)
        {
            _CynkyClient = scenarioContext.ScenarioContainer.Resolve<CynkyClient>();
            _ScenarioContext = scenarioContext.ScenarioContainer.Resolve<ScenarioContext>();
        }

        [StepDefinition("input text is {string}")]
        public void GivenInputTextIs(string text)
        {
            _ScenarioContext.Set<string>(text, "text");
        }

        [StepDefinition("the request is made to the json endpoint")]
        public void WhenTheRequestIsMadeToTheJsonEndpoint()
        {
            _CynkyClient.SendRequest(Method.GET, $"{ServiceEndpointBuilder.GetJsonEndpoint()}/?text={_ScenarioContext.Get<string>("text")}");
            _ScenarioContext.Set<string>("json", "endpoint");
        }

        [StepDefinition("the request is made to the json endpoint with parameters {string}")]
        public void WhenTheRequestIsMadeToTheJsonEndpointWithParameters(string parameters)
        {
            _CynkyClient.SendRequest(Method.GET, $"{ServiceEndpointBuilder.GetJsonEndpoint()}/?text={_ScenarioContext.Get<string>("text")}&{parameters}");
            _ScenarioContext.Set<string>("json", "endpoint");
        }

        [StepDefinition("the request is made to the xml endpoint")]
        public void WhenTheRequestIsMadeToTheXmlEndpoint()
        {
            _CynkyClient.SendRequest(Method.GET, $"{ServiceEndpointBuilder.GetXmlEndpoint()}/?text={_ScenarioContext.Get<string>("text")}");
            _ScenarioContext.Set<string>("xml", "endpoint");
        }

        [StepDefinition("the request is made to the xml endpoint with parameters {string}")]
        public void WhenTheRequestIsMadeToTheXmlEndpointWithParameters(string parameters)
        {
            _CynkyClient.SendRequest(Method.GET, $"{ServiceEndpointBuilder.GetXmlEndpoint()}/?text={_ScenarioContext.Get<string>("text")}&{parameters}");
            _ScenarioContext.Set<string>("xml", "endpoint");
        }

        [StepDefinition("the request is made to the plain endpoint")]
        public void WhenTheRequestIsMadeToThePlainEndpoint()
        {
            _CynkyClient.SendRequest(Method.GET, $"{ServiceEndpointBuilder.GetPlainEndpoint()}/?text={_ScenarioContext.Get<string>("text")}");
            _ScenarioContext.Set<string>("plain", "endpoint");
        }

        [StepDefinition("the request is made to the plain endpoint with parameters {string}")]
        public void WhenTheRequestIsMadeToThePlainEndpointWithParameters(string parameters)
        {
            _CynkyClient.SendRequest(Method.GET, $"{ServiceEndpointBuilder.GetPlainEndpoint()}/?text={_ScenarioContext.Get<string>("text")}&{parameters}");
            _ScenarioContext.Set<string>("plain", "endpoint");
        }

        [StepDefinition("the request is made to the containsprofanity endpoint")]
        public void WhenTheRequestIsMadeToTheContainsprofanityEndpoint()
        {
            _CynkyClient.SendRequest(Method.GET, $"{ServiceEndpointBuilder.GetContainsProfanityEndpoint()}/?text={_ScenarioContext.Get<string>("text")}");
            _ScenarioContext.Set<string>("containsprofanity", "endpoint");
        }

        [StepDefinition("the response should be {string}")]
        public void ThenTheResponseShouldBe(string text)
        {
            _CynkyClient.GetStatusCode().Should().Be(HttpStatusCode.OK);

            switch (_ScenarioContext.Get<string>("endpoint"))
            {
                case "json":
                    var json = _CynkyClient.GetJsonResponseBody<JsonResponse>();
                    json.result.Should().Be(text);
                    break;
                case "xml":
                    var xml = _CynkyClient.GetXmlResponseBody<XmlResponse>();
                    xml.Result.Should().Be(text);
                    break;
                case "plain":
                case "containsprofanity":
                    var plain = _CynkyClient.GetResponseBody();
                    plain.Should().Be(text);
                    break;
                default:
                    throw new Exception("Unkonwn endpoint!");
            }
        }

        [StepDefinition("the response error should be {string}")]
        public void ThenTheResponseErrorShouldBe(string text)
        {
            _CynkyClient.GetStatusCode().Should().Be(HttpStatusCode.OK);

            switch (_ScenarioContext.Get<string>("endpoint"))
            {
                case "json":
                    var json = _CynkyClient.GetJsonResponseBody<JsonResponse>();
                    json.error.Should().Be(text);
                    break;
                case "xml":
                    var xml = _CynkyClient.GetXmlResponseBody<XmlResponse>();
                    xml.Error.Should().Be(text);
                    break;
                case "plain":
                case "containsprofanity":
                    var plain = _CynkyClient.GetResponseBody();
                    plain.Should().Be(text);
                    break;
                default:
                    throw new Exception("Unkonwn endpoint!");
            }
        }
    }
}

