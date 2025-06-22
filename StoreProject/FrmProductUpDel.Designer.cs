namespace StoreProject
{
    partial class FrmProductUpDel
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btProImage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pcbProImage = new System.Windows.Forms.PictureBox();
            this.rdoProStatusOff = new System.Windows.Forms.RadioButton();
            this.rdoProStatusOn = new System.Windows.Forms.RadioButton();
            this.btProUpdate = new System.Windows.Forms.Button();
            this.tbProUnit = new System.Windows.Forms.TextBox();
            this.tbProPrice = new System.Windows.Forms.TextBox();
            this.nudProQuan = new System.Windows.Forms.NumericUpDown();
            this.tbProName = new System.Windows.Forms.TextBox();
            this.btProDelete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbProImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProQuan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gold;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "แก้ไข/ลบสินค้า";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btProImage
            // 
            this.btProImage.Location = new System.Drawing.Point(274, 182);
            this.btProImage.Name = "btProImage";
            this.btProImage.Size = new System.Drawing.Size(24, 23);
            this.btProImage.TabIndex = 19;
            this.btProImage.Text = "...";
            this.btProImage.UseVisualStyleBackColor = true;
            this.btProImage.Click += new System.EventHandler(this.btProImage_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pcbProImage);
            this.panel1.Location = new System.Drawing.Point(134, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 128);
            this.panel1.TabIndex = 18;
            // 
            // pcbProImage
            // 
            this.pcbProImage.Location = new System.Drawing.Point(3, 3);
            this.pcbProImage.Name = "pcbProImage";
            this.pcbProImage.Size = new System.Drawing.Size(125, 120);
            this.pcbProImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbProImage.TabIndex = 2;
            this.pcbProImage.TabStop = false;
            // 
            // rdoProStatusOff
            // 
            this.rdoProStatusOff.AutoSize = true;
            this.rdoProStatusOff.Location = new System.Drawing.Point(243, 385);
            this.rdoProStatusOff.Name = "rdoProStatusOff";
            this.rdoProStatusOff.Size = new System.Drawing.Size(83, 17);
            this.rdoProStatusOff.TabIndex = 32;
            this.rdoProStatusOff.Text = "ไม่พร้อมขาย";
            this.rdoProStatusOff.UseVisualStyleBackColor = true;
            // 
            // rdoProStatusOn
            // 
            this.rdoProStatusOn.AutoSize = true;
            this.rdoProStatusOn.Checked = true;
            this.rdoProStatusOn.Location = new System.Drawing.Point(134, 385);
            this.rdoProStatusOn.Name = "rdoProStatusOn";
            this.rdoProStatusOn.Size = new System.Drawing.Size(70, 17);
            this.rdoProStatusOn.TabIndex = 31;
            this.rdoProStatusOn.TabStop = true;
            this.rdoProStatusOn.Text = "พร้อมขาย";
            this.rdoProStatusOn.UseVisualStyleBackColor = true;
            // 
            // btProUpdate
            // 
            this.btProUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProUpdate.Image = global::StoreProject.Properties.Resources.save;
            this.btProUpdate.Location = new System.Drawing.Point(210, 423);
            this.btProUpdate.Name = "btProUpdate";
            this.btProUpdate.Size = new System.Drawing.Size(132, 38);
            this.btProUpdate.TabIndex = 30;
            this.btProUpdate.Text = "บันทึกสินค้า";
            this.btProUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btProUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btProUpdate.UseVisualStyleBackColor = true;
            this.btProUpdate.Click += new System.EventHandler(this.btProUpdate_Click);
            // 
            // tbProUnit
            // 
            this.tbProUnit.Location = new System.Drawing.Point(134, 347);
            this.tbProUnit.Name = "tbProUnit";
            this.tbProUnit.Size = new System.Drawing.Size(208, 20);
            this.tbProUnit.TabIndex = 29;
            // 
            // tbProPrice
            // 
            this.tbProPrice.Location = new System.Drawing.Point(134, 285);
            this.tbProPrice.Name = "tbProPrice";
            this.tbProPrice.Size = new System.Drawing.Size(208, 20);
            this.tbProPrice.TabIndex = 28;
            // 
            // nudProQuan
            // 
            this.nudProQuan.Location = new System.Drawing.Point(134, 317);
            this.nudProQuan.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudProQuan.Name = "nudProQuan";
            this.nudProQuan.Size = new System.Drawing.Size(208, 20);
            this.nudProQuan.TabIndex = 27;
            // 
            // tbProName
            // 
            this.tbProName.Location = new System.Drawing.Point(134, 253);
            this.tbProName.Name = "tbProName";
            this.tbProName.Size = new System.Drawing.Size(208, 20);
            this.tbProName.TabIndex = 26;
            // 
            // btProDelete
            // 
            this.btProDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProDelete.Image = global::StoreProject.Properties.Resources.cancel;
            this.btProDelete.Location = new System.Drawing.Point(56, 423);
            this.btProDelete.Name = "btProDelete";
            this.btProDelete.Size = new System.Drawing.Size(132, 38);
            this.btProDelete.TabIndex = 25;
            this.btProDelete.Text = "ยกเลิก";
            this.btProDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btProDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btProDelete.UseVisualStyleBackColor = true;
            this.btProDelete.Click += new System.EventHandler(this.btProDelete_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "สถานะสินค้า";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "หน่วยสินค้า";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "จำนวนสินค้า";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "ราคาสินค้า";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "ขื่อสินค้า";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbProId
            // 
            this.tbProId.Location = new System.Drawing.Point(134, 222);
            this.tbProId.Name = "tbProId";
            this.tbProId.ReadOnly = true;
            this.tbProId.Size = new System.Drawing.Size(208, 20);
            this.tbProId.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 33;
            this.label7.Text = "รหัสสินค้า";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmProductUpDel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 481);
            this.Controls.Add(this.tbProId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rdoProStatusOff);
            this.Controls.Add(this.rdoProStatusOn);
            this.Controls.Add(this.btProUpdate);
            this.Controls.Add(this.tbProUnit);
            this.Controls.Add(this.tbProPrice);
            this.Controls.Add(this.nudProQuan);
            this.Controls.Add(this.tbProName);
            this.Controls.Add(this.btProDelete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btProImage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FrmProductUpDel";
            this.Text = "FrmProductUpDel";
            this.Load += new System.EventHandler(this.FrmProductUpDel_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbProImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProQuan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btProImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pcbProImage;
        private System.Windows.Forms.RadioButton rdoProStatusOff;
        private System.Windows.Forms.RadioButton rdoProStatusOn;
        private System.Windows.Forms.Button btProUpdate;
        private System.Windows.Forms.TextBox tbProUnit;
        private System.Windows.Forms.TextBox tbProPrice;
        private System.Windows.Forms.NumericUpDown nudProQuan;
        private System.Windows.Forms.TextBox tbProName;
        private System.Windows.Forms.Button btProDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbProId;
        private System.Windows.Forms.Label label7;
    }
}