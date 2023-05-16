using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostAPI
{
    public class CountryGwp
    {
        public string country { get; set; }
        public string variableId { get; set; }
        public string  variableName { get; set; }
        public string lineOfBusiness { get; set; }
        public string y2000 { get; set; }
        public string y2001 { get; set; }
        public string y2002 { get; set; }
        public string y2003 { get; set; }
        public string y2004 { get; set; }
        public string y2005 { get; set; }
        public string y2006 { get; set; }
        public string y2007 { get; set; }
        public string y2008 { get; set; }
        public string y2009 { get; set; }
        public string y2010 { get; set; }
        public string y2011 { get; set; }
        public string y2012 { get; set; }
        public string y2013 { get; set; }
        public string y2014 { get; set; }
        public string y2015 { get; set; }

        public static CountryGwp FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            CountryGwp dailyValues = new CountryGwp();
            dailyValues.country = values[0];
            dailyValues.variableId = values[1];
            dailyValues.variableName = values[2];
            dailyValues.lineOfBusiness = values[3];
            dailyValues.y2000 = values[4];
            dailyValues.y2001 = values[5];
            dailyValues.y2002 = values[6];
            dailyValues.y2003 = values[7];
            dailyValues.y2004 = values[8];
            dailyValues.y2005 = values[9];
            dailyValues.y2006 = values[10];
            dailyValues.y2007 = values[11];
            dailyValues.y2008 = values[12];
            dailyValues.y2009 = values[13];
            dailyValues.y2010 = values[14];
            dailyValues.y2011 = values[15];
            dailyValues.y2012 = values[16];
            dailyValues.y2013 = values[17];
            dailyValues.y2014 = values[18];
            dailyValues.y2015 = values[19];
            return dailyValues;
        }
    }
}
