using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMBot.Extensions
{
    public static class LuisResultExtensions
    {
        public static String GetResolvedListEntity(this LuisResult result, String nameOfListEntity)
        {
            if (result.TryFindEntity("LeaveType", out EntityRecommendation leaveEntityRecommendation))
            {
                var msg = leaveEntityRecommendation.Resolution.FirstOrDefault().Value as Newtonsoft.Json.Linq.JArray;
                return msg.First.ToString();
            }

            return null;
        }
    }
}