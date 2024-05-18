
namespace BookMS
{
    partial class Usernews
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Font = new System.Drawing.Font("宋体", 14F);
            this.button1.Location = new System.Drawing.Point(550, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(212, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(212, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓  名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.Location = new System.Drawing.Point(212, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "年  龄：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14F);
            this.label5.Location = new System.Drawing.Point(212, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "级  别：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14F);
            this.label6.Location = new System.Drawing.Point(305, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "NILL";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 14F);
            this.label10.Location = new System.Drawing.Point(305, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 19);
            this.label10.TabIndex = 10;
            this.label10.Text = "NILL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 14F);
            this.label9.Location = new System.Drawing.Point(305, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 9;
            this.label9.Text = "NILL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14F);
            this.label7.Location = new System.Drawing.Point(305, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "NILL";
            // 
            // Usernews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Usernews";
            this.Text = "个人信息";
            this.Load += new System.EventHandler(this.Usernews_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
    }
}