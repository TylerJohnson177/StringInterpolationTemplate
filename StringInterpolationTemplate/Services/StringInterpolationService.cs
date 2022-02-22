using System;
using Microsoft.Extensions.Logging;
using StringInterpolationTemplate.Utils;

namespace StringInterpolationTemplate.Services;

public class StringInterpolationService : IStringInterpolationService
{
    private readonly ISystemDate _date;
    private readonly ILogger<IStringInterpolationService> _logger;

    public StringInterpolationService(ISystemDate date, ILogger<IStringInterpolationService> logger)
    {
        _date = date;
        _logger = logger;
        _logger.Log(LogLevel.Information, "Executing the StringInterpolationService");
    }

    //1. January 22, 2019 (right aligned in a 40 character field)
    public string Number01()
    {
        var date = _date.Now.ToString("MMMM dd, yyyy");
        var answer = $"{date,40}";
        Console.WriteLine(answer);

        return answer;
    }

    public string Number02()
    {
        var date = _date.Now;
        return $"{date.Year}.{date.Month:D2}.{date.Day:D2}";
    }

    public string Number03()
    {
        var date = _date.Now;
        return $"Day {date.Day:D2} of {date.ToString("MMMM")}, {date.Year}";
    }

    public string Number04()
    {
        var date = _date.Now;
        return $"Year: {date.Year}, Month: {date.Month:D2}, Day: {date.Day:D2}";
    }

    public string Number05()
    {
        var date = _date.Now;
        return date.ToString("dddd").PadLeft(10);
    }

    public string Number06()
    {
        var date = _date.Now;
        return $"{date:t}".PadRight(10) + $"{date.ToString("dddd")}".PadRight(10);
    }

    public string Number07()
    {
        var date = _date.Now;
        return $"h:{date.Hour:D2}, m:{date.Month:D2}, s:{date.Second:D2}";
    }

    public string Number08()
    {
        var date = _date.Now;
        return $"{date.Year}.{date.Month:D2}.{date.Day:D2}.{date.Hour:D2}.{date.Minute:D2}.{date.Second:D2}";
    }

    public string Number09()
    {
        var pi = Math.PI;
        return String.Format($"{pi:C, en-US}");
    }

    public string Number10()
    {
        var pi = Math.PI;
        return String.Format($"{pi:0.000}".PadLeft(10));
    }

    public string Number11()
    {
        double sqrt = Math.Sqrt(2);
        return sqrt.ToString("X");

    }

    //2.2019.01.22
}
