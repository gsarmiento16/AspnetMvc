using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspnetMvc.Database;
using AspnetMvc.Helpers;
using AspnetMvc.Models;

namespace AspnetMvc.Helpers
{
    public static class SecurityHelper
    {
        public static Boolean AuthorizeActivity(string activityName, User user) {
            Boolean auth = true;
            using (var db = new DataContext())
            {
                var activity = db.SecActivities.Where(w => w.Name.Equals(activityName)).FirstOrDefault();
                if (activity == null) { return false; }
                var activityRole = activity.SecActivityRoles.Where(w => w.RoleId == user.UserRoles.FirstOrDefault().Id).FirstOrDefault();
                //var activyRole = db.SecActivityRoles.Where(w => w.RoleId == user.UserRoles.FirstOrDefault().RoleId && w.SecActivityId==activity.Id).FirstOrDefault();
                if (activityRole == null) { return false; }
                
            }
            
            return auth;
        }

        public static Boolean ReadModelFilter(string modelName, User user)
        {
            Boolean auth = false;

            using (var secModel = new SecModelHelper())
            {
                secModel.getSecModelAttributesRole(modelName, user);
            }

                return auth;
        }
        
       

    }
}