using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using Lab6_7.Settings;

namespace Lab6_7
{
    
    public partial class App : Application
    {
       private static Theme theme;
        private static Language language;
       public static Theme Theme
           {
               get => theme ?? (theme = new Theme());
           }
            public static Language Language
            {
                get => language ?? (language = new Language());
            }


            public App()
            {
                InitializeComponent();
            }
        
    }
}
