using System;

namespace ListAutoSelectTest
{
    public class UserLap
    {
        public Guid UserLapID { get; set; }
        public TimeSpan LapTime { get; set; }
        public int LapNumber { get; set; }
        public bool InLap { get; set; }
        public bool OutLap { get; set; }
        public Guid SetupSheetID { get; set; }
        public int? LapTypeIntID { get; set; }
    }
}