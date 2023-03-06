using Xunit;
using Moq;
using Jacaranda.UseCase.Interfaces.Repositories;
using Jacaranda.Tests.Context;
using Xunit.Microsoft.DependencyInjection.Abstracts;
using Xunit.Abstractions;

namespace Jacaranda.Tests;

public class CertificateTests : TestBed<Fixture>
{
    public CertificateTests(ITestOutputHelper testOutputHelper, Fixture fixture) : base(testOutputHelper, fixture) { }

    [Fact]
    public void RepositoryShouldNotBeNull()
    {
        var CertificateRepository = _fixture.GetService<ICertificateRepository>(_testOutputHelper);

        Assert.NotNull(CertificateRepository);
    }
}
