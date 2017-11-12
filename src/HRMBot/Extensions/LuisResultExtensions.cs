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
            EntityRecommendation leaveEntityRecommendation;

            if (result.TryFindEntity("LeaveType", out leaveEntityRecommendation))
            {
                var msg = leaveEntityRecommendation.Resolution.FirstOrDefault().Value as Newtonsoft.Json.Linq.JArray;
                return msg.First.ToString();
            }

            return null;
        }

        public static String GetResolvedEntity(this LuisResult result, String nameOfEntity)
        {
            EntityRecommendation leaveEntityRecommendation;

            if (result.TryFindEntity(nameOfEntity, out leaveEntityRecommendation))
            {
                var msg = leaveEntityRecommendation.Entity;
                return msg;
            }

            return null;
        }
    }
}