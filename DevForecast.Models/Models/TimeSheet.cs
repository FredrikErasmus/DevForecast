using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevForecast.Models
{
    public class TimeSheet
    {
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public string Project { get; set; }
        public string Department { get; set; }
        public string Activity { get; set; }
        public TimeSpan HoursAllocated { get; set; }
        public string Remark { get; set; }
        public int WorkAllocationId { get; set; }
        public int UserId { get; set; }
        public string EmploymentType { get; set; }
        public string DivisionName { get; set; }
        public string RegionName { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public int ActivityId { get; set; }
        public int Period { get; set; }
        public int TotalHours { get; set; }
        public int Capacity { get; set; }
        public string TrainingType { get; set; }
        public string TrainerName { get; set; }
        public string TrainingInstitute { get; set; }
    }
}
