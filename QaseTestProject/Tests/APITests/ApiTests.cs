/*using System.Net;
using System.Text.Json;
using NLog;
using QaseTestProject.Models;
using RestSharp;
using RestSharp.Authenticators.OAuth2;

namespace QaseTestProject.Tests.APITests;

public class ApiTests
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private const string Uri = "https://api.qase.io";

    private const string Token = "6ea73c46610c1f9bc84a37a304e99113a0748e2df25b31db1a2ab121420febdd";


    [Test]
    public void SimpleTest()
    {
        const string endpoint = "/v1/project";
        Result expectedProject = new Result
        {
            Title = "CreatedViaAPI",
            Code = "APIPR5",
            Access = "all"
        };
        
        var options = new RestClientOptions(Uri);
        var client = new RestClient(options);

        var request = new RestRequest(endpoint).AddJsonBody(expectedProject);
        //request.AddHeader("accept", "application/json");
        request.AddHeader("token", Token);
        
        var response = client.ExecutePost<Project>(request);
        Logger.Info(response.Content);
        var actualProject = response.Data;

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(actualProject.Result.Code, Is.EqualTo(expectedProject.Code));
        });
    }
}*/