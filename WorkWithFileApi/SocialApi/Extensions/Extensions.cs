namespace ZwajApp.api.Extensions;

public static class Extensions
{

    public static int CalculateAge(this DateTime Date)
    {
        var Age = DateTime.Today.Year - Date.Year;
        if (Date.AddYears(Age) > DateTime.Today)
        {
            Age--;
        }
        return Age;

    }
}
