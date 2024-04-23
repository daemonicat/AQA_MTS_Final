using NLog;
using QaseTestProject.Clients;
using QaseTestProject.Models;
using RestSharp;

namespace QaseTestProject.Services;

public class TestCaseService : ITestCaseService, IDisposable
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly RestClientExtended _client;

    public TestCaseService(RestClientExtended client)
    {
        _client = client;
    }

    public async Task<ApiResult<TestCase>> CreateNewTestCase(TestCase? testCase, string code)
    {
        var request = new RestRequest("/v1/case/{code}", Method.Post)
            .AddJsonBody(testCase)
            .AddUrlSegment("code", code);
        _logger.Info(request);
        return await _client.ExecuteAsync<ApiResult<TestCase>>(request);
    }

    public async Task<ApiResult<TestCase>> GetTestCase(string code, int id)
    {
        var request = new RestRequest("/v1/case/{code}/{id}")
            .AddUrlSegment("code", code)
            .AddUrlSegment("id", id);
        _logger.Info(request);
        return await _client.ExecuteAsync<ApiResult<TestCase>>(request);
    }

    public async Task<ApiResult<TestCase>> UpdateTestCase(TestCase? testCase, string code, int id)
    {
        var request = new RestRequest("/v1/case/{code}/{id}", Method.Patch)
            .AddJsonBody(testCase)
            .AddUrlSegment("code", code)
            .AddUrlSegment("id", id);
        _logger.Info(request);
        return await _client.ExecuteAsync<ApiResult<TestCase>>(request);
    }

    public async Task<ApiResult<TestCase>> DeleteTestCase(string code, int id)
    {
        var request = new RestRequest("/v1/case/{code}/{id}", Method.Delete)
            .AddUrlSegment("code", code)
            .AddUrlSegment("id", id);
        _logger.Info(request);
        return await _client.ExecuteAsync<ApiResult<TestCase>>(request);
    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}