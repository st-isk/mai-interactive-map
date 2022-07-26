using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Parsing_module;
using System.Text.RegularExpressions;

namespace Plan3.Data
{
    public class ScheduleService
    {
        public Task<OccupiedList> GetOccupiedAsync(int floor)
        {
            DateTime time = DateTime.Parse("13:10:50");
            //DateTime time = DateTime.Now;
            List<string> occ_list = new List<string>();
            using (var db = new LiteDatabase(@"MAI.db"))
            {
                var col = db.GetCollection<SchedulePos>("Schedule");
                //Parser.Get_info(col, false);
                var result = col.Find(x => time > DateTime.Parse(x.Time_start) && time < DateTime.Parse(x.Time_finish));
                foreach (var item in result)
                {
                    if (Regex.IsMatch(item.Location, "ГУК \\w-" + floor + "\\d{2}")) occ_list.Add(Regex.Matches(item.Location, "ГУК \\w-(\\d{3})")[0].Groups[1].Value);
                }
            }
     
            return Task.FromResult(new OccupiedList(occ_list));
        }
    };
}
