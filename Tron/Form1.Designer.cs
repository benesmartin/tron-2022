
namespace Tron
{
    partial class FormTron
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.tmRefresh = new System.Windows.Forms.Timer(this.components);
            this.tmCollision = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.SuspendLayout();
            // 
            // pb1
            // 
            this.pb1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pb1.BackgroundImage = global::Tron.Properties.Resources.tile;
            this.pb1.Location = new System.Drawing.Point(12, 12);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(776, 426);
            this.pb1.TabIndex = 0;
            this.pb1.TabStop = false;
            this.pb1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // tmRefresh
            // 
            this.tmRefresh.Tick += new System.EventHandler(this.tmRefresh_Tick);
            // 
            // tmCollision
            // 
            this.tmCollision.Tick += new System.EventHandler(this.tmCollision_Tick);
            // 
            // FormTron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pb1);
            this.Name = "FormTron";
            this.Text = "TRON";
            this.SizeChanged += new System.EventHandler(this.FormTron_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormTron_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.Timer tmRefresh;
        private System.Windows.Forms.Timer tmCollision;
    }
}

