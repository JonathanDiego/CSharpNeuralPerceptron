namespace Neural1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lLog = new System.Windows.Forms.ListBox();
            this.lLog2 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbTest = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pbTest2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbresult = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.meTrain = new System.Windows.Forms.MaskedTextBox();
            this.lacc = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTest2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(527, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Train";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Log";
            // 
            // lLog
            // 
            this.lLog.FormattingEnabled = true;
            this.lLog.Location = new System.Drawing.Point(15, 24);
            this.lLog.Name = "lLog";
            this.lLog.Size = new System.Drawing.Size(250, 303);
            this.lLog.TabIndex = 15;
            // 
            // lLog2
            // 
            this.lLog2.FormattingEnabled = true;
            this.lLog2.Location = new System.Drawing.Point(271, 25);
            this.lLog2.Name = "lLog2";
            this.lLog2.Size = new System.Drawing.Size(250, 329);
            this.lLog2.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(527, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(527, 54);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(181, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Create";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.lacc);
            this.panel1.Controls.Add(this.meTrain);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbresult);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.pbTest2);
            this.panel1.Controls.Add(this.pbTest);
            this.panel1.Location = new System.Drawing.Point(527, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 175);
            this.panel1.TabIndex = 17;
            // 
            // pbTest
            // 
            this.pbTest.BackColor = System.Drawing.Color.Black;
            this.pbTest.Location = new System.Drawing.Point(121, 112);
            this.pbTest.Name = "pbTest";
            this.pbTest.Size = new System.Drawing.Size(28, 28);
            this.pbTest.TabIndex = 18;
            this.pbTest.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(121, 59);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 27);
            this.button4.TabIndex = 3;
            this.button4.Text = "Test";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(121, 87);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(58, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pbTest2
            // 
            this.pbTest2.BackColor = System.Drawing.Color.Black;
            this.pbTest2.Location = new System.Drawing.Point(3, 59);
            this.pbTest2.Name = "pbTest2";
            this.pbTest2.Size = new System.Drawing.Size(112, 112);
            this.pbTest2.TabIndex = 19;
            this.pbTest2.TabStop = false;
            this.pbTest2.DoubleClick += new System.EventHandler(this.pbTest2_DoubleClick);
            this.pbTest2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbTest2_MouseClick);
            this.pbTest2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbTest2_MouseDown);
            this.pbTest2.MouseLeave += new System.EventHandler(this.pbTest2_MouseLeave);
            this.pbTest2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbTest2_MouseMove);
            this.pbTest2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbTest2_MouseUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SeaGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 36);
            this.label1.TabIndex = 24;
            this.label1.Text = "Result:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbresult
            // 
            this.lbresult.BackColor = System.Drawing.Color.SeaGreen;
            this.lbresult.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbresult.Location = new System.Drawing.Point(119, 3);
            this.lbresult.Name = "lbresult";
            this.lbresult.Size = new System.Drawing.Size(60, 36);
            this.lbresult.TabIndex = 23;
            this.lbresult.Text = "XX";
            this.lbresult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(121, 144);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(57, 27);
            this.button6.TabIndex = 25;
            this.button6.Text = "Train";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // meTrain
            // 
            this.meTrain.Location = new System.Drawing.Point(154, 120);
            this.meTrain.Mask = "0";
            this.meTrain.Name = "meTrain";
            this.meTrain.Size = new System.Drawing.Size(24, 20);
            this.meTrain.TabIndex = 26;
            this.meTrain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lacc
            // 
            this.lacc.BackColor = System.Drawing.Color.SeaGreen;
            this.lacc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lacc.Location = new System.Drawing.Point(3, 39);
            this.lacc.Name = "lacc";
            this.lacc.Size = new System.Drawing.Size(176, 17);
            this.lacc.TabIndex = 27;
            this.lacc.Text = "acc:";
            this.lacc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(527, 112);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(181, 23);
            this.button7.TabIndex = 18;
            this.button7.Text = "Save";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(527, 141);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(181, 23);
            this.button8.TabIndex = 19;
            this.button8.Text = "Load";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(15, 331);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(250, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Convolution";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 363);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lLog2);
            this.Controls.Add(this.lLog);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTest2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lLog;
        private System.Windows.Forms.ListBox lLog2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pbTest;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pbTest2;
        private System.Windows.Forms.MaskedTextBox meTrain;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbresult;
        private System.Windows.Forms.Label lacc;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

