using GravityCodeChallenge.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GravityCodeChallenge.Services.FileService
{
    public class FileService : IFileService
    {
        public List<DriverReport> ProcessFile(IFormFile file)
        {
            string line;
            List<string> drivers = new List<string>();
            List<Trip> trips = new List<Trip>();
            List<DriverReport> reports = new List<DriverReport>();

            try
            {
                if(file.Length > 0)
                {
                    using (var stream = new StreamReader(file.OpenReadStream()))
                    {
                        //var filestring = stream.ReadToEnd();
                        while((line = stream.ReadLine()) != null)
                        {
                            line = line.Trim();
                            if (line.StartsWith("Driver"))
                            {
                                drivers.Add(line.Split(new[] { " " }, StringSplitOptions.None)[1]);
                            }
                            else if (line.StartsWith("Trip"))
                            {
                                var properties = line.Split(new[] { " " }, StringSplitOptions.None);
                                if (properties.Length == 5) {
                                    var startDate = new DateTime(1, 1, 1, Convert.ToInt32(properties[2].Split(new[] { ":" }, StringSplitOptions.None)[0]), Convert.ToInt32(properties[2].Split(new[] { ":" }, StringSplitOptions.None)[1]), 0);
                                    var endDate = new DateTime(1, 1, 1, Convert.ToInt32(properties[3].Split(new[] { ":" }, StringSplitOptions.None)[0]), Convert.ToInt32(properties[3].Split(new[] { ":" }, StringSplitOptions.None)[1]), 0);
                                    Trip newTrip = new Trip {
                                        Driver = properties[1],
                                        Duration = endDate - startDate,
                                        Distance = Convert.ToDouble(properties[4])
                                    };
                                    if (newTrip.Speed >= 5 && newTrip.Speed <= 100)
                                    {
                                        trips.Add(newTrip);
                                    }
                                }
                                else
                                {
                                    throw new Exception("The Trip information provided does not match expected formats: TRIP Driver HH:MM HH:MM Miles");
                                }
                            }
                            else
                            {
                                //probably want to log a nonconforming line?
                                throw new Exception("The file contains a line with an unknown command.");
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("The file is empty.");
                }
                foreach(var driver in drivers)
                {
                    var driverTrips = trips.Where(m => m.Driver.ToUpper().Equals(driver.ToUpper())).ToList();
                    var driverReport = new DriverReport { DriverName = driver, Distance = 0 };
                    if (driverTrips.Any())
                    {
                        driverReport.Distance = (int)Math.Round(driverTrips.Sum(m => m.Distance));
                        driverReport.Speed = (int)Math.Round(driverTrips.Average(m => m.Speed));
                    }
                    reports.Add(driverReport);
                }

                return reports;
            }
            catch(Exception ex)
            {
                //log exception
                return null;
            }
        }
    }
}
