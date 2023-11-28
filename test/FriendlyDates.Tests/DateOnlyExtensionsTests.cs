using FluentAssertions;
#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

namespace FriendlyDates.Tests;

public class DateOnlyExtensionsTests
{
    
    [Theory]
    [MemberData(nameof(DateOnlyTestData))]
    public void DateOnlyExtensionsReturnsDate(DateOnly testDate)
    {
        var result = testDate.Month switch
        {
            1 => DateOnlyExtensions.January(testDate.Day, testDate.Year),
            2 => DateOnlyExtensions.February(testDate.Day, testDate.Year),
            3 => DateOnlyExtensions.March(testDate.Day, testDate.Year),
            4 => DateOnlyExtensions.April(testDate.Day, testDate.Year),
            5 => DateOnlyExtensions.May(testDate.Day, testDate.Year),
            6 => DateOnlyExtensions.June(testDate.Day, testDate.Year),
            7 => DateOnlyExtensions.July(testDate.Day, testDate.Year),
            8 => DateOnlyExtensions.August(testDate.Day, testDate.Year),
            9 => DateOnlyExtensions.September(testDate.Day, testDate.Year),
            10 => DateOnlyExtensions.October(testDate.Day, testDate.Year),
            11 => DateOnlyExtensions.November(testDate.Day, testDate.Year),
            12 => DateOnlyExtensions.December(testDate.Day, testDate.Year),
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
            1 => () => { DateOnlyExtensions.January(32, 2023); },
            2 => () => { DateOnlyExtensions.February(30, 2023); },
            3 => () => { DateOnlyExtensions.March(32, 2023); },
            4 => () => { DateOnlyExtensions.April(31, 2023); },
            5 => () => { DateOnlyExtensions.May(32, 2023); },
            6 => () => { DateOnlyExtensions.June(31, 2023); },
            7 => () => { DateOnlyExtensions.July(32, 2023); },
            8 => () => { DateOnlyExtensions.August(32, 2023); },
            9 => () => { DateOnlyExtensions.September(31, 2023); },
            10 => () => { DateOnlyExtensions.October(32, 2023); },
            11 => () => { DateOnlyExtensions.November(31, 2023); },
            12 => () => { DateOnlyExtensions.December(32, 2023); },
        };

        act.Should().Throw<ArgumentOutOfRangeException>();
    }
    
    public static TheoryData<DateOnly> DateOnlyTestData()
    {
        var result = new TheoryData<DateOnly>();
        var start = new DateOnly(2023, 1, 1);
        var end = new DateOnly(2024, 1, 1);
        while (start != end)
        {
            result.Add(start);
            start = start.AddDays(1);
        }

        return result;
    }
}