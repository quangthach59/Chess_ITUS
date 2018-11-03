using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static chess.Form1;
namespace chess
{
    public partial class frmCustomize : Form
    {
        //Nguyễn Quang Thạch
        //Khởi tạo 3 radio button để lựa chọn loại icon và 3 picturebox tương ứng mô tả quân cờ
        RadioButton[] rb = new RadioButton[3];
        PictureBox[] img = new PictureBox[3];
        //biến static lưu tên của thư mục được chọn để load quân cờ
        public static string c = "";
        public frmCustomize()
        {
            InitializeComponent();
            //Khởi tạo icon cho form
            Icon = Icon.ExtractAssociatedIcon(Environment.CurrentDirectory + "\\img\\logo.ico");
            //Khởi tạo 3 radio button và 3 picturebox ở trên
            for(int i=0;i<3;i++)
            {
                rb[i] = new RadioButton();
                rb[i].Location = new Point(24 + 120 * i, 24);
                rb[i].Text = "Type " + (i + 1).ToString();
                rb[i].BringToFront();
                rb[i].CheckedChanged += rb_CheckedChanged;
                groupBox1.Controls.Add(rb[i]);
                img[i] = new PictureBox();
                img[i].Size = new Size(100, 100);
                img[i].Location = new Point(6 + 120 * i, 51);
                img[i].SizeMode = PictureBoxSizeMode.StretchImage;
                img[i].Image = Image.FromFile(Environment.CurrentDirectory + "\\resources" + (i + 1).ToString() + "\\" + "bK.PNG");
                img[i].BringToFront();
                groupBox1.Controls.Add(img[i]);
            }
            int n = 0;
            //Checkbox với thuộc tính cho phép có hiển thị gợi ý nước đi hay không
            ckbAllowHint.Checked = AbstractChessPiece.AllowHint;
            //Đọc dữ liệu từ biến instance.defIcon (default icon) xem trước đó người chơi đã chọn bộ icon nào
            Int32.TryParse(instance.defIcon.Substring(instance.defIcon.Length - 1, 1), out n);
            rb[n - 1].Checked = true;
        }
        private static void rb_CheckedChanged(object sender, EventArgs e)
        {
            //Sự kiện khi radio button bất kì có thay đổi thuộc tính checked
            //Gán biến c (choosen) với radio button tương ứng
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
                c = "resources" + rb.Text.Substring(rb.Text.Length - 1, 1);
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            //Button lưu lại cài đặt của game
            DialogResult dlr = MessageBox.Show("Application will restart to apply changes" + Environment.NewLine + "You wanna continue?", "Chess ITUS Restart Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //Được yêu cầu khởi động lại game, nếu chọn Yes sẽ lưu cài đặt và khởi động lại
            //chọn No sẽ không lưu cài đặt và không khởi động lại
            if (dlr == DialogResult.Yes)
            {
                instance.defIcon = c;
                AbstractChessPiece.AllowHint = ckbAllowHint.Checked;
                instance.SaveSettings();
                Application.Restart();
            }        
        }
    }
}
