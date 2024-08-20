namespace TwoScreensOneCup
{
    partial class WideForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WideForm));
            FirstMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)FirstMediaPlayer).BeginInit();
            SuspendLayout();
            // 
            // FirstMediaPlayer
            // 
            FirstMediaPlayer.Enabled = true;
            FirstMediaPlayer.Location = new Point(128, 112);
            FirstMediaPlayer.Name = "FirstMediaPlayer";
            FirstMediaPlayer.OcxState = (AxHost.State)resources.GetObject("FirstMediaPlayer.OcxState");
            FirstMediaPlayer.Size = new Size(75, 23);
            FirstMediaPlayer.TabIndex = 0;
            // 
            // WideForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(FirstMediaPlayer);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "WideForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            KeyDown += WideForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)FirstMediaPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer FirstMediaPlayer;
    }
}
