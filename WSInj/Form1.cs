using System.Windows.Forms;
using WeAreDevs_API;

namespace WSInj
{
    public partial class Form1 : Form
    {

        ExploitAPI API= new ExploitAPI();
        Point lastPoint;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.WindowState= FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            API.SendLuaScript(richTextBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            API.LaunchExploit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew));
                using (StreamWriter sw = new StreamWriter(File.Open(saveFileDialog1.FileName, FileMode.CreateNew)))
                {
                    sw.Write(richTextBox1.Text);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
           lastPoint = new Point(e.X, e.Y);
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}