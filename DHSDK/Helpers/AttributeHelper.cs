using System;
using System.Linq;
using System.Reflection;

namespace DHSDK.Helpers
{
    public static class AttributeHelper
    {
        public static T GetAttribute<T>(Enum enumValue) where T : Attribute
        {
            T attribute;

            MemberInfo memberInfo = enumValue.GetType().GetMember(enumValue.ToString())
                                            .FirstOrDefault();

            if (memberInfo != null)
            {
                attribute = (T)memberInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                return attribute;
            }

            return null;
        }

        public static T GetAttribute<T>(object obj) where T : Attribute
        {
            T attribute;

            MemberInfo memberInfo = obj.GetType().GetMember(obj.ToString())
                                            .FirstOrDefault();

            if (memberInfo != null)
            {
                attribute = (T)memberInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                return attribute;
            }

            return null;
        }
    }
}
