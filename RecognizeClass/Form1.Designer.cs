namespace RecognizeClass
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RecognitionResultLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RecognitionPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LearningPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ImageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecognitionPictureBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LearningPictureBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 407);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.RecognitionResultLabel);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.RecognitionPictureBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(877, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recognition";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // RecognitionResultLabel
            // 
            this.RecognitionResultLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RecognitionResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RecognitionResultLabel.Location = new System.Drawing.Point(374, 47);
            this.RecognitionResultLabel.Name = "RecognitionResultLabel";
            this.RecognitionResultLabel.Size = new System.Drawing.Size(154, 323);
            this.RecognitionResultLabel.TabIndex = 2;
            this.RecognitionResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RecognitionPictureBox
            // 
            this.RecognitionPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RecognitionPictureBox.Location = new System.Drawing.Point(8, 6);
            this.RecognitionPictureBox.Name = "RecognitionPictureBox";
            this.RecognitionPictureBox.Size = new System.Drawing.Size(360, 364);
            this.RecognitionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RecognitionPictureBox.TabIndex = 0;
            this.RecognitionPictureBox.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.LearningPictureBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(877, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Learning";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(374, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = "Import";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(426, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(107, 22);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class:";
            // 
            // LearningPictureBox
            // 
            this.LearningPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LearningPictureBox.Location = new System.Drawing.Point(8, 6);
            this.LearningPictureBox.Name = "LearningPictureBox";
            this.LearningPictureBox.Size = new System.Drawing.Size(360, 364);
            this.LearningPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LearningPictureBox.TabIndex = 1;
            this.LearningPictureBox.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(877, 378);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Classes Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(871, 372);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 407);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Main Application";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RecognitionPictureBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LearningPictureBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox RecognitionPictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog ImageOpenFileDialog;
        private System.Windows.Forms.Label RecognitionResultLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox LearningPictureBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

