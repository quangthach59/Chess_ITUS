using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using static chess.AbstractChessPiece;
namespace chess
{
    //Class quan trọng, tất cả các thành viên đều tham gia code + debug
    public partial class Form1 : Form
    {
        //Thống nhất chung giữa các thành viên
        //Khu vực khai báo biến
        #region Khu vực khai báo biến
        //Biến instance, đại diện cho form1, cho phép các class khác có thể truy xuất đối tượng public ở form1
        public static Form1 instance;
        //Tạo tạo 64 ô cờ
        public static AbstractChessPiece[,] cw = new AbstractChessPiece[8, 8];
        //Biến đếm về lượt đi, nước đi chẵn là quân trắng, lẻ là quân đen
        public static int turn = 0;
        //Lịch sử ván đấu hiện tại, khi thoát sẽ mất, và không load lại được
        public List<string> hst = new List<string>();
        //Thuộc tính sẽ thay đổi thành true khi thực hiện bất kì thao tác nào. Khi thay đổi thành true sẽ yêu cầu lưu khi thoát game
        public static bool gameChanged = false;
        //Tên thư mục mặc định khi load quân cờ
        public string defIcon = "";
        //Khởi tạo 2 người chơi. Người chơi 1 là quân trắng, người chơi 2 là quân đen
        public static Player[] player = new Player[2];
        //Khởi tạo vị trí đánh dấu lượt đi của 2 bên
        public Point[] pt = new Point[] { new Point { X = 912, Y = 12 }, new Point { X = 351, Y = 12 } };
        //Khởi tạo biến đánh dấu lịch sử nước đi
        public static int pivot = 0;
        #endregion

        //Lê Thanh Tâm: thiết kế logo
        //Nguyễn Quang Thạch: dựng 64 ô cờ
        //Huỳnh Viết Thám: thiết kế menu, bố trí giao diện
        
        //Form giao diện chính của game
        public Form1()
        {
            //Trả về đối tượng là instance để các hàm ngoài class sử dụng
            instance = this;
            InitializeComponent();
            //Load logo và icon
            Icon = Icon.ExtractAssociatedIcon(Environment.CurrentDirectory + "\\img\\logo.ico");
            pbClock.Image = Image.FromFile(Environment.CurrentDirectory + "\\img\\clock.PNG");
            pbDevil.Image = Image.FromFile(Environment.CurrentDirectory + "\\img\\devil.PNG");
            pbDevil.Location = pt[0];
        }

        //Nguyễn Quang Thạch
        //Sự kiện form load
        private void Form1_Load(object sender, EventArgs e)
        {
            //Lấy cài đặt trong file setting.inf, nếu file không có thì load cài đặt mặc định
            LoadSettings();
        }

        //Nguyễn Quang Thạch
        //Lấy cài đặt trong file setting.inf, nếu file không có thì load cài đặt mặc định
        public void LoadSettings()
        {
            if (File.Exists("settings.inf") == false)
            {
                MessageBox.Show("settings.inf not found! Default settings will be loaded!", "Chess ITUS Loading Settings Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                defIcon = "resources1";
                AllowHint = true;
                return;
            }
            else
            {
                StreamReader f = new StreamReader("settings.inf");
                defIcon = f.ReadLine();
                string alh = f.ReadLine();
                if (alh == "True")
                    AllowHint = true;
                else if (alh == "False")
                    AllowHint = false;
                f.Close();
            }
        }

        //Nguyễn Quang Thạch
        //Tạo lại bàn cờ khi thực hiện chức năng load game
        public void RestartBoard()
        {
            turn = 0;
            tmp = null;
            EP = null;
        }

        //Nguyễn Quang Thạch
        //Hủy bàn cờ
        public void DisposeBoardForNewGame()
        {
            if (cw[0, 0] != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        cw[i, j].Dispose();
                    }
                }
            }
            lbHistory.Items.Clear();
        }

        //Nguyễn Quang Thạch
        //Hàm đặt quân cờ vào các vị trí trên bàn cờ
        public void InitializeBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                cw[1, i] = new WhitePawn(1, i);
                cw[6, i] = new BlackPawn(6, i);
                cw[2, i] = new AbstractChessPiece(2, i);
                cw[3, i] = new AbstractChessPiece(3, i);
                cw[4, i] = new AbstractChessPiece(4, i);
                cw[5, i] = new AbstractChessPiece(5, i);
            }
            cw[0, 0] = new Rook(0, 0, 0);
            cw[0, 1] = new Knight(0, 1, 0);
            cw[0, 2] = new Bishop(0, 2, 0);
            cw[0, 3] = new Queen(0, 3, 0);
            cw[0, 4] = new King(0, 4, 0);
            cw[0, 5] = new Bishop(0, 5, 0);
            cw[0, 6] = new Knight(0, 6, 0);
            cw[0, 7] = new Rook(0, 7, 0);
            cw[7, 0] = new Rook(7, 0, 1);
            cw[7, 1] = new Knight(7, 1, 1);
            cw[7, 2] = new Bishop(7, 2, 1);
            cw[7, 3] = new Queen(7, 3, 1);
            cw[7, 4] = new King(7, 4, 1);
            cw[7, 5] = new Bishop(7, 5, 1);
            cw[7, 6] = new Knight(7, 6, 1);
            cw[7, 7] = new Rook(7, 7, 1);
        }

        //Nguyễn Quang Thạch
        //Vẽ bàn cờ và đánh dấu thứ tự
        public void Drawboard()
        {
            Label[] lbc = new Label[8];
            Label[] lbn = new Label[8];
            for (int i = 0; i < 8; i++)
            {
                //Kẻ chữ trên bàn cờ
                lbc[i] = new Label();
                lbc[i].BackColor = Color.Transparent;
                lbc[i].Font = new Font("Segoe UI", 15, FontStyle.Bold);
                lbc[i].Location = new Point(cw[0, i].Location.X + piece_size / 2 - 11, cw[0, 0].Location.Y + piece_size);
                lbc[i].Text = Convert.ToChar(65 + i).ToString();
                lbc[i].ForeColor = Color.Black;
                lbc[i].AutoSize = true;
                this.Controls.Add(lbc[i]);
                //Kẻ số trên bàn cờ
                lbn[i] = new Label();
                lbn[i].BackColor = Color.Transparent;
                lbn[i].Font = new Font("Segoe UI", 15, FontStyle.Bold);
                lbn[i].Location = new Point(cw[i, 0].Location.X - 25, cw[i, 0].Location.Y + piece_size / 2 - 18);
                lbn[i].Text = (i + 1).ToString();
                lbn[i].ForeColor = Color.Black;
                lbn[i].AutoSize = true;
                this.Controls.Add(lbn[i]);
                for (int j = 0; j < 8; j++)
                {
                    Controls.Add(cw[i, j]);
                }
            }
        }

        //Nguyễn Quang Thạch
        //Hiển thị các công cụ khi bắt đầu game
        public void ShowModule()
        {
            gbPlayer1.Visible = true;
            gbPlayer2.Visible = true;
            lbScore1.Visible = true;
            lbScore2.Visible = true;
            lbTime1.Visible = true;
            lbTime2.Visible = true;
            lbHistory.Visible = true;
            btnUndo2.Visible = true;
            btnRedo2.Visible = true;
            pbClock.Visible = true;
            pbDevil.Visible = true;
            prgAdvantage.Visible = true;
            lbCalculate.Visible = true;
        }

        //Lê Thanh Tâm + Nguyễn Quang Thạch
        //Trả lại chuỗi 128 kí tự về vị trí bàn cờ hiện tại
        public string LoadHistory()
        {
            string t = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string n = cw[i, j].Get_name;
                    if (n == "")
                    {
                        t += "00";
                    }
                    else
                    {
                        t += n;
                    }
                }
            }
            return t;
        }

        //Lê Thanh Tâm + Nguyễn Quang Thạch + Huỳnh Viết Thám
        //Khởi tạo vị trí quân cờ khi load lại game, đọc từ chuỗi 128 kí tự được lưu trên file từ trước
        public void BuildChessBoardFromString(string t)
        {
            RestartBoard();
            string str1 = t.Substring(0, 128);
            t = t.Remove(0, str1.Length + 1);
            int n = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string s = str1.Substring(n, 2);
                    int c = 0;
                    AbstractChessPiece p = new AbstractChessPiece();
                    if (s[1] == '0')
                        p = new AbstractChessPiece(i, j);
                    else if (s[0] == 'b')
                        c = 1;
                    switch (s[1])
                    {
                        case 'R': p = new Rook(i, j, c); break;
                        case 'N': p = new Knight(i, j, c); break;
                        case 'B': p = new Bishop(i, j, c); break;
                        case 'Q': p = new Queen(i, j, c); break;
                        case 'K': p = new King(i, j, c); break;
                        case 'P':
                            {
                                if (c == 0)
                                    p = new WhitePawn(i, j);
                                else
                                    p = new BlackPawn(i, j);
                            }; break;
                    }
                    if (cw[i, j] == null)
                    {
                        cw[i, j] = p;
                        Controls.Add(cw[i, j]);
                    }
                    else if (cw[i, j].Get_name != p.Get_name)
                    {
                        cw[i, j].Dispose();
                        cw[i, j] = p;
                        Controls.Add(cw[i, j]);
                    }
                    n += 2;
                }
            }
            string str2 = t.Substring(0, t.IndexOf("\n"));
            t = t.Remove(0, str2.Length + 1);
            Int32.TryParse(str2, out turn);
            turn = turn % 2;
            pbDevil.Location = pt[turn];
            string str3 = t.Substring(0, t.IndexOf("\n"));
            t = t.Remove(0, str3.Length + 1);
            Int32.TryParse(str3, out player[0].time);

            string str4 = t.Substring(0, t.IndexOf("\n"));
            t = t.Remove(0, str4.Length + 1);
            Int32.TryParse(str4, out player[1].time);

            string str5 = t.Substring(0, t.IndexOf("\n"));
            t = t.Remove(0, str5.Length + 1);
            Int32.TryParse(str5, out player[0].score);

            string str6 = t.Substring(0, t.IndexOf("\n"));
            t = t.Remove(0, str6.Length + 1);
            Int32.TryParse(str6, out player[1].score);

            string str7 = t.Substring(0, t.IndexOf("\n"));
            player[0].eaten = str7;
            t = t.Remove(0, str7.Length + 1);
            string str8 = t.Substring(0, t.IndexOf("\n"));
            player[1].eaten = str8;
            t = t.Remove(0, str8.Length + 1);
            if (turn % 2 == 0)
            {
                Timer1.Start();
                Timer2.Stop();
            }
            else
            {
                Timer2.Start();
                Timer1.Stop();
            }
            cw[0, 0].GetAdvantage();
            Player.LoadPlayerInfo();
        }

        //Lê Thanh Tâm + Nguyễn Quang Thạch
        //Khởi tạo lại bàn cờ khi load tập tin .dat thành công
        public void RebuildChessBoard(string fname)
        {
            StreamReader f = new StreamReader(fname);
            string t = "";
            for (int i = 0; i < 8; i++)
            {
                t += f.ReadLine() + "\n";
            }
            Int32.TryParse(f.ReadLine(), out Player.timeAdd);
            player[0] = new Player(0, 0, 0, f.ReadLine(), f.ReadLine(), f.ReadLine(), "");
            player[1] = new Player(1, 0, 0, f.ReadLine(), f.ReadLine(), f.ReadLine(), "");
            BuildChessBoardFromString(t);
            instance.hst.Add(t);
            pivot = 0;
            f.Close();
        }

        //Lê Thanh Tâm
        //Hàm undo
        public void UndoFunction()
        {
            if (hst.Count == 1)
                return;
            if (pivot == 0)
                return;
            int temp = --turn;
            pivot--;
            BuildChessBoardFromString(hst[pivot]);
            turn = temp;
            AbstractChessPiece.CheckCurrentGame();
        }

        //Lê Thanh Tâm
        //Hàm redo
        public void RedoFunction()
        {
            if (hst.Count == 1)
                return;
            if (pivot == hst.Count - 1)
                return;
            int temp = ++turn;
            pivot++;
            BuildChessBoardFromString(hst[pivot]);
            turn = temp;
            AbstractChessPiece.CheckCurrentGame();
        }

        //Huỳnh Viết Thám
        //Hàm lưu game
        public void SaveGame()
        {
            if (cw[0, 0] == null)
            {
                MessageBox.Show("No game loaded or started!", "Chess ITUS Message", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "DAT|*.dat";
            sfd.ShowDialog();
            if (sfd.FileName == "")
            {
                MessageBox.Show("Save game cancelled!", "Chess ITUS Message", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            StreamWriter f = new StreamWriter(sfd.FileName, false);
            f.WriteLine(LoadHistory());
            f.WriteLine(turn);
            f.WriteLine(player[0].time);
            f.WriteLine(player[1].time);
            f.WriteLine(player[0].score);
            f.WriteLine(player[1].score);
            f.WriteLine(player[0].eaten);
            f.WriteLine(player[1].eaten);
            f.WriteLine(Player.timeAdd);
            f.WriteLine(player[0].name);
            f.WriteLine(player[0].age);
            f.WriteLine(player[0].location);
            f.WriteLine(player[1].name);
            f.WriteLine(player[1].age);
            f.WriteLine(player[1].location);
            f.Close();
            gameChanged = false;
        }

        //Huỳnh Viết Thám
        //Hỏi người chơi có muốn lưu lại game hay không, nếu có sẽ gọi hàm SaveGame, không thì đi đến lệnh tiếp theo
        public void AskSavingGame()
        {
            if (gameChanged == true)
            {
                DialogResult dlr = MessageBox.Show("Do you wanna save game?", "Chess ITUS Saving Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    SaveGame();
                }
            }
        }

        //Nguyễn Quang Thạch
        //Lưu cài đặt vào tập tin settings.inf, tự động được gọi khi thoát game
        public void SaveSettings()
        {
            StreamWriter f = new StreamWriter("settings.inf", false);
            f.WriteLine(defIcon);
            f.WriteLine(AbstractChessPiece.AllowHint.ToString());
            f.Close();
        }

        //Nhóm hàm private của các control
        #region Nhóm hàm private của các control

        //Nguyễn Quang Thạch
        //Thao tác vào ô cờ
        public static void AbstractChessPiece_Click(object sender, EventArgs e)
        {
            //Tạo dựng quân cờ từ sender, tức quân cờ được click trên form
            AbstractChessPiece s = (AbstractChessPiece)sender;
            //Lựa chọn quân cờ thao tác
            s.SelectPiece();
        }

        //Nguyễn Quang Thạch
        //Thao tác khi thực hiện ở nút newgame
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            //Xác nhận việc lưu game khi muốn chơi lại game mới
            AskSavingGame();
            frmNewGame frm = new frmNewGame();
            //Khởi tạo game mới
            frm.ShowDialog();
        }

        //Nguyễn Quang Thạch
        //Thao tác thực hiện khi chọn chức năng LoadGame
        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            AskSavingGame();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "DAT|*.dat";
            ofd.ShowDialog();
            if (ofd.FileName == "")
            {
                MessageBox.Show("No file selected!", "Chess ITUS Loading Data Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            hst.Clear();
            RebuildChessBoard(ofd.FileName);
            ShowModule();
        }

        //Nguyễn Quang Thạch
        //Thao tác thực hiện khi chọn chức năng SaveGame
        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            SaveGame();
        }

        //Huỳnh Viết Thám
        //Thao tác khi thực hiện ở nút exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Nguyễn Quang Thạch
        //Thao tác thực hiện ở nút Player's Settings
        private void btnPlayerSettings_Click(object sender, EventArgs e)
        {
            if (player[0] != null)
            {
                frmPlayerSettings fps = new frmPlayerSettings();
                fps.ShowDialog();
            }
            else
                MessageBox.Show("No player available!", "Chess ITUS Player's Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Nguyễn Quang Thạch
        //Thao tác thực hiện ở nút Customize
        private void btnCustomize_Click(object sender, EventArgs e)
        {
            frmCustomize fcm = new frmCustomize();
            fcm.ShowDialog();
        }

        //Lê Thanh Tâm
        //Thao tác thực hiện ở nút Undo
        private void btnUndo2_Click(object sender, EventArgs e)
        {
            UndoFunction();
        }

        //Lê Thanh Tâm
        //Thao tác thực hiện ở nút Redo
        private void btnRedo2_Click(object sender, EventArgs e)
        {
            RedoFunction();
        }

        //Lê Thanh Tâm
        //Thao tác thực hiện khi chọn chức năng undo trên màn hình
        private void btnUndo_Click(object sender, EventArgs e)
        {
            UndoFunction();
        }

        //Lê Thanh Tâm
        //Thao tác thực hiện khi chọn chức năng redo trên màn hình
        private void btnRedo_Click(object sender, EventArgs e)
        {
            RedoFunction();
        }

        //Nguyễn Quang Thạch
        //Thao tác thực hiện khi chọn chức năng Rules
        private void btnRules_Click_1(object sender, EventArgs e)
        {
            //Dẫn đến web hướng dẫn chơi game
            System.Diagnostics.Process.Start("http://www.fide.com/fide/handbook.html?id=171&view=article");
        }

        //Nguyễn Quang Thạch
        //Thao tác khi thực hiện ở nút about
        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        //Huỳnh Viết Thám
        //Các thao tác thực hiện sau mỗi lần thời gian 2 tick
        private void Timer1_Tick(object sender, EventArgs e)
        {
            player[0].time--;
            lbTime1.Text = string.Format("{0:00}:{1:00}", player[0].time / 60, player[0].time % 60);
            if (player[0].time == 0)
            {
                Timer1.Stop();
                Timer2.Stop();
                MessageBox.Show("Time out! You still can continue, but time will be stuck at 00:00!", "Chess ITUS Time Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        //Huỳnh Viết Thám
        //Các thao tác thực hiện sau mỗi lần thời gian 2 tick
        private void Timer2_Tick(object sender, EventArgs e)
        {
            player[1].time--;
            lbTime2.Text = string.Format("{0:00}:{1:00}", player[1].time / 60, player[1].time % 60);
            if (player[1].time == 0)
            {
                Timer1.Stop();
                Timer2.Stop();
                MessageBox.Show("Time out! You still can continue, but time will be stuck at 00:00!", "Chess ITUS Time Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Nguyễn Quang Thạch
        //Hàm đóng chương trình
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Nếu bàn cờ chưa dựng thì thoát
            if (cw[0, 0] == null)
                return;
            //Hỏi lưu game
            AskSavingGame();
            SaveSettings();
        }
        
        //Nguyễn Quang Thạch
        //Vẽ 2 màu khác nhau cho listbox lbHistory
        private void lbHistory_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                if (e.Index % 2 == 0)
                    e.Graphics.FillRectangle(Brushes.LightGreen, e.Bounds);
                using (Brush textBrush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(lbHistory.Items[e.Index].ToString(), e.Font, textBrush, e.Bounds.Location);
                }
            }
        }
        #endregion
    }
}