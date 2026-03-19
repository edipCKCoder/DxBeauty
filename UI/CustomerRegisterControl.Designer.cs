namespace DXBeauty.UI
{
    partial class CustomerRegisterControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            birthdayBox = new DevExpress.XtraEditors.DateEdit();
            SaveButton = new DevExpress.XtraEditors.SimpleButton();
            nameBox = new DevExpress.XtraEditors.TextEdit();
            surnameBox = new DevExpress.XtraEditors.TextEdit();
            phoneBox = new DevExpress.XtraEditors.TextEdit();
            emailBox = new DevExpress.XtraEditors.TextEdit();
            addressBox = new DevExpress.XtraEditors.MemoEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)birthdayBox.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)birthdayBox.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameBox.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)surnameBox.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)phoneBox.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emailBox.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addressBox.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(birthdayBox);
            layoutControl1.Controls.Add(SaveButton);
            layoutControl1.Controls.Add(nameBox);
            layoutControl1.Controls.Add(surnameBox);
            layoutControl1.Controls.Add(phoneBox);
            layoutControl1.Controls.Add(emailBox);
            layoutControl1.Controls.Add(addressBox);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1104, 195, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(491, 336);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // birthdayBox
            // 
            birthdayBox.EditValue = null;
            birthdayBox.Location = new System.Drawing.Point(114, 120);
            birthdayBox.Name = "birthdayBox";
            birthdayBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            birthdayBox.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            birthdayBox.Size = new System.Drawing.Size(350, 20);
            birthdayBox.StyleController = layoutControl1;
            birthdayBox.TabIndex = 5;
            // 
            // SaveButton
            // 
            SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            SaveButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            SaveButton.ImageOptions.SvgImage = Properties.Resources.Save1;
            SaveButton.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            SaveButton.Location = new System.Drawing.Point(210, 273);
            SaveButton.MaximumSize = new System.Drawing.Size(70, 0);
            SaveButton.MinimumSize = new System.Drawing.Size(0, 25);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new System.Drawing.Size(70, 25);
            SaveButton.StyleController = layoutControl1;
            SaveButton.TabIndex = 7;
            SaveButton.Text = "Kaydet";
            SaveButton.Click += SaveButton_Click;
            // 
            // nameBox
            // 
            nameBox.Location = new System.Drawing.Point(114, 48);
            nameBox.Name = "nameBox";
            nameBox.Size = new System.Drawing.Size(128, 20);
            nameBox.StyleController = layoutControl1;
            nameBox.TabIndex = 0;
            // 
            // surnameBox
            // 
            surnameBox.Location = new System.Drawing.Point(296, 48);
            surnameBox.Name = "surnameBox";
            surnameBox.Size = new System.Drawing.Size(168, 20);
            surnameBox.StyleController = layoutControl1;
            surnameBox.TabIndex = 2;
            // 
            // phoneBox
            // 
            phoneBox.Location = new System.Drawing.Point(114, 72);
            phoneBox.Name = "phoneBox";
            phoneBox.Size = new System.Drawing.Size(350, 20);
            phoneBox.StyleController = layoutControl1;
            phoneBox.TabIndex = 3;
            // 
            // emailBox
            // 
            emailBox.Location = new System.Drawing.Point(114, 96);
            emailBox.Name = "emailBox";
            emailBox.Size = new System.Drawing.Size(350, 20);
            emailBox.StyleController = layoutControl1;
            emailBox.TabIndex = 4;
            // 
            // addressBox
            // 
            addressBox.Location = new System.Drawing.Point(114, 144);
            addressBox.Name = "addressBox";
            addressBox.Size = new System.Drawing.Size(350, 115);
            addressBox.StyleController = layoutControl1;
            addressBox.TabIndex = 6;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem8, layoutControlItem7, layoutControlItem5, layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(491, 336);
            Root.Spacing = new DevExpress.XtraLayout.Utils.Padding(15, 15, 15, 15);
            Root.Text = "Müşteri Kayıt";
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Control = birthdayBox;
            layoutControlItem8.Location = new System.Drawing.Point(0, 72);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.Size = new System.Drawing.Size(441, 24);
            layoutControlItem8.Text = "Doğum Tarihi :";
            layoutControlItem8.TextSize = new System.Drawing.Size(75, 13);
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem7.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem7.Control = SaveButton;
            layoutControlItem7.Location = new System.Drawing.Point(0, 215);
            layoutControlItem7.MaxSize = new System.Drawing.Size(74, 50);
            layoutControlItem7.MinSize = new System.Drawing.Size(64, 50);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new System.Drawing.Size(441, 50);
            layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = nameBox;
            layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(219, 24);
            layoutControlItem5.Text = "Müşteri İsmi :";
            layoutControlItem5.TextSize = new System.Drawing.Size(75, 13);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = surnameBox;
            layoutControlItem1.Location = new System.Drawing.Point(219, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(222, 24);
            layoutControlItem1.Text = "Soyisim :";
            layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            layoutControlItem1.TextSize = new System.Drawing.Size(50, 13);
            layoutControlItem1.TextToControlDistance = 0;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = phoneBox;
            layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(441, 24);
            layoutControlItem2.Text = "Telefon :";
            layoutControlItem2.TextSize = new System.Drawing.Size(75, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = emailBox;
            layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(441, 24);
            layoutControlItem3.Text = "E - Mail :";
            layoutControlItem3.TextSize = new System.Drawing.Size(75, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = addressBox;
            layoutControlItem4.Location = new System.Drawing.Point(0, 96);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(441, 119);
            layoutControlItem4.Text = "Müşteri Adresi :";
            layoutControlItem4.TextSize = new System.Drawing.Size(75, 13);
            // 
            // CustomerRegisterControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "CustomerRegisterControl";
            Size = new System.Drawing.Size(491, 336);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)birthdayBox.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)birthdayBox.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameBox.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)surnameBox.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)phoneBox.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)emailBox.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)addressBox.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit birthdayBox;
        private DevExpress.XtraEditors.SimpleButton SaveButton;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.TextEdit nameBox;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit surnameBox;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit phoneBox;
        private DevExpress.XtraEditors.TextEdit emailBox;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.MemoEdit addressBox;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
