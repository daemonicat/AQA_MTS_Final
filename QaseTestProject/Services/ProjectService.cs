using QaseTestProject.Clients;
using QaseTestProject.Models;
using RestSharp;

namespace QaseTestProject.Services;

public class ProjectService: IProjectService, IDisposable
{
    private readonly RestClientExtended _client;

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }
    
    public Task<Project> CreateNewProject(Project project)
    {
        var request =  new RestRequest("/v1/project", Method.Post).AddJsonBody(project);
        return _client.ExecuteAsync<Project>(request);
    }

    public Task<Project> GetProjectByCode(string code)
    {
        var request =  new RestRequest("/v1/project/{code}").AddUrlSegment("code", code);
        return _client.ExecuteAsync<Project>(request);
    }

    public Task<Project> DeleteProjectByCode(string code)
    {
        var request =  new RestRequest("/v1/project/{code}", Method.Delete).AddUrlSegment("code", code);
        return _client.ExecuteAsync<Project>(request);
    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}