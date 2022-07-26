using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Parsing_module;
using System.Text.RegularExpressions;

namespace Plan3.Pages
{
    public partial class Auditory
    {
        [Parameter]
        public string Number { get; set; }

        private string[] timetbl_start =
        {
            "09:00", "10:45", "13:00", "14:45", "16:30", "18:15", "20:00"
        };

        private string[] timetbl_fin =
        {
            "10:30", "12:15", "14:30", "16:15", "18:00", "19:45", "21:30"
        };

        private bool isOccupied(string time_start)
        {
            bool status = false;
            using (var db = new LiteDatabase(@"MAI.db"))
            {
                var col = db.GetCollection<SchedulePos>("Schedule");
                var result = col.Exists(x => time_start == x.Time_start && Regex.IsMatch(x.Location, "ГУК \\w-" + Number));
                if (result)
                    status = true;
                else
                    status = false;
            }
            return status;
        }
    }
}
