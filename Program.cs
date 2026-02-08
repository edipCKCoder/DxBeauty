using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace DXBeauty {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            DevExpress.Skins.SkinManager.EnableFormSkins();
DevExpress.UserSkins.BonusSkins.Register();

            Application.Run(new MainForm());
        }
    }
}