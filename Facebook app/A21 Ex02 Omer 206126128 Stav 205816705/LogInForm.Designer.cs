namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public partial class LogInForm
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
            this.EmailLabel = new System.Windows.Forms.Label();
            this.WelcomeLable = new System.Windows.Forms.Label();
            this.LogInBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EmailLabel
            // 
            this.EmailLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.EmailLabel.Location = new System.Drawing.Point(168, 376);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(759, 65);
            this.EmailLabel.TabIndex = 0;
            // 
            // WelcomeLable
            // 
            this.WelcomeLable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WelcomeLable.AutoSize = true;
            this.WelcomeLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.WelcomeLable.Location = new System.Drawing.Point(104, 121);
            this.WelcomeLable.Name = "WelcomeLable";
            this.WelcomeLable.Size = new System.Drawing.Size(739, 55);
            this.WelcomeLable.TabIndex = 2;
            this.WelcomeLable.Text = "Welcome to Facebook Extentions";
            // 
            // LogInBtn
            // 
            this.LogInBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LogInBtn.BackgroundImage = global::A21_Ex02_Omer_206126128_Stav_205816705.Properties.Resources.ContinueWithFacebook;
            this.LogInBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogInBtn.Location = new System.Drawing.Point(137, 268);
            this.LogInBtn.Name = "LogInBtn";
            this.LogInBtn.Size = new System.Drawing.Size(631, 119);
            this.LogInBtn.TabIndex = 1;
            this.LogInBtn.UseVisualStyleBackColor = true;
            this.LogInBtn.Click += new System.EventHandler(this.LogInBtn_Click);
            // 
            // LogInForm
            // 
            this.ClientSize = new System.Drawing.Size(913, 493);
            this.Controls.Add(this.WelcomeLable);
            this.Controls.Add(this.LogInBtn);
            this.Controls.Add(this.EmailLabel);
            this.Name = "LogInForm";
            this.SizeChanged += new System.EventHandler(this.LogInForm_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label EmailLable;
        private System.Windows.Forms.Label PasswordLable;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Button LogInBtn;
        private System.Windows.Forms.Label WelcomeLable;
    }
}