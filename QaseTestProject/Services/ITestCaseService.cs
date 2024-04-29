using QaseTestProject.Models.API;

namespace QaseTestProject.Services;

public interface ITestCaseService
{
    Task<ApiResult<TestCase>> CreateNewTestCase(TestCase testCase, string code);
    Task<ApiResult<TestCase>> GetTestCase(string code, int id);
    Task<ApiResult<TestCase>> UpdateTestCase(TestCase testCase, string code, int id);
    Task<ApiResult<TestCase>> DeleteTestCase(string code, int id);
}