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
        var now = _date.Now;
        return $"{now.Year}.{now.Month:D2}.{now.Day:D2}";
    }

    public string Number03()
    {
        var now = _date.Now;
        return $"Day {now.Day:D2} of {now.ToString("MMMM")}, {now.Year}";
    }

    public string Number04()
    {
        var now = _date.Now;
        return $"Year:{now.Year}, Month:{now.Month:D2}, Day:{now.Day:D2}";
    }

    public string Number05()
    {
        var now = _date.Now;
        return now.ToString("dddd").PadLeft(10);
    }

    public string Number06()
    {
        var now = _date.Now;
        return $"{now:t}".PadRight(10) + $"{now.ToString("dddd")}".PadRight(10);
    }

    public string Number07()
    {
        var now = _date.Now;
        return $"h:{now.Hour:D2}, m:{now.Month:D2}, s:{now.Second:D2}";
    }

    public string Number08()
    {
        var now = _date.Now;
        return $"{now.Year}.{now.Month:D2}.{now.Day:D2}.{now.Hour:D2}.{now.Minute:D2}.{now.Second:D2}";
    }

    public string Number09()
    {
        var pi = Math.PI;
        return String.Format($"{pi:C}");
    }

    public string Number10()
    {
        var pi = Math.PI;
        return String.Format($"{pi:0.000}".PadRight(10));
    }

    public string Number11()
    {
        var now = _date.Now;
        return $"{Math.Sqrt(2):X2}";
    }

    //2.2019.01.22
}
