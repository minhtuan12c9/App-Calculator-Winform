using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_HoPhanMinhTuan
{
    public partial class frmHistory : Form
    {
        public frmTuan mainForm; // Tham chiếu đến form frmMain
        public Point MainFormLocation
        {
            get { return mainFormLocation; }
            set { mainFormLocation = value; }
        }
        private Point mainFormLocation; // Lưu trữ vị trí của frmMain trước khi chuyển sang frmHistory
        public frmHistory()
        {
            InitializeComponent();
            
        }
        public frmHistory(int width, int height)
        {
            InitializeComponent();
            this.Size = new Size(width, height);
        }
        public frmHistory(frmTuan mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.Size = mainForm.Size; // Đặt kích thước của frmHistory bằng kích thước của frmMain
            o3.SelectionAlignment = HorizontalAlignment.Right;
            o3.Text = mainForm.combinedContent;
            changeColor();
        }

        private void frmHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainForm.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm.Show();
        }

        private void cal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            o3.Clear();
            this.mainForm.combinedContent = "";
        }
        private void changeColor()
        {
            String input = o3.Text;
            // Mã màu cho số "0", ví dụ: "#9899c2" (màu xanh)
            string hexColor = "#45bd62";
            Color customColor = System.Drawing.ColorTranslator.FromHtml(hexColor);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '+' || input[i] == '-' || input[i] == 'x' || input[i] == '÷' || input[i] == '%')
                {
                    o3.Select(i, 1);
                    o3.SelectionColor = customColor;
                }
                else if (input[i] == '(' || input[i] == ')')
                {
                    o3.Select(i, 1);
                    o3.SelectionColor = Color.Red;
                }
                else if(input[i] == '=')
                {
                    o3.Select(i, input.Length);
                    o3.SelectionColor = Color.Yellow;
                }
                else
                {
                    o3.Select(i, 1);
                    o3.SelectionColor = Color.FromArgb(188, 192, 237);
                }
            }
        }
    }
}
