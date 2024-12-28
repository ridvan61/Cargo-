namespace kargotest1
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblsifre = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.btngiris = new System.Windows.Forms.Button();
            this.txt_GonderenTCno = new System.Windows.Forms.TextBox();
            this.sifre = new System.Windows.Forms.TextBox();
            this.TCHatasi = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TCHatasi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.lblsifre);
            this.groupBox1.Controls.Add(this.lblid);
            this.groupBox1.Controls.Add(this.btngiris);
            this.groupBox1.Controls.Add(this.txt_GonderenTCno);
            this.groupBox1.Controls.Add(this.sifre);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(96, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 359);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sisteme Giriş Yapınız...";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(318, 214);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Şifreyi Göster";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblsifre
            // 
            this.lblsifre.AutoSize = true;
            this.lblsifre.Location = new System.Drawing.Point(159, 185);
            this.lblsifre.Name = "lblsifre";
            this.lblsifre.Size = new System.Drawing.Size(28, 13);
            this.lblsifre.TabIndex = 4;
            this.lblsifre.Text = "Şifre";
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(159, 120);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(21, 13);
            this.lblid.TabIndex = 3;
            this.lblid.Text = "TC";
            // 
            // btngiris
            // 
            this.btngiris.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btngiris.Location = new System.Drawing.Point(175, 255);
            this.btngiris.Name = "btngiris";
            this.btngiris.Size = new System.Drawing.Size(104, 43);
            this.btngiris.TabIndex = 2;
            this.btngiris.Text = "Giriş Yap";
            this.btngiris.UseVisualStyleBackColor = true;
            this.btngiris.Click += new System.EventHandler(this.btngiris_Click);
            // 
            // txt_GonderenTCno
            // 
            this.txt_GonderenTCno.Location = new System.Drawing.Point(152, 145);
            this.txt_GonderenTCno.MaxLength = 11;
            this.txt_GonderenTCno.Name = "txt_GonderenTCno";
            this.txt_GonderenTCno.Size = new System.Drawing.Size(160, 20);
            this.txt_GonderenTCno.TabIndex = 0;
            this.txt_GonderenTCno.TextChanged += new System.EventHandler(this.txt_GonderenTCno_TextChanged);
            this.txt_GonderenTCno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_GonderenTCno_KeyPress);
            this.txt_GonderenTCno.Leave += new System.EventHandler(this.txt_GonderenTCno_Leave);
            // 
            // sifre
            // 
            this.sifre.Location = new System.Drawing.Point(152, 211);
            this.sifre.MaxLength = 30;
            this.sifre.Name = "sifre";
            this.sifre.PasswordChar = '*';
            this.sifre.Size = new System.Drawing.Size(160, 20);
            this.sifre.TabIndex = 1;
            // 
            // TCHatasi
            // 
            this.TCHatasi.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(678, 523);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TCHatasi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblsifre;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Button btngiris;
        private System.Windows.Forms.TextBox txt_GonderenTCno;
        private System.Windows.Forms.TextBox sifre;
        private System.Windows.Forms.ErrorProvider TCHatasi;
    }
}

