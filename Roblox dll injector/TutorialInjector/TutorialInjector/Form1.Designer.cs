namespace TutorialInjector
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
            this.InjectionButton = new System.Windows.Forms.Button();
            this.Label = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InjectionButton
            // 
            this.InjectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InjectionButton.Location = new System.Drawing.Point(60, 157);
            this.InjectionButton.Name = "InjectionButton";
            this.InjectionButton.Size = new System.Drawing.Size(108, 34);
            this.InjectionButton.TabIndex = 0;
            this.InjectionButton.Text = "Inject into roblox";
            this.InjectionButton.UseVisualStyleBackColor = true;
            this.InjectionButton.Click += new System.EventHandler(this.InjectionButton_Click);
            // 
            // Label
            // 
            this.Label.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label.Location = new System.Drawing.Point(0, 9);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(239, 37);
            this.Label.TabIndex = 1;
            this.Label.Text = "Injector";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Location = new System.Drawing.Point(205, 16);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(22, 23);
            this.ExitBtn.TabIndex = 2;
            this.ExitBtn.Text = "X";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(239, 203);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.InjectionButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Injector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InjectionButton;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Button ExitBtn;
    }
}

