using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TwoScreensOneCup
{
    public partial class WideForm : Form
    {
        public WideForm()
        {
            InitializeComponent();

            FirstMediaPlayer.settings.setMode("loop", true);
            FirstMediaPlayer.enableContextMenu = false;
            FirstMediaPlayer.uiMode = "none";
            FirstMediaPlayer.stretchToFit = false;

            GetAndSetPlayersProcents();
        }
        
        public void GetAndSetPlayersProcents()
        {
            try
            {
                Screen[] screens = Screen.AllScreens;

                int procents;
                int X, Y;

                using (StreamReader reader = new StreamReader("C:\\ScreenDevider\\ProgrammResources\\PlayersProcents.txt"))
                {
                    string line = reader.ReadToEnd();
                    string[] Params = line.Split(',');
                    procents = int.Parse(Params[0]);

                    FirstMediaPlayer.URL = Params[1];
                    X = int.Parse(Params[2]);
                    Y = int.Parse(Params[3]);
                }

                FirstMediaPlayer.SetBounds(0, 0, screens[0].Bounds.Width * procents / 100, screens[0].Bounds.Height * procents / 100);
                FirstMediaPlayer.Location = new Point((screens[0].Bounds.Width - FirstMediaPlayer.Width) / 2 + X, (screens[0].Bounds.Height - FirstMediaPlayer.Height) / 2 + Y);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error! {ex.ToString().Split('.')[1]}");
            }
        }

        private void WideForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                    var SettingsForm = new PlayersProcentsEditorForm();
                    if (SettingsForm.ShowDialog() == DialogResult.OK)
                    {
                        GetAndSetPlayersProcents();
                    }

                    break;
            }
        }
    }
}
