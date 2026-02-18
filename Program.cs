using DevExpress.LookAndFeel;
using DevExpress.Skins;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DXBeauty {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

          
          
            Application.SetCompatibleTextRenderingDefault(false);

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;


            Application.Run(new MainForm());
        }
    }
}