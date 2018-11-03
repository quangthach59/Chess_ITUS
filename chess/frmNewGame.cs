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
    //Nhiều thành viên tham gia
    public partial class frmNewGame : Form
    {
        //Nguyễn Quang Thạch
        public frmNewGame()
        {
            //Khởi tạo icon cho form
            Icon = Icon.ExtractAssociatedIcon(Environment.CurrentDirectory + "\\img\\logo.ico");
            InitializeComponent();
        }
        //Huỳnh Viết Thám: chức năng thời gian
        //Nguyễn Quang Thạch: các phần còn lại
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Reset bàn cờ trước đó nếu có
            instance.RestartBoard();
            instance.hst.Clear();
            instance.DisposeBoardForNewGame();
            //Khởi tạo bàn cờ mới
            instance.InitializeBoard();
            instance.Drawboard();
            //Biến n được gán giá trị của iten được chọn từ listbox
            int n = cbTimeSelect.SelectedIndex;
            int cTime = 0;
			switch(n)
			{
				case 0: //Blitz mode, 3 phút đánh, +2s sau mỗi nước đi
                    {                      
                        cTime = 180;    Player.timeAdd = 2;
					}; break;
				case 1: //Rapid mode, 5 phút đánh, +10s sau mỗi nước đi
                    {         
                        cTime = 300;    Player.timeAdd = 10;
                    }; break;
				case 2: //Standard mode, 90 phút đánh, +30s sau mỗi nước đi
                    {                  
                        cTime = 5400;   Player.timeAdd = 30;
                    }; break;
			}
            //Nếu đã có thông tin người chơi trước đó thì reset dữ liệu
            if (player[0]!=null)
                player[0].ResetPlayer();
            player[0] = new Player(0, cTime, 0, tbName1.Text, tbAge1.Text, tbLocation1.Text, "");
            if (player[1] != null)
                player[1].ResetPlayer();
            player[1] = new Player(1, cTime, 0, tbName2.Text, tbAge2.Text, tbLocation2.Text, "");
            //Cập nhật thông tin người chơi trên màn hình
            Player.LoadPlayerInfo();
            Close();
            //Bắt đầu tính giờ, người chơi 1 (quân trắng) mặc định đi trước, không cho phép đổi
            instance.Timer2.Stop();
			instance.Timer1.Start();
            //Lưu lại bàn cờ khi khởi tạo để có thể thực hiện undo ngay lượt đầu tiên
            string t = instance.LoadHistory() + "\n" + turn.ToString() + "\n" + (player[0].time) + "\n" + player[1].time + "\n";
            t+= player[0].score.ToString() + "\n" + player[1].score.ToString() + "\n" + player[0].eaten + "\n" +  player[1].eaten + "\n";
            instance.hst.Add(t);
            //Hiện module của game
            instance.ShowModule();
        }
        //Nguyễn Quang Thạch
		private void cbTimeSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
            //Khi có thay đổi bất kì trong listbox, tức người chơi đã chọn thời gian
            //Cho phép click nút Start
			btnStart.Enabled = true;
		}
	}
}
