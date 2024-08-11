using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;

namespace Architecture.Tests;

public class ArchitectureTests
{
    private const string DomainNamespace = "Domain";
    private const string ApplicationNamespace = "Application";
    private const string InfrastructureNamespace = "Infrastructure";
    private const string PresentationNamespace = "Presentation";
    private const string WebApiNamespace = "WebApi";

    public static IEnumerable<object[]> GetData()
    {
        yield return new object[] {
            typeof(Domain.AssemblyReference).Assembly,
            new string[] {
                ApplicationNamespace,
                InfrastructureNamespace,
                PresentationNamespace,
                WebApiNamespace } };
        yield return new object[] {
            typeof(Application.AssemblyReference).Assembly,
            new string[] {
                InfrastructureNamespace,
                PresentationNamespace,
                WebApiNamespace } };
        yield return new object[] {
            typeof(Infrastructure.AssemblyReference).Assembly,
            new string[] {
                ApplicationNamespace,
                PresentationNamespace,
                WebApiNamespace } };
        yield return new object[] {
            typeof(Presentation.AssemblyReference).Assembly,
            new string[] {
                InfrastructureNamespace,
                WebApiNamespace } };
    }

    [Theory]
    [MemberData(nameof(GetData))]
    public void Project_Should_NotHave_DependencyOnOtherProjects(Assembly project, string[] otherProjects)
    {
        // Arrange

        // Act
        var actual = Types
            .InAssembly(project)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert

        actual.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Handlers_Should_Have_DependencyOnDomain()
    {
        // Arrange
        var project = typeof(Application.AssemblyReference).Assembly;

        // Act
        var actual = Types
            .InAssembly(project)
            .That()
            .HaveNameEndingWith("Handler")
            .Should()
            .HaveDependencyOn(DomainNamespace)
            .GetResult();

        // Assert

        actual.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Controllers_Should_Have_DependencyOnMediatR()
    {
        // Arrange
        var project = typeof(Application.AssemblyReference).Assembly;

        // Act
        var actual = Types
            .InAssembly(project)
            .That()
            .HaveNameEndingWith("Controller")
            .Should()
            .HaveDependencyOn("MediatR")
            .GetResult();

        // Assert

        actual.IsSuccessful.Should().BeTrue();
    }
}
