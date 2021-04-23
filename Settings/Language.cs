using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;
using System.Windows;

namespace Lab6_7.Settings
{
    public class Language
    {
        private List<CultureInfo> languages = new List<CultureInfo>();
        public List<CultureInfo> Languages
        {
            get => languages;
        }

        public Language()
        {
            LanguageChanged += AppLanguageChanged;

            languages.Add(new CultureInfo("en-US"));
            languages.Add(new CultureInfo("ru-RU"));

            Name = Lab6_7.Properties.Settings.Default.DefaultLanguage;
        }

        public event EventHandler LanguageChanged;

        public CultureInfo Name
        {
            get => System.Threading.Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                ResourceDictionary dict = new ResourceDictionary();
                switch (value.Name)
                {
                    case "ru-RU":
                        dict.Source = new Uri(String.Format("Resources/lang.{0}.xaml", value.Name), UriKind.Relative);
                        break;
                    default:
                        dict.Source = new Uri("Resources/lang.xaml", UriKind.Relative);
                        break;
                }

                App.Current.Resources.MergedDictionaries.Add(dict);
                LanguageChanged(App.Current, new EventArgs());
            }
        }


        private void AppLanguageChanged(Object sender, EventArgs e)
        {
            Lab6_7.Properties.Settings.Default.DefaultLanguage = Name;
            Lab6_7.Properties.Settings.Default.Save();
        }
    }
}
