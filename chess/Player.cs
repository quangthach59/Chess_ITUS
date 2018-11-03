using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using static chess.Form1;
using System.Reflection;
using System.Collections;
namespace chess
{
    //Nhiều thành viên tham gia
    public class Player
    {
        //Thời gian bổ sung sau mỗi nước đi, của 2 người chơi là như nhau
        public static int timeAdd;
        //Thời gian, điểm, số quân cờ đã ăn của người chơi
        public int time, score, numofeat;   //numofeat = number of eaten (pieces)
        //Tên, tuổi, địa chỉ, cho phép bỏ trống nếu không muốn nhập
        public string name, age, location;
        //Chuỗi chứa tên các quân cờ đã ăn
        public string eaten;
        //15 picturebox lưu hình ảnh của các quân cờ ăn được
        public PictureBox[] pbe = new PictureBox[15];

        //Nguyễn Quang Thạch
        //Hàm dựng khởi tạo mặc định
        public Player()
        {            
            timeAdd = 0;
            time = 0;
            score = 0;
            numofeat = 0;
            name = "";
            age = "";
            location = "";
        }
        //Nguyễn Quang Thạch
        //Hàm dựng khởi tạo 6 tham số: lượt đi & thời gian còn lại & điểm & tên & tuổi & vị trí & những quân cờ đã ăn được
        public Player(int t, int n1, int n2, string s1, string s2, string s3, string s4)
        {
            time = n1;
            score = n2;
            name = s1;
            age = s2;
            location = s3;
            eaten = s4;
            //Số quân cờ ăn được = độ dài của eaten/2, vì tên mỗi quân cờ gồm có 2 kí tự
            numofeat = (s4.Length) / 2;
            //Tái tạo hình ảnh những quân cờ đã ăn được
            RenewPicture(t);
        }
        //Huỳnh Viết Thám
        //Tái tạo những quân cờ đã ăn được
        private void RenewPicture(int t)
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    pbe[5 * r + c] = new PictureBox
                    {
                        Size = new Size(56, 56),
                        Location = new Point(5 + 62 * c, 69 + 62 * r),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                    };
                    if ((r + c + t) % 2 == 0)
                        pbe[5 * r + c].BackColor = Color.LightGray;
                    else
                        pbe[5 * r + c].BackColor = Color.RosyBrown;
                    pbe[5 * r + c].BringToFront();
                    //Biến t là chỉ số của người chơi, hàm dựng truyền vào người chơi nào thì thêm vào người chơi đó
                    if (t % 2 == 0)
                        instance.gbPlayer1.Controls.Add(pbe[5 * r + c]);
                    else if (t % 2 == 1)
                        instance.gbPlayer2.Controls.Add(pbe[5 * r + c]);
                }
            }
        }
        //Nguyễn Quang Thạch
        //Thêm hình ảnh của quân cờ ăn được
        public void AddEatenPiece(Image p, string n)
        {
            pbe[numofeat].Image = p;
            numofeat++;
            eaten += n;
        }
        //Nguyễn Quang Thạch
        //Xóa 15 picturebox và số cờ ăn được trước đó
        public void ResetPlayer()
        {
            for(int i=0;i<15;i++)
            {
                pbe[i].Dispose();
            }
            numofeat = 0;
        }
        //Nguyễn Quang Thạch
        //Cập nhật thông tin của người chơi trên màn hình
        public static void LoadPlayerInfo()
        {
            //Điểm, tên, tuổi, vị trí, thời gian
            instance.lbScore1.Text = player[0].score.ToString();
            instance.lbName1.Text = player[0].name;
            instance.lbAge1.Text = player[0].age;
            instance.lbLocation1.Text = player[0].location.ToString();
            instance.lbTime1.Text = string.Format("{0:00}:{1:00}", player[0].time / 60, player[0].time % 60);
            instance.lbScore2.Text = player[1].score.ToString();
            instance.lbName2.Text = player[1].name;
            instance.lbAge2.Text = player[1].age;
            instance.lbLocation2.Text = player[1].location.ToString();
            instance.lbTime2.Text = string.Format("{0:00}:{1:00}", player[1].time / 60, player[1].time % 60);
            //Cập nhật những quân cờ đã ăn được
            for(int k=0;k<2;k++)
            {
                player[k].ResetPlayer();
                player[k].RenewPicture(k);
                string s = player[k].eaten;
                player[k].numofeat = (s.Length) / 2;
                for(int i=0;i<(s.Length)/2;i++)
                {
                    player[k].pbe[i].Image = Image.FromFile(Environment.CurrentDirectory + "\\" + instance.defIcon + "\\" + s.Substring(2*i,2) + ".PNG");
                }
            }
        }
    }
}
