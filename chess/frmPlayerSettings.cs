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
    public partial class frmPlayerSettings : Form
    {
        //Nguyễn Quang Thạch
        public frmPlayerSettings()
        {
            InitializeComponent();
            //Khởi tạo icon cho form
            Icon = Icon.ExtractAssociatedIcon(Environment.CurrentDirectory + "\\img\\logo.ico");
            //Gán các textbox bằng tên người chơi hiện tại
            tbName1.Text = player[0].name;
            tbAge1.Text = player[0].age;
            tbLocation1.Text = player[0].location;
            tbName2.Text = player[1].name;
            tbAge2.Text = player[1].age;
            tbLocation2.Text = player[1].location;          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Lưu lại thông tin người chơi
            player[0].name = tbName1.Text;
            player[0].age = tbAge1.Text;
            player[0].location = tbLocation1.Text;
            player[1].name = tbName2.Text;
            player[1].age = tbAge2.Text;
            player[1].location = tbLocation2.Text;
            //Cập nhật hiển thị thông tin người chơi
            Player.LoadPlayerInfo();
            //Game đã thay đổi, khi thoát phải save
            gameChanged = true;
            Close();
        }
    }
}
