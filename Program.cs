using Microsoft.Win32;

namespace HW_04_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string keypath = @"Software\HW_04_10";

            string defUserName = "Guest";
            int defFontSize = 12;

            string userName = ReadRegistryValue(keypath, "UserName", defUserName);
            int fontSize = ReadRegistryValue(keypath,"FontSize",defFontSize);

            Console.WriteLine("Текущие настройки:");
            Console.WriteLine("Имя пользователя: "+ userName);
            Console.WriteLine("Размер шрифта: "+ fontSize);

            userName = "Oleg";
            fontSize = 12;

            WriteRegistryValue(keypath, "UserName", userName);
            WriteRegistryValue(keypath, "FontSize", fontSize);

            Console.WriteLine("Настройки обновлены");

        }


        static T ReadRegistryValue<T>(string keyPath,string valueName,T defValue)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if(key!= null)
                {
                    object value = key.GetValue(valueName);
                    if(value != null)
                    {
                        return (T)Convert.ChangeType(value, typeof(T));
                    }
                }
            }

            return defValue;
        }

        static void WriteRegistryValue<T>(string keyPath, string valueName, T value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null) {

                    key.SetValue(valueName, value);
                }
            }

        }

    }
}
