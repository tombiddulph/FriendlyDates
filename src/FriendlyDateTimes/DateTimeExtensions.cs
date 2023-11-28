namespace FriendlyDateTimes;

public static class DateTimeExtensions
{
    
    public static DateTime January(this int day, int year) => CreateDate(day, 1, year);

    public static DateTime February(this int day, int year) => CreateDate(day, 2,year);
    
    public static DateTime March(this int day, int year) => CreateDate(day, 3, year);
    
    public static DateTime April(this int day, int year) => CreateDate(day, 4, year);
    
    public static DateTime May(this int day, int year) => CreateDate(day, 5, year);
    
    public static DateTime June(this int day, int year) => CreateDate(day, 6, year);
    
    public static DateTime July(this int day, int year) => CreateDate(day, 7, year);
    
    public static DateTime August(this int day, int year) => CreateDate(day, 8, year);
    
    public static DateTime September(this int day, int year) => CreateDate(day, 9, year);
    
    public static DateTime October(this int day, int year) => CreateDate(day, 10, year);
    
    public static DateTime November(this int day, int year) => CreateDate(day, 11, year);
    
    public static DateTime December(this int day, int year) => CreateDate(day, 12, year);

    private static DateTime CreateDate(int day, int month, int year)
    {
        if (day > DateTime.DaysInMonth(day, month))
        {
            throw new ArgumentOutOfRangeException(nameof(day), $"Day must be a valid day in {month}");
        }
        return new DateTime(year, month, day);
    }
    
}