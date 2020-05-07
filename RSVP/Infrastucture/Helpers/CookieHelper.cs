using System;
using System.Web;
using System.Web.Hosting;
using System.Collections.Generic;

namespace RSVP.Infrastucture.Helpers
{
    public static class CookieHelper
    {
        public static HttpCookie GetCookie(string cookieName)
        {
            return HttpContext.Current.Request.Cookies[cookieName];
        }

        public static void SetCookie(string cookieName, string value)
        {
            // Check if cookie exists and update it
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                HttpContext.Current.Response.Cookies[cookieName].Value = value;
            } else
            {
                // If it doesn't exist then create a new cookie
                HttpCookie newCookie = new HttpCookie(cookieName)
                {
                    Expires = DateTime.Now.AddHours(2),
                    Shareable = true,
                    Value = value
                };
                HttpContext.Current.Response.Cookies.Add(newCookie);
            }
        }

        public static void DeleteCookie(string cookieName)
        {
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                HttpContext.Current.Request.Cookies[cookieName].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}