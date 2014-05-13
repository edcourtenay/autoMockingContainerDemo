using System;
using AMCDemo.Web.Interfaces;

namespace AMCDemo.Web.Services
{
    public class DateService : IDateService {
        public DateTime GetDateTime()
        {
            return new DateTime(2014, 4, 2);
        }
    }
}