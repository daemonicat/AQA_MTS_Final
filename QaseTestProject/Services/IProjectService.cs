using QaseTestProject.Models;

namespace QaseTestProject.Services;

public interface IProjectService
{
    Task<Project> CreateNewProject(Project project);
    Task<Project> GetProjectByCode(string code);
    Task<Project> DeleteProjectByCode(string code);
}