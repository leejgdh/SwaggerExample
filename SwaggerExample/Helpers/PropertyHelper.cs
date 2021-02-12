using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace SwaggerExample.Helpers
{

    public static class PropertyHelper
    {

        public static void UpdateProperty<T>(ref T update_to, in object update_from)
        {
            //기본 Except 추가

            string[] default_except = new string[] { "DeletedAt" };

            PropertyInfo[] from_properties = update_from.GetType().GetProperties();
            PropertyInfo[] to_properties = update_to.GetType().GetProperties();


            foreach (PropertyInfo to_property in to_properties)
            {
                // key는 업데이트 하지 않는다.
                bool is_key = Attribute.IsDefined(to_property, typeof(KeyAttribute));

                if (is_key)
                {
                    continue;
                }

                //from에서 이름 똑같은거 찾아본다.

                if (default_except.Contains(to_property.Name))
                {
                    continue;
                }

                IEnumerable<PropertyInfo> same_property = from_properties.Where(e => e.Name == to_property.Name);

                if (same_property.Any())
                {
                    PropertyInfo from_property = same_property.First();

                    //null이면 건너뜀
                    if (from_property.GetValue(update_from) == null)
                    {
                        continue;
                    }

                    // Datetime offset은 Datetime으로 변경
                    if (to_property.PropertyType == typeof(DateTime) && from_property.PropertyType == typeof(DateTimeOffset))
                    {
                        to_property.SetValue(update_to, ((DateTimeOffset)from_property.GetValue(update_from)).UtcDateTime);
                    }
                    else
                    {
                        to_property.SetValue(update_to, from_property.GetValue(update_from));
                    }
                }

            }

        }

    }
}