using System.Globalization;

namespace CoreBussiness.CoreEntity;

public class Core
{
    public Core()
    {
        CurrentTime = SetCurrentTime();
        CurrentDate = SetCurrentDate();
        CreationOffsetTime = DateTimeOffset.Now;
    }
    public int Id { get; set; }
    public string CurrentTime { get; set; }
    private string CurrentDate { get; set; }
    private DateTimeOffset CreationOffsetTime { get; set; }
    public string? ModificationTime { get; set; }
    
    private string SetCurrentTime()=>new PersianCalendar().GetHour(DateTime.Now) + ":" +
                                     new PersianCalendar().GetMinute(DateTime.Now) + ":" +
                                     new PersianCalendar().GetSecond(DateTime.Now);
    private string SetCurrentDate()=> new PersianCalendar().GetYear(DateTime.Now) + "/" + new PersianCalendar().GetMonth(DateTime.Now) +
                                      "/" + new PersianCalendar().GetDayOfMonth(DateTime.Now);
    public bool IsDeleted { get; set; }
}