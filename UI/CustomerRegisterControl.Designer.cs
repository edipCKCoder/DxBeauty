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
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            addressBox = new System.Windows.Forms.RichTextBox();
            birthdayBox = new DevExpress.XtraEditors.DateEdit();
            emailBox = new System.Windows.Forms.TextBox();
            phoneBox = new System.Windows.Forms.TextBox();
            surnameBox = new System.Windows.Forms.TextBox();
            nameBox = new System.Windows.Forms.TextBox();
            SaveButton = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)birthdayBox.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)birthdayBox.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(layoutControl1);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(0, 0);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(1069, 634);
            groupControl1.TabIndex = 1;
            groupControl1.Text = "Customer İnformations";
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(addressBox);
            layoutControl1.Controls.Add(birthdayBox);
            layoutControl1.Controls.Add(emailBox);
            layoutControl1.Controls.Add(phoneBox);
            layoutControl1.Controls.Add(surnameBox);
            layoutControl1.Controls.Add(nameBox);
            layoutControl1.Controls.Add(SaveButton);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(2, 23);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1104, 195, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(1065, 609);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // addressBox
            // 
            addressBox.Location = new System.Drawing.Point(12, 124);
            addressBox.MaximumSize = new System.Drawing.Size(0, 100);
            addressBox.Name = "addressBox";
            addressBox.Size = new System.Drawing.Size(1041, 100);
            addressBox.TabIndex = 6;
            addressBox.Text = "";
            // 
            // birthdayBox
            // 
            birthdayBox.EditValue = null;
            birthdayBox.Location = new System.Drawing.Point(66, 84);
            birthdayBox.Name = "birthdayBox";
            birthdayBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            birthdayBox.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            birthdayBox.Size = new System.Drawing.Size(987, 20);
            birthdayBox.StyleController = layoutControl1;
            birthdayBox.TabIndex = 5;
            // 
            // emailBox
            // 
            emailBox.Location = new System.Drawing.Point(66, 60);
            emailBox.Margin = new System.Windows.Forms.Padding(5);
            emailBox.Name = "emailBox";
            emailBox.Size = new System.Drawing.Size(987, 20);
            emailBox.TabIndex = 4;
            // 
            // phoneBox
            // 
            phoneBox.Location = new System.Drawing.Point(66, 36);
            phoneBox.Name = "phoneBox";
            phoneBox.Size = new System.Drawing.Size(987, 20);
            phoneBox.TabIndex = 3;
            // 
            // surnameBox
            // 
            surnameBox.Location = new System.Drawing.Point(586, 12);
            surnameBox.Name = "surnameBox";
            surnameBox.Size = new System.Drawing.Size(467, 20);
            surnameBox.TabIndex = 2;
            // 
            // nameBox
            // 
            nameBox.Location = new System.Drawing.Point(66, 12);
            nameBox.Name = "nameBox";
            nameBox.Size = new System.Drawing.Size(462, 20);
            nameBox.TabIndex = 0;
            // 
            // SaveButton
            // 
            SaveButton.Location = new System.Drawing.Point(12, 228);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new System.Drawing.Size(1041, 22);
            SaveButton.StyleController = layoutControl1;
            SaveButton.TabIndex = 7;
            SaveButton.Text = "Save";
            SaveButton.Click += SaveButton_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem3, layoutControlItem4, layoutControlItem2, layoutControlItem8, layoutControlItem6, layoutControlItem7 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(1065, 609);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = nameBox;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(520, 24);
            layoutControlItem1.Text = "Name";
            layoutControlItem1.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = phoneBox;
            layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(1045, 24);
            layoutControlItem3.Text = "Phone";
            layoutControlItem3.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = emailBox;
            layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(1045, 24);
            layoutControlItem4.Text = "e-Mail";
            layoutControlItem4.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = surnameBox;
            layoutControlItem2.Location = new System.Drawing.Point(520, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(525, 24);
            layoutControlItem2.Text = "Surname";
            layoutControlItem2.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Control = birthdayBox;
            layoutControlItem8.Location = new System.Drawing.Point(0, 72);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.Size = new System.Drawing.Size(1045, 24);
            layoutControlItem8.Text = "Birthday";
            layoutControlItem8.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = addressBox;
            layoutControlItem6.Location = new System.Drawing.Point(0, 96);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new System.Drawing.Size(1045, 120);
            layoutControlItem6.Text = "Address";
            layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem6.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = SaveButton;
            layoutControlItem7.Location = new System.Drawing.Point(0, 216);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new System.Drawing.Size(1045, 373);
            layoutControlItem7.TextVisible = false;
            // 
            // CustomerRegisterControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupControl1);
            Name = "CustomerRegisterControl";
            Size = new System.Drawing.Size(1069, 634);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)birthdayBox.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)birthdayBox.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.RichTextBox addressBox;
        private DevExpress.XtraEditors.DateEdit birthdayBox;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.TextBox surnameBox;
        private System.Windows.Forms.TextBox nameBox;
        private DevExpress.XtraEditors.SimpleButton SaveButton;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}
