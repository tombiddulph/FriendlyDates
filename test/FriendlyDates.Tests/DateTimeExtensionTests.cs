using FluentAssertions;
using FriendlyDateTimes;

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

namespace FriendlyDates.Tests;

public class DateTimeExtensionTests
{
    [Theory]
    [MemberData(nameof(DateTimeTestData))]
    public void DateTimeExtensionsReturnsDate(DateTime testDate)
    {
        var result = testDate.Month switch
        {
            1 => DateTimeExtensions.January(testDate.Day, testDate.Year),
            2 => DateTimeExtensions.February(testDate.Day, testDate.Year),
            3 => DateTimeExtensions.March(testDate.Day, testDate.Year),
            4 => DateTimeExtensions.April(testDate.Day, testDate.Year),
            5 => DateTimeExtensions.May(testDate.Day, testDate.Year),
            6 => DateTimeExtensions.June(testDate.Day, testDate.Year),
            7 => DateTimeExtensions.July(testDate.Day, testDate.Year),
            8 => DateTimeExtensions.August(testDate.Day, testDate.Year),
            9 => DateTimeExtensions.September(testDate.Day, testDate.Year),
            10 => DateTimeExtensions.October(testDate.Day, testDate.Year),
            11 => DateTimeExtensions.November(testDate.Day, testDate.Year),
            12 => DateTimeExtensions.December(testDate.Day, testDate.Year),
        };

        result.Should().Be(testDate);
    }


    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    public void ThrowsWhenDayNotInMonth(int month)
    {
        Action act = month switch
        {
            1 => () => { DateTimeExtensions.January(32, 2023); },
            2 => () => { DateTimeExtensions.February(30, 2023); },
            3 => () => { DateTimeExtensions.March(32, 2023); },
            4 => () => { DateTimeExtensions.April(31, 2023); },
            5 => () => { DateTimeExtensions.May(32, 2023); },
            6 => () => { DateTimeExtensions.June(31, 2023); },
            7 => () => { DateTimeExtensions.July(32, 2023); },
            8 => () => { DateTimeExtensions.August(32, 2023); },
            9 => () => { DateTimeExtensions.September(31, 2023); },
            10 => () => { DateTimeExtensions.October(32, 2023); },
            11 => () => { DateTimeExtensions.November(31, 2023); },
            12 => () => { DateTimeExtensions.December(32, 2023); },
        };

        act.Should().Throw<ArgumentOutOfRangeException>();
    }


    public static TheoryData<DateTime> DateTimeTestData()
    {
        var result = new TheoryData<DateTime>();
        var start = new DateTime(2023, 1, 1);
        var end = new DateTime(2024, 1, 1);
        while (start != end)
        {
            result.Add(start);
            start = start.AddDays(1);
        }

        return result;
    }
}