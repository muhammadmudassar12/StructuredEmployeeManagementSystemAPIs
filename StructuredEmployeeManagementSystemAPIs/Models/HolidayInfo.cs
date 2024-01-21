namespace StructuredEmployeeManagementSystemAPIs.Models
{
    public class HolidayInfo : BaseEntity
    {
        public int Holidays { get; set; }
        public int Leaves { get; set; }
        public int TotalHolidays { get; set; }
        public int BasicId { get; set; }
    }
}
