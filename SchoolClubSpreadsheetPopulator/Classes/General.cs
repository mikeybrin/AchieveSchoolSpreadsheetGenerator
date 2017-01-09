using SchoolClubSpreadsheetPopulator.Classes;
using System.Collections.Generic;

namespace SchoolClubSpreadsheetPopulator.Classes
{
    public class Country
    {
        public string Name { get; set; }
        public Dictionary<string, School> Schools { get; set; }
    }

    public class School
    {
        public string Name { get; set; }
        public Dictionary<string, SpreadsheetData> Spreadsheets { get; set; }
    }

    public class SpreadsheetData
    {
        public string Name { get; set; }
        public string YearGroup { get; set; }
        public string TargetRowId { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Student
    {
        public List<mappingsTemplatemasterSpreadsheetMapping> Values { get; set; }
    }
}
