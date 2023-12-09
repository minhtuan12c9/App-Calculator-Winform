using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Calc_HoPhanMinhTuan
{
    public partial class frmTuan : Form
    {
        private Dictionary<Button, Color> buttonColors = new Dictionary<Button, Color>();
        private void AlignTextRight(RichTextBox richTextBox)
        {
            // Căn lề về phía bên phải cho văn bản tại vị trí con trỏ hiện tại
            richTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }

        public frmTuan()
        {
            InitializeComponent();

        }


        private void bt1_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);

            // Hiển thị số "0" trong RichTextBox o1
            o1.AppendText("1");

            FormatTextInput();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);

            // Hiển thị số "0" trong RichTextBox o1
            o1.AppendText("2");

            FormatTextInput();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);
           

            // Hiển thị số "0" trong RichTextBox o1
            o1.AppendText("3");

            FormatTextInput();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);

            // Hiển thị số "0" trong RichTextBox o1
            o1.AppendText("4");

            FormatTextInput();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);

            // Hiển thị số "0" trong RichTextBox o1
            o1.AppendText("5");

            FormatTextInput();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);
       
            // Hiển thị số "0" trong RichTextBox o1
            o1.AppendText("6");

            FormatTextInput();
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);
           
            // Hiển thị số "0" trong RichTextBox o1
            o1.AppendText("7");

            FormatTextInput();
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);

            // Hiển thị số "0" trong RichTextBox o1
            o1.AppendText("8");

            FormatTextInput();
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);

            // Hiển thị số "0" trong RichTextBox o1
            o1.AppendText("9");

            FormatTextInput();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            o1.Clear();
            o2.Clear();
        }

        private void btpt_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);
           
            // Hiển thị dấu "+" trong RichTextBox o1
            o1.AppendText("%");

            FormatTextInput();
        }

        private void btchia_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);
            
            // Hiển thị dấu "+" trong RichTextBox o1
            o1.AppendText("÷");

            FormatTextInput();
        }

        private void btnhan_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);

            // Hiển thị dấu "+" trong RichTextBox o1
            o1.AppendText("x");

            FormatTextInput();
        }

        private void bttru_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);
            
            // Hiển thị dấu "+" trong RichTextBox o1
            o1.AppendText("-");

            FormatTextInput();
        }

        private void btcong_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);

            // Hiển thị dấu "+" trong RichTextBox o1
            o1.AppendText("+");

            FormatTextInput();
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);
           
            // Hiển thị số "0" trong RichTextBox o1
            o1.AppendText("0");

            FormatTextInput();
        }

        private void btphay_Click(object sender, EventArgs e)
        {
            AlignTextRight(o1);
           
            // Hiển thị số "0" trong RichTextBox o1
            o1.AppendText(",");
        }

        private bool isOpenParenthesis = false; // Biến để theo dõi trạng thái mở ngoặc
        private void btngoac_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu đang trong trạng thái mở ngoặc, thì thêm dấu đóng ngoặc
            if (isOpenParenthesis)
            {
                o1.AppendText(")");
                isOpenParenthesis = false; // Đã thêm dấu đóng ngoặc, chuyển trạng thái về false
            }
            else
            {
                o1.AppendText("("); // Nếu không, thêm dấu mở ngoặc
                isOpenParenthesis = true; // Đã thêm dấu mở ngoặc, chuyển trạng thái về true
            }
        }
        private string ReplaceOperators(string input)
        {
            // Thay thế dấu "x" thành phép nhân (*)
            input = input.Replace("x", "*");

            // Thay thế dấu "÷" thành phép chia (/)
            input = input.Replace("÷", "/");

            // Thay thế dấu "," thành dáu "." để có thể thực hiện thập phân
            input = input.Replace(",", ".");

            // Thay thế dấu "%" thành chia phần trăm "/100"
            input = input.Replace("%", "/100");

            return input;
        }
        private double Calculate(string input)
        {
            try
            {
                // Sử dụng hàm Evaluate để tính toán biểu thức số học
                DataTable table = new DataTable();
                table.Columns.Add("expression", typeof(string), input);
                DataRow row = table.NewRow();
                table.Rows.Add(row);

                // Tính toán kết quả
                double result = double.Parse((string)row["expression"]);
                return result;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi trong phép tính: " + ex.Message);
                return double.NaN; // Trả về NaN nếu có lỗi
            }
        }
        private void PerformCalculation()
        {
            // Lấy nội dung từ RichTextBox o1
            string input = o1.Text;

            // Xóa định dạng nghìn
            string inputRemoveFormat = input.Replace(".", "");

            // Chuyển đổi dấu ",", "x" và "÷" thành ".", phép nhân (*) và phép chia (/)
            string change = ReplaceOperators(inputRemoveFormat);

            // Thực hiện phép tính dựa trên biểu thức đã định dạng và lưu kết quả vào biến result
            double result = Calculate(change);

            // Hiển thị kết quả trong RichTextBox o2
            o2.Text = FormatNumber(result.ToString("G"));
        }




        public string combinedContent;
        private void btkq_Click(object sender, EventArgs e)
        {
            // Gọi hàm thực hiện phép tính và hiển thị kết quả
            PerformCalculation();
            // Lấy nội dung của o1 và o2
            string o1Content = o1.Text;
            string o2Content = o2.Text;
            // Kết hợp nội dung từ o1 và o2 với dấu xuống dòng
            combinedContent += o1Content + Environment.NewLine + "=" + o2Content + Environment.NewLine + Environment.NewLine;
            
        }

        private void FormatTextInput()
        {
            String input = o1.Text;
            input = input.Replace(".", "");
            input = input.Replace(",", ".");

            string pattern = @"[0-9]+(?:\.[0-9]+)?"; // Biểu thức chính quy để tìm số

            MatchCollection matches = Regex.Matches(input, pattern);

            String numberFormat, numberStr;
            foreach (Match match in matches)
            {
                numberStr = match.Value;
                numberFormat = FormatNumber(numberStr);
                input = input.Replace(numberStr, numberFormat);
            }

            o1.ForeColor = Color.White;
            o1.Text = input;

            // Mã màu cho số "0", ví dụ: "#9899c2" (màu xanh)
            string hexColor = "#9899c2";
            Color customColor = System.Drawing.ColorTranslator.FromHtml(hexColor);

            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == '+' || input[i] == '-' || input[i] == 'x' || input[i] == '÷' || input[i] == '%')
                {
                    o1.Select(i, 1);
                    o1.SelectionColor = customColor;
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == ')')
                {
                    o1.Select(i, 1);
                    o1.SelectionColor = Color.Yellow;
                }
            }

        }

        private String FormatNumber(String numberStr)
        {
            String result = "";

            result = numberStr.Replace(".", ",");
            int resCount = result.Length;

            if (result.Contains(","))
            {
                resCount = result.IndexOf(",");
            }

            for (int i = resCount - 3; i > 0; i -= 3)
            {
                result = result.Insert(i, ".");
            }

            return result;
        }

        private void imgclear_Click(object sender, EventArgs e)
        {
            string originalString = o1.Text;
            if (!string.IsNullOrEmpty(originalString))
            {
                originalString = originalString.Remove(originalString.Length - 1);
            }
            o1.Text = originalString;
            FormatTextInput();
        }
        private void history_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện của frmHistory và truyền tham chiếu đến frmMain
            frmHistory historyForm = new frmHistory(this);

            historyForm.StartPosition = FormStartPosition.CenterScreen;

            // Ẩn form frmMain
            this.Hide();

            // Hiển thị form mới
            historyForm.Show();
        }
    }
}
