namespace flappiebird {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlgame = new System.Windows.Forms.Panel();
            this.tmrgame = new System.Windows.Forms.Timer(this.components);
            this.tmrachtergrond = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(734, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "NEW GAME";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pnlgame
            // 
            this.pnlgame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlgame.Location = new System.Drawing.Point(12, 81);
            this.pnlgame.Name = "pnlgame";
            this.pnlgame.Size = new System.Drawing.Size(734, 528);
            this.pnlgame.TabIndex = 1;
            this.pnlgame.Click += new System.EventHandler(this.stijgen);
            this.pnlgame.Paint += new System.Windows.Forms.PaintEventHandler(this.allesWeergeven);
            // 
            // tmrgame
            // 
            this.tmrgame.Tick += new System.EventHandler(this.Tmrgame_Tick);
            // 
            // tmrachtergrond
            // 
            this.tmrachtergrond.Tick += new System.EventHandler(this.Tmrachtergrond_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 621);
            this.Controls.Add(this.pnlgame);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "flappy bird";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlgame;
        private System.Windows.Forms.Timer tmrgame;
        private System.Windows.Forms.Timer tmrachtergrond;
    }
}

