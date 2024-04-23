using QaseTestProject.Models.API;

namespace QaseTestProject.Services;

public interface IProjectService
{
    Task<ApiResult<Project>> CreateNewProject(Project? project);
    Task<ApiResult<Project>> GetProjectByCode(string code);
    Task<ApiResult<Project>> DeleteProjectByCode(string code);
}