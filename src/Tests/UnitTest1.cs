using Microsoft.Extensions.Logging;
using EzStartup.Logic;
using NSubstitute;

namespace Tests;

public class UnitTest1
{
    private ILogger<Loader> _logger;
    private ILaunchApps _launcher;

    private Loader _sut;

    public UnitTest1()
    {
        _logger = Substitute.For<ILogger<Loader>>();
        _launcher = Substitute.For<ILaunchApps>();

        //_sut = new EzStartup.Logic.Loader(_logger, ...)
    }

    [Fact]
    public void Test1()
    {
        // arrange
        // setup mocks

        // act
        _sut.Load();

        // assert
        // run assertions, such as _launcerh.shouldhavecalled xyz
        _launcher.Launch("", "", "").Received(1);
        var a = 1;
        a.Should().Be(1); // < this is fluentassertions framework
        Assert.Equal(a, 1);
    }
}