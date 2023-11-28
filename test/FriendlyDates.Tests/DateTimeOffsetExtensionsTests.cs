using FluentAssertions;
using FriendlyDateTimeOffsets;

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
namespace FriendlyDates.Tests;

public class DateTimeOffsetExtensionsTests
{
    [Theory, MemberData(nameof(DateTimeOffsetTestData))]
    public void DateTimeOffsetExtensionsReturnsDate(DateTimeOffset testDate)
    {
        var result = testDate.Month switch
        {
            1 => DateTimeOffsetExtensions.January(testDate.Day, testDate.Year),
            2 => DateTimeOffsetExtensions.February(testDate.Day, testDate.Year),
            3 => DateTimeOffsetExtensions.March(testDate.Day, testDate.Year),
            4 => DateTimeOffsetExtensions.April(testDate.Day, testDate.Year),
            5 => DateTimeOffsetExtensions.May(testDate.Day, testDate.Year),
            6 => DateTimeOffsetExtensions.June(testDate.Day, testDate.Year),
            7 => DateTimeOffsetExtensions.July(testDate.Day, testDate.Year),
            8 => DateTimeOffsetExtensions.August(testDate.Day, testDate.Year),
            9 => DateTimeOffsetExtensions.September(testDate.Day, testDate.Year),
            10 => DateTimeOffsetExtensions.October(testDate.Day, testDate.Year),
            11 => DateTimeOffsetExtensions.November(testDate.Day, testDate.Year),
            12 => DateTimeOffsetExtensions.December(testDate.Day, testDate.Year),
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
            1 => () => { DateTimeOffsetExtensions.January(32, 2023); },
            2 => () => { DateTimeOffsetExtensions.February(30, 2023); },
            3 => () => { DateTimeOffsetExtensions.March(32, 2023); },
            4 => () => { DateTimeOffsetExtensions.April(31, 2023); },
            5 => () => { DateTimeOffsetExtensions.May(32, 2023); },
            6 => () => { DateTimeOffsetExtensions.June(31, 2023); },
            7 => () => { DateTimeOffsetExtensions.July(32, 2023); },
            8 => () => { DateTimeOffsetExtensions.August(32, 2023); },
            9 => () => { DateTimeOffsetExtensions.September(31, 2023); },
            10 => () => { DateTimeOffsetExtensions.October(32, 2023); },
            11 => () => { DateTimeOffsetExtensions.November(31, 2023); },
            12 => () => { DateTimeOffsetExtensions.December(32, 2023); },
        };

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    public static TheoryData<DateTimeOffset> DateTimeOffsetTestData()
    {
        var result = new TheoryData<DateTimeOffset>();
        var start = new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var end = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
        while (start != end)
        {
            result.Add(start);
            start = start.AddDays(1);
        }

        return result;
    }
}