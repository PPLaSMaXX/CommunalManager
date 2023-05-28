using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionHelper
{
    public class CommunalValue
    {
        public enum Type { Gas, Water, Electricity };
        public Type localtype;
        public int value;
        public int LinkedId;

        public CommunalValue(string sType,int value, int linkedId)
        {
            localtype = Enum.Parse<Type>(sType);
            this.value = value;
            LinkedId = linkedId;
        }
    }
}
