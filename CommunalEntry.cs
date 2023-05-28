using Google.Protobuf.WellKnownTypes;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionHelper
{
    public class CommunalEntry
    {
        public int ID;
        public DateTime Date;

        public List<CommunalValue> entries = new();

        public CommunalEntry(int iD, DateTime date)
        {
            ID = iD;
            Date = date;
        }
    }
}
