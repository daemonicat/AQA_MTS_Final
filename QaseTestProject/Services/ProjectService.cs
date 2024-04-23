using NLog;
using QaseTestProject.Clients;
using QaseTestProject.Models;
using RestSharp;

namespace QaseTestProject.Services;

public class ProjectService : IProjectService, IDisposable
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly RestClientExtended _client;

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }

    public async Task<ApiResult<Project>> CreateNewProject(Project? project)
    {
        var request = new RestRequest("/v1/project", Method.Post).AddJsonBody(project);
        _logger.Info(request);
        return await _client.ExecuteAsync<ApiResult<Project>>(request);
    }

    public Task<ApiResult<Project>> GetProjectByCode(string code)
    {
        var request = new RestRequest("/v1/project/{code}").AddUrlSegment("code", code);
        return _client.ExecuteAsync<ApiResult<Project>>(request);
    }

    public Task<ApiResult<Project>> DeleteProjectByCode(string code)
    {
        var request = new RestRequest("/v1/project/{code}", Method.Delete).AddUrlSegment("code", code);
        return _client.ExecuteAsync<ApiResult<Project>>(request);
    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}