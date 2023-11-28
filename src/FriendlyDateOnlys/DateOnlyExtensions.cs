namespace FriendlyDates;

public static  class DateOnlyExtensions
{
    public static DateOnly January(this int day, int year) => CreateDate(day, 1, year);
    
    public static DateOnly February(this int day, int year) => CreateDate(day, 2,year);
    
    public static DateOnly March(this int day, int year) => CreateDate(day, 3, year);
    
    public static DateOnly April(this int day, int year) => CreateDate(day, 4, year);
    
    public static DateOnly May(this int day, int year) => CreateDate(day, 5, year);
    
    public static DateOnly June(this int day, int year) => CreateDate(day, 6, year);
    
    public static DateOnly July(this int day, int year) => CreateDate(day, 7, year);
    
    public static DateOnly August(this int day, int year) => CreateDate(day, 8, year);
    
    public static DateOnly September(this int day, int year) => CreateDate(day, 9, year);
    
    public static DateOnly October(this int day, int year) => CreateDate(day, 10, year);
    
    public static DateOnly November(this int day, int year) => CreateDate(day, 11, year);
    
    public static DateOnly December(this int day, int year) => CreateDate(day, 12, year);
    
    private static DateOnly CreateDate(int day, int month, int year)
    {
        if (day > DateTime.DaysInMonth(day, month))
        {
            throw new ArgumentOutOfRangeException(nameof(day), $"Day must be a valid day in {month}");
        }
        return new DateOnly(year, month, day);
    }
}