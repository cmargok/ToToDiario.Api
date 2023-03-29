using System.ComponentModel;

namespace ToToDiario.API.Domain.Shared.ExtensionsMethods
{
    public static class Methods
    {
        public static string GetDescription(this Enum enumType)
        {
            var type = enumType.GetType();

            var memInfo = type.GetMember(enumType.ToString());

            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumType.ToString();
        }
    }
}
