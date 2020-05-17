
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace LocalStorage
{
    public class Settings
    {
        #region Setting Constants


        private  static string SettingsKey = "settings_key";
        private static string UsersKey = "users_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion

        private static ISettings getSetting => CrossSettings.Current;//  Androidde shared yapisini Iosda ise userdata yapisini dondurur bu kod bize

        public static string GeneralSettings
        {
           
            get => getSetting.GetValueOrDefault(SettingsKey,SettingsDefault);

            set => getSetting.AddOrUpdateValue(SettingsKey, value);
        }

        public static void Delete()
        {
            getSetting.Remove(SettingsKey);
            getSetting.Remove(UsersKey);
        }
        public static Personal CurrentUser
        {
            get
            {
                Personal user = null;
                var serializedUser = getSetting.GetValueOrDefault(UsersKey, SettingsDefault);
                if (serializedUser != null)
                {
                    user = JsonConvert.DeserializeObject<Personal>(serializedUser);
                }

                return user;
            }
            set
            {
                CrossSettings.Current.AddOrUpdateValue(UsersKey, JsonConvert.SerializeObject(value));
            }
        }
    }

}

