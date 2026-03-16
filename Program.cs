using DevExpress.LookAndFeel;
using DevExpress.Skins;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace DXBeauty {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 1. GLOBAL ZIRH: Kullanıcı arayüzünde (UI) oluşan beklenmedik hataları yakalar
            Application.ThreadException += new ThreadExceptionEventHandler(Global_ThreadException);

            // 2. GLOBAL ZIRH: Arka plan işlemlerinde (Threads) oluşan hataları yakalar
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Global_UnhandledException);



            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            // 1. Kaydedilmiş tema ve palet isimlerini Settings'ten oku
            string savedSkin = Properties.Settings.Default.SkinName;
            string savedPalette = Properties.Settings.Default.PaletteName;

            // 2. DevExpress'e temayı uygula
            // MANTIK 1: Önce mutlaka bir Skin (Ana Tema) kaydedilmiş mi diye bakıyoruz!
            if (!string.IsNullOrEmpty(savedSkin))
            {
                // MANTIK 2: Ana tema var. Peki buna bağlı bir SVG renk paleti seçilmiş mi?
                if (!string.IsNullOrEmpty(savedPalette))
                {
                    // Hem tema hem palet seçilmiş (Örn: "WXI" teması ve "Clearness" paleti)
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(savedSkin, savedPalette);
                }
                else
                {
                    // Palet yok, sadece standart bir tema seçilmiş (Örn: "Office 2019 Colorful")
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(savedSkin);
                }
            }
            // else durumu: Eğer savedSkin boş gelirse, DevExpress zaten kendi varsayılanını (Basic vb.) açacaktır, müdahaleye gerek yok.

            Application.Run(new MainForm());
        }
       
        private static void Global_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            DevExpress.XtraEditors.XtraMessageBox.Show(
                "Uygulamada kritik bir hata oluştu.\n\nDetay: " + ex.Message,
                "Kritik Hata",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        // GLOBAL ZIRHIN ÇALIŞACAĞI METODLAR 
        private static void Global_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Burada ileride hatayı bir .txt dosyasına (Log) kaydedeceğiz.
            DevExpress.XtraEditors.XtraMessageBox.Show(
                "İşlem sırasında beklenmeyen bir hata oluştu.\n\nDetay: " + e.Exception.Message,
                "Sistem Uyarı",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}