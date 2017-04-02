using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspnetMvc.Models;
namespace AspnetMvc.Helpers
{
    public static class ModelFilterHelper<T>
    {

        public static T Read(IList<SecModelAttributeRole> list)
        {
            T model = default(T);

            Type type = typeof(T);
            //int attributeCount = 0;

            foreach (var property in type.GetProperties())
            {
                if (property.GetValue(type, null) != null)
                {
                    string attributeName = property.Name;
                    bool allowRead = list.Where(w => w.SecModelAttribute.Name.Equals(attributeName)).FirstOrDefault().AllowRead;

                }    
            }

            int count =  type.GetType()
                         .GetProperties()
                         .Select(x => x.GetValue(type, null))
                         .Count(v => v != null);
        

            /*foreach (PropertyInfo property in type.GetProperties())
            {
                attributeCount += property.GetCustomAttributes(false).Length;
            }*/
            return model;
        }
    }
}