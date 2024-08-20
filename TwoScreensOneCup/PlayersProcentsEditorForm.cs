using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoScreensOneCup
{
    public partial class PlayersProcentsEditorForm : Form
    {
        public PlayersProcentsEditorForm()
        {
            InitializeComponent();
        }

        private void PlayersProcentsEditorForm_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader("C:\\ScreenDevider\\ProgrammResources\\PlayersProcents.txt"))
            {
                string line = reader.ReadToEnd();
                reader.Close();

                FirstPlayerProcent.Text = line.Split(',')[0];

                FirstPath.Text = line.Split(',')[1];

                XTB.Text = line.Split(",")[2];
                YTB.Text = line.Split(",")[3];
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(FirstPath.Text))
            {
                using (StreamWriter writer = new StreamWriter("C:\\ScreenDevider\\ProgrammResources\\PlayersProcents.txt", false))
                {
                    writer.WriteLine($"{FirstPlayerProcent.Text},{FirstPath.Text},{XTB.Text},{YTB.Text},");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Файл не найден!");
            }
        }

        private void FPlus_Click(object sender, EventArgs e)
        {
            if (FirstPlayerProcent.Text.Length > 0)
            {
                FirstPlayerProcent.Text = (int.Parse(FirstPlayerProcent.Text) + 1).ToString();
            }
            else
            {
                FirstPlayerProcent.Text = "0";
            }
        }

        private void FMinus_Click(object sender, EventArgs e)
        {
            if (FirstPlayerProcent.Text.Length > 0 && int.Parse(FirstPlayerProcent.Text) > 0)
            {
                FirstPlayerProcent.Text = (int.Parse(FirstPlayerProcent.Text) - 1).ToString();
            }
        }

        private void FirstOFD_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "C:\\ScreenDevider\\Inputs";
            ofd.Filter = "mp4 files(*.mp4)|*.mp4";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FirstPath.Text = ofd.FileName;
            }
        }

        private void XPlus_Click(object sender, EventArgs e)
        {
            XTB.Text = (int.Parse(XTB.Text) + 10).ToString();
        }

        private void XMinus_Click(object sender, EventArgs e)
        {
            XTB.Text = (int.Parse(XTB.Text) - 10).ToString();
        }

        private void YPlus_Click(object sender, EventArgs e)
        {
            YTB.Text = (int.Parse(YTB.Text) + 10).ToString();
        }

        private void YMinus_Click(object sender, EventArgs e)
        {
            YTB.Text = (int.Parse(YTB.Text) - 10).ToString();
        }

        private void LeftUpMinus_Click(object sender, EventArgs e)
        {
            LeftUpTB.Text = (int.Parse(LeftUpTB.Text) - 10).ToString();
        }

        private void LeftUpPlus_Click(object sender, EventArgs e)
        {
            LeftUpTB.Text = (int.Parse(LeftUpTB.Text) + 10).ToString();
        }

        private void RightUpMinus_Click(object sender, EventArgs e)
        {
            RightUpTB.Text = (int.Parse(RightUpTB.Text) - 10).ToString();
        }

        private void RightUpPlus_Click(object sender, EventArgs e)
        {
            RightUpTB.Text = (int.Parse(RightUpTB.Text) + 10).ToString();
        }

        private void LeftDownMinus_Click(object sender, EventArgs e)
        {
            LeftDownTB.Text = (int.Parse(LeftDownTB.Text) - 10).ToString();
        }

        private void LeftDownPlus_Click(object sender, EventArgs e)
        {
            LeftDownTB.Text = (int.Parse(LeftDownTB.Text) + 10).ToString();
        }

        private void RightDownMinus_Click(object sender, EventArgs e)
        {
            RightDownTB.Text = (int.Parse(RightDownTB.Text) - 10).ToString();
        }

        private void RightDownPlus_Click(object sender, EventArgs e)
        {
            RightDownTB.Text = (int.Parse(RightDownTB.Text) + 10).ToString();
        }

        Process process;
        string FileName = string.Empty;
        int num;

        private void ChangeVideoSettingsButton_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (int.TryParse(LeftUpTB.Text, out num) == false || int.TryParse(RightUpTB.Text, out num) == false || int.TryParse(LeftDownTB.Text, out num) == false || int.TryParse(RightDownTB.Text, out num) == false)
            {
                MessageBox.Show("Найдена буква!");
                flag = 1;
            }
            if (flag == 0)
            {
                ExecuteSrecCommand();

                SelectedVideoTB.Text = "Обработка...";

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += new EventHandler((o, ev) =>
                {
                    if (process.HasExited)
                    {
                        SelectedVideoTB.Text = "Завершено!";
                        FirstPath.Text = $"C:\\ScreenDevider\\Inputs\\{FileName}-{LeftUpTB.Text}-{RightUpTB.Text}-{LeftDownTB.Text}-{RightDownTB.Text}.mp4";
                        timer.Stop();
                    }
                });

                timer.Start();
            }
        }

        private void ExecuteSrecCommand()
        {
            ProcessStartInfo commandInfo = new ProcessStartInfo();
            commandInfo.WorkingDirectory = @"C:\Windows\System32";
            commandInfo.CreateNoWindow = true;
            commandInfo.UseShellExecute = false;
            commandInfo.RedirectStandardInput = false;
            commandInfo.RedirectStandardOutput = false;
            commandInfo.FileName = "cmd.exe";
            commandInfo.Arguments = $"/c ffmpeg -i {SelectedVideoTB.Text} -vf drawbox=t=1,perspective={LeftUpTB.Text}:{LeftUpTB.Text}:W-{RightUpTB.Text}:{RightUpTB.Text}:{LeftDownTB.Text}:H-{LeftDownTB.Text}:W-{RightDownTB.Text}:H-{RightDownTB.Text}:sense=destination C:\\ScreenDevider\\Inputs\\{FileName}-{LeftUpTB.Text}-{RightUpTB.Text}-{LeftDownTB.Text}-{RightDownTB.Text}.mp4";
            process = Process.Start(commandInfo);
        }

        private void OpenSettingsVideoOFD_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "C:\\ScreenDevider\\Inputs";
            ofd.Filter = "mp4 files(*.mp4)|*.mp4";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SelectedVideoTB.Text = ofd.FileName;
                FileName = System.IO.Path.GetFileName(ofd.FileName);
            }
        }
    }
}
