using LiveChartsCore.Defaults;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ConsumptionHelper
{
    public static class DataController
    {
        static public List<CommunalEntry> GetValues()
        {
            List<CommunalEntry> DateEntryList = GetDateEntries();

            List<CommunalValue> entryList = GetEntries();

            foreach (CommunalValue entry in entryList)
            {
                DateEntryList.Find(x => x.ID == entry.LinkedId)!.entries.Add(entry);
            }

            return DateEntryList;
        }
        static private List<CommunalEntry> GetDateEntries()
        {
            List<CommunalEntry> DateEntryList = new();
            var cmd = new MySqlCommand("SELECT * FROM communalentry", SqlContoller.sqlConnection);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DateEntryList.Add(new CommunalEntry(rdr.GetInt32(0), rdr.GetDateTime(1)));
            }
            return DateEntryList;
        }

        static private List<CommunalValue> GetEntries()
        {
            List<CommunalValue> entryList = new();
            var cmd = new MySqlCommand("SELECT * FROM communalvalues", SqlContoller.sqlConnection);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<string> test = new();

            while (rdr.Read())
            {
                entryList.Add(new CommunalValue(rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3)));
            }

            return entryList;
        }

        static public List<DateTimePoint> MakeView(List<CommunalEntry> communalEntries, CommunalValue.Type type)
        {
            List<DateTimePoint> DTPoints = new();
            foreach (CommunalEntry communalEntry in communalEntries)
            {
                DTPoints.Add(new DateTimePoint(communalEntry.Date, communalEntry.entries.Find(x => x.localtype == type)!.value));
            }

            return DTPoints;
        }
    }
}
