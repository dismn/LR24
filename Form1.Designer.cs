
namespace LR24
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.start1 = new System.Windows.Forms.Button();
            this.stop1 = new System.Windows.Forms.Button();
            this.start2 = new System.Windows.Forms.Button();
            this.stop2 = new System.Windows.Forms.Button();
            this.start3 = new System.Windows.Forms.Button();
            this.stop3 = new System.Windows.Forms.Button();
            this.startall = new System.Windows.Forms.Button();
            this.stopall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 15);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(237, 295);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(286, 15);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(237, 295);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(551, 15);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(237, 295);
            this.richTextBox3.TabIndex = 2;
            this.richTextBox3.Text = "";
            // 
            // start1
            // 
            this.start1.BackColor = System.Drawing.Color.PaleGreen;
            this.start1.Location = new System.Drawing.Point(25, 316);
            this.start1.Name = "start1";
            this.start1.Size = new System.Drawing.Size(235, 31);
            this.start1.TabIndex = 3;
            this.start1.Text = "Запустити 1 поток";
            this.start1.UseVisualStyleBackColor = false;
            this.start1.Click += new System.EventHandler(this.start1_Click);
            // 
            // stop1
            // 
            this.stop1.BackColor = System.Drawing.Color.LightCoral;
            this.stop1.Location = new System.Drawing.Point(26, 350);
            this.stop1.Name = "stop1";
            this.stop1.Size = new System.Drawing.Size(235, 29);
            this.stop1.TabIndex = 4;
            this.stop1.Text = "Зупинити 1 поток";
            this.stop1.UseVisualStyleBackColor = false;
            this.stop1.Click += new System.EventHandler(this.stop1_Click);
            // 
            // start2
            // 
            this.start2.BackColor = System.Drawing.Color.PaleGreen;
            this.start2.Location = new System.Drawing.Point(286, 316);
            this.start2.Name = "start2";
            this.start2.Size = new System.Drawing.Size(235, 31);
            this.start2.TabIndex = 5;
            this.start2.Text = "Запустити 2 поток";
            this.start2.UseVisualStyleBackColor = false;
            this.start2.Click += new System.EventHandler(this.start2_Click);
            // 
            // stop2
            // 
            this.stop2.BackColor = System.Drawing.Color.LightCoral;
            this.stop2.Location = new System.Drawing.Point(286, 353);
            this.stop2.Name = "stop2";
            this.stop2.Size = new System.Drawing.Size(235, 26);
            this.stop2.TabIndex = 6;
            this.stop2.Text = "Зупинити 2 поток";
            this.stop2.UseVisualStyleBackColor = false;
            this.stop2.Click += new System.EventHandler(this.stop2_Click);
            // 
            // start3
            // 
            this.start3.BackColor = System.Drawing.Color.PaleGreen;
            this.start3.Location = new System.Drawing.Point(551, 316);
            this.start3.Name = "start3";
            this.start3.Size = new System.Drawing.Size(235, 31);
            this.start3.TabIndex = 7;
            this.start3.Text = "Запустити 3 поток";
            this.start3.UseVisualStyleBackColor = false;
            this.start3.Click += new System.EventHandler(this.start3_Click);
            // 
            // stop3
            // 
            this.stop3.BackColor = System.Drawing.Color.LightCoral;
            this.stop3.Location = new System.Drawing.Point(551, 353);
            this.stop3.Name = "stop3";
            this.stop3.Size = new System.Drawing.Size(235, 26);
            this.stop3.TabIndex = 8;
            this.stop3.Text = "Зупинити 3 поток";
            this.stop3.UseVisualStyleBackColor = false;
            this.stop3.Click += new System.EventHandler(this.stop3_Click);
            // 
            // startall
            // 
            this.startall.BackColor = System.Drawing.Color.PaleGreen;
            this.startall.Location = new System.Drawing.Point(286, 381);
            this.startall.Name = "startall";
            this.startall.Size = new System.Drawing.Size(235, 29);
            this.startall.TabIndex = 9;
            this.startall.Text = "Запустити усі потоки";
            this.startall.UseVisualStyleBackColor = false;
            this.startall.Click += new System.EventHandler(this.startall_Click);
            // 
            // stopall
            // 
            this.stopall.BackColor = System.Drawing.Color.LightCoral;
            this.stopall.Location = new System.Drawing.Point(286, 416);
            this.stopall.Name = "stopall";
            this.stopall.Size = new System.Drawing.Size(235, 29);
            this.stopall.TabIndex = 10;
            this.stopall.Text = "Зупинити усі потоки";
            this.stopall.UseVisualStyleBackColor = false;
            this.stopall.Click += new System.EventHandler(this.stopall_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stopall);
            this.Controls.Add(this.startall);
            this.Controls.Add(this.stop3);
            this.Controls.Add(this.start3);
            this.Controls.Add(this.stop2);
            this.Controls.Add(this.start2);
            this.Controls.Add(this.stop1);
            this.Controls.Add(this.start1);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Button start1;
        private System.Windows.Forms.Button stop1;
        private System.Windows.Forms.Button start2;
        private System.Windows.Forms.Button stop2;
        private System.Windows.Forms.Button start3;
        private System.Windows.Forms.Button stop3;
        private System.Windows.Forms.Button startall;
        private System.Windows.Forms.Button stopall;
    }
}

