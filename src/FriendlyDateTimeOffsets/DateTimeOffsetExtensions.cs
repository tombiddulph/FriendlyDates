namespace FriendlyDateTimeOffsets;

public static class DateTimeOffsetExtensions
{
    public static DateTimeOffset January(this int day, int year) => CreateDate(day, 1, year);
    
    public static DateTimeOffset February(this int day, int year) => CreateDate(day, 2,year);
    
    public static DateTimeOffset March(this int day, int year) => CreateDate(day, 3, year);
    
    public static DateTimeOffset April(this int day, int year) => CreateDate(day, 4, year);
    
    public static DateTimeOffset May(this int day, int year) => CreateDate(day, 5, year);
    
    public static DateTimeOffset June(this int day, int year) => CreateDate(day, 6, year);
    
    public static DateTimeOffset July(this int day, int year) => CreateDate(day, 7, year);
    
    public static DateTimeOffset August(this int day, int year) => CreateDate(day, 8, year);
    
    public static DateTimeOffset September(this int day, int year) => CreateDate(day, 9, year);
    
    public static DateTimeOffset October(this int day, int year) => CreateDate(day, 10, year);
    
    public static DateTimeOffset November(this int day, int year) => CreateDate(day, 11, year);
    
    public static DateTimeOffset December(this int day, int year) => CreateDate(day, 12, year);
    
    
    private static DateTimeOffset CreateDate(int day, int month, int year)
    {
        if (day > DateTime.DaysInMonth(day, month))
        {
            throw new ArgumentOutOfRangeException(nameof(day), $"Day must be a valid day in {month}");
        }
        return new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.Zero);
    }
}