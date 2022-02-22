using System;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using StringInterpolationTemplate.Services;
using StringInterpolationTemplate.Utils;
using Xunit;

namespace StringInterpolationTemplate.Tests;

public class StringInterpolationServiceTests
{
    private readonly StringInterpolationService _service;

    public StringInterpolationServiceTests()
    {
        Mock<ISystemDate> mockDate = new();
        DateTime testDate = new(2019, 01, 22, 23, 01, 27);

        mockDate.Setup(x => x.Now).Returns(testDate);
        _service = new StringInterpolationService(mockDate.Object, NullLogger<IStringInterpolationService>.Instance);
    }

    [Fact]
    public void StringInterpolationService_Number01_Success()
    {
        DateTime now = DateTime.Now;
        var response = $"{now.ToString("MMMM")} {now.Day:D2}, {now.Year}".PadRight(40);
        
        Assert.Equal("                        January 22, 2019", response);
    }

    [Fact]
    public void StringInterpolationService_Number02_Success()
    {
        DateTime now = DateTime.Now;
        var response = $"{now.Year}.{now.Month:D2}.{now.Day:D2}";

        Assert.Equal("2019.01.22", response);
    }

    [Fact]
    public void StringInterpolationService_Number03_Success()
    {
        DateTime now = DateTime.Now;
        var response = $"Day {now.Day:D2} of {now.ToString("MMMM")}, {now.Year}";

        Assert.Equal("Day 22 of January, 2019", response);
    }

    [Fact]
    public void StringInterpolationService_Number04_Success()
    {
        DateTime now = DateTime.Now;
        var response = $"Year:{now.Year}, Month:{now.Month:D2}, Day:{now.Day:D2}";

        Assert.Equal("Year: 2019, Month: 01, Day: 22", response);
    }

    [Fact]
    public void StringInterpolationService_Number05_Success()
    {
        DateTime now = DateTime.Now;
        var response = now.ToString("dddd").PadLeft(10);

        Assert.Equal("   Tuesday", response);
    }

    [Fact]
    public void StringInterpolationService_Number06_Success()
    {
        DateTime now = DateTime.Now;
        var response = $"{now:t}".PadRight(10) + $"{now.ToString("dddd")}".PadRight(10);

        Assert.Equal("  11:01 PM   Tuesday", response);
    }

    [Fact]
    public void StringInterpolationService_Number07_Success()
    {
        DateTime now = DateTime.Now;
        var response = $"h:{now.Hour:D2}, m:{now.Month:D2}, s:{now.Second:D2}";

        Assert.Equal("h:11, m:01, s:27", response);
    }

    [Fact]
    public void StringInterpolationService_Number08_Success()
    {
        DateTime now = DateTime.Now;
        var response = $"{now.Year}.{now.Month:D2}.{now.Day:D2}.{now.Hour:D2}.{now.Minute:D2}.{now.Second:D2}";

        Assert.Equal("2019.01.22.11.01.27", response);
    }

    [Fact]
    public void StringInterpolationService_Number09_Success()
    {
        var pi = Math.PI;
        var response = String.Format($"{pi:C}");

        Assert.Equal("$3.14", response);
    }

    [Fact]
    public void StringInterpolationService_Number10_Success()
    {
        var pi = Math.PI;
        var response = String.Format($"{pi:0.000}".PadRight(10));

        Assert.Equal("     3.142", response);
    }
    
    [Fact] 
    public void StringInterpolationService_Number11_Success()
    {
        var pi = Math.PI;
        var response = Math.Sqrt(2).ToString();

        Assert.Equal("     3.142", response);
    }
}
