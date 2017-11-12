using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMBot.Dialogs
{
    public class StaticMessage
    {
        public static string AboutDemo {get; set;}
        static StaticMessage()
        {
            AboutDemo = "Please visit: https://www.youtube.com/watch?v=2_QpOVp5rpo to know more about HR bot and to see a demo.";
        }
    }
}