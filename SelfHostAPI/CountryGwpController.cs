using SelfHostAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace OwinSelfhostSample
{
    public class CountryGwpController : ApiController
    {
        // GET api/values 
        public IEnumerable<string> Get()
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);
            var fileName = "\\gwpByCountry.csv";
            var path = directory + fileName;

            //Complete Records
            List<CountryGwp> allValues = File.ReadAllLines(path)
                               .Skip(1)
                               .Select(v => CountryGwp.FromCsv(v))
                               .ToList();

            //Counting total number of records that matches accordign to country name given.
            List<CountryGwp> totalRows = new List<CountryGwp>();

            //Final Result Set having lines of business (LOB) & average list.
            List<string> finalResultSet = new List<string>();

            Console.WriteLine("Enter Country : ");
            string inputCountry = Console.ReadLine();

            Console.WriteLine("Enter LOB : ");
            string[] inputLOB = Console.ReadLine().Split(',');

            totalRows = allValues.Where(w => w.country.Equals(inputCountry)).ToList();

            Console.WriteLine();
            Console.WriteLine(".........................Result...........................");
            int index = 0;
            while (index < inputLOB.Count())
            {
                CountryGwp temp = totalRows.Where(w => w.lineOfBusiness.Equals(inputLOB[index])).FirstOrDefault();

                if(temp != null) 
                {
                    float t008 = !String.IsNullOrEmpty(temp.y2008) ? float.Parse(temp.y2008) : 0.0f;
                    float t009 = !String.IsNullOrEmpty(temp.y2009) ? float.Parse(temp.y2009) : 0.0f;
                    float t010 = !String.IsNullOrEmpty(temp.y2010) ? float.Parse(temp.y2010) : 0.0f;
                    float t011 = !String.IsNullOrEmpty(temp.y2011) ? float.Parse(temp.y2011) : 0.0f;
                    float t012 = !String.IsNullOrEmpty(temp.y2012) ? float.Parse(temp.y2012) : 0.0f;
                    float t013 = !String.IsNullOrEmpty(temp.y2013) ? float.Parse(temp.y2013) : 0.0f;
                    float t014 = !String.IsNullOrEmpty(temp.y2014) ? float.Parse(temp.y2014) : 0.0f;
                    float t015 = !String.IsNullOrEmpty(temp.y2015) ? float.Parse(temp.y2015) : 0.0f;

                    //Adding Explicit Casting to handle null, white space while reading from csv file.
                    float average = (t008 + t009 + t010 + t011 + t012 + t013 + t014 + t015) / 8.0f;
                    finalResultSet.Add(temp.lineOfBusiness + " : " + average);
                    index++;
                }
                else if(temp == null)
                {
                    Console.WriteLine("Please provide valid country / lineOfBusiness");
                    break;
                }
            }
            return finalResultSet.AsEnumerable();
        }

        // GET api/values/5 
        public string Get(string id)
        {
            return "value";
        }

        // POST api/values 
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}