using NLog;
using QaseTestProject.Clients;
using QaseTestProject.Models.API;
using RestSharp;

namespace QaseTestProject.Services;

public class ProjectService(RestClientExtended client) : IProjectService, IDisposable
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public async Task<ApiResult<Project>> CreateNewProject(Project project)
    {
        var request = new RestRequest("/v1/project", Method.Post).AddJsonBody(project);
        _logger.Info(request);
        return await client.ExecuteAsync<ApiResult<Project>>(request);
    }

    public Task<ApiResult<Project>> GetProjectByCode(string code)
    {
        var request = new RestRequest("/v1/project/{code}").AddUrlSegment("code", code);
        return client.ExecuteAsync<ApiResult<Project>>(request);
    }

    public Task<ApiResult<Project>> DeleteProjectByCode(string code)
    {
        var request = new RestRequest("/v1/project/{code}", Method.Delete).AddUrlSegment("code", code);
        return client.ExecuteAsync<ApiResult<Project>>(request);
    }

    public void Dispose()
    {
        client.Dispose();
        GC.SuppressFinalize(this);
    }
}