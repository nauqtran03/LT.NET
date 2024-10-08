namespace vidu3
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbNhap = new System.Windows.Forms.TextBox();
            this.btnNhap = new System.Windows.Forms.Button();
            this.lsHienthi = new System.Windows.Forms.ListBox();
            this.tbTong = new System.Windows.Forms.TextBox();
            this.btnXoadc = new System.Windows.Forms.Button();
            this.btnXoatatca = new System.Windows.Forms.Button();
            this.btnXoadau = new System.Windows.Forms.Button();
            this.btnXoacuoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(341, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tổng số người đã khai báo";
            // 
            // tbNhap
            // 
            this.tbNhap.Location = new System.Drawing.Point(107, 45);
            this.tbNhap.Name = "tbNhap";
            this.tbNhap.Size = new System.Drawing.Size(213, 20);
            this.tbNhap.TabIndex = 2;
            // 
            // btnNhap
            // 
            this.btnNhap.Location = new System.Drawing.Point(107, 81);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(168, 22);
            this.btnNhap.TabIndex = 3;
            this.btnNhap.Text = "Nhập thông tin ";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // lsHienthi
            // 
            this.lsHienthi.FormattingEnabled = true;
            this.lsHienthi.Location = new System.Drawing.Point(344, 48);
            this.lsHienthi.Name = "lsHienthi";
            this.lsHienthi.Size = new System.Drawing.Size(397, 173);
            this.lsHienthi.TabIndex = 4;
            // 
            // tbTong
            // 
            this.tbTong.Location = new System.Drawing.Point(545, 245);
            this.tbTong.Name = "tbTong";
            this.tbTong.Size = new System.Drawing.Size(133, 20);
            this.tbTong.TabIndex = 5;
            // 
            // btnXoadc
            // 
            this.btnXoadc.Location = new System.Drawing.Point(344, 288);
            this.btnXoadc.Name = "btnXoadc";
            this.btnXoadc.Size = new System.Drawing.Size(146, 23);
            this.btnXoadc.TabIndex = 6;
            this.btnXoadc.Text = "Xóa thông tin đã chọn";
            this.btnXoadc.UseVisualStyleBackColor = true;
            this.btnXoadc.Click += new System.EventHandler(this.btnXoadc_Click);
            // 
            // btnXoatatca
            // 
            this.btnXoatatca.Location = new System.Drawing.Point(344, 332);
            this.btnXoatatca.Name = "btnXoatatca";
            this.btnXoatatca.Size = new System.Drawing.Size(146, 23);
            this.btnXoatatca.TabIndex = 7;
            this.btnXoatatca.Text = "Xóa tất cả thông tin ";
            this.btnXoatatca.UseVisualStyleBackColor = true;
            this.btnXoatatca.Click += new System.EventHandler(this.btnXoatatca_Click);
            // 
            // btnXoadau
            // 
            this.btnXoadau.Location = new System.Drawing.Point(532, 288);
            this.btnXoadau.Name = "btnXoadau";
            this.btnXoadau.Size = new System.Drawing.Size(146, 23);
            this.btnXoadau.TabIndex = 8;
            this.btnXoadau.Text = "Xóa thông tin ban đầu ";
            this.btnXoadau.UseVisualStyleBackColor = true;
            this.btnXoadau.Click += new System.EventHandler(this.btnXoadau_Click);
            // 
            // btnXoacuoi
            // 
            this.btnXoacuoi.Location = new System.Drawing.Point(532, 332);
            this.btnXoacuoi.Name = "btnXoacuoi";
            this.btnXoacuoi.Size = new System.Drawing.Size(146, 23);
            this.btnXoacuoi.TabIndex = 9;
            this.btnXoacuoi.Text = "Xóa thông tin cuối ";
            this.btnXoacuoi.UseVisualStyleBackColor = true;
            this.btnXoacuoi.Click += new System.EventHandler(this.btnXoacuoi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXoacuoi);
            this.Controls.Add(this.btnXoadau);
            this.Controls.Add(this.btnXoatatca);
            this.Controls.Add(this.btnXoadc);
            this.Controls.Add(this.tbTong);
            this.Controls.Add(this.lsHienthi);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.tbNhap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNhap;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.ListBox lsHienthi;
        private System.Windows.Forms.TextBox tbTong;
        private System.Windows.Forms.Button btnXoadc;
        private System.Windows.Forms.Button btnXoatatca;
        private System.Windows.Forms.Button btnXoadau;
        private System.Windows.Forms.Button btnXoacuoi;
    }
}

