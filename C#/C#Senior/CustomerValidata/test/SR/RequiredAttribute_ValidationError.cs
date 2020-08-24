using System.Resources;

namespace test.SR
{
    internal class SR
    {
        internal static string GetResourceString(string resourceKey, string defaultString = null)
        {
            return resourceKey;
        }

        internal static string RequiredAttribute_ValidationError
        {
            get
            {
                return SR.GetResourceString("您的输入有误", "您的输入有误");
            }
        }
        
    }
}