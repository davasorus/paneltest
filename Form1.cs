using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paneltest
{
    public partial class Form1 : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        //Constructor
        public Form1()
        {
            InitializeComponent();
            random = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.colorList.Count);
            while(tempIndex == index)
            {
                index = random.Next(ThemeColor.colorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.colorList[index];
            return ColorTranslator.FromHtml(color);
        }

        //changes color of buttons
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();

                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;

                    currentButton.Font = new Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color,-0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                }
            }
        }

        //reset color and font for unselected button
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if(previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(67, 86, 143);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelChild1.Controls.Add(childForm);
            this.panelChild1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            lblTitle.Text = childForm.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.childForm1(),sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.childForm2(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.childForm3(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.childForm4(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.childForm5(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.childForm6(), sender);
        }

        
    }
}
