using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using static chess.Form1;
using System;
using System.Reflection;
using System.Collections;
namespace chess
{
    //Class quan trọng, tất cả các thành viên đều tham gia code + debug
    public class AbstractChessPiece : PictureBox
    {
        //Các thành viên thống nhất chung
        //Khu vực khai báo biến
        #region Khu vực khai báo biến
        //Quy ước màu sắc của ô cờ, giá trị từ 0 đến 3
        //0 là ô chẵn, 1 là ô lẻ, 2 là ô được chọn, 3 là ô có thể ăn
        public static Color[] cColor = new Color[] { Color.ForestGreen, Color.LightSteelBlue, Color.DodgerBlue, Color.Red };
        //Quy đổi lượt đi sang chữ cái, w là chẵn = quân trắng, b là lẻ = quân đen
        protected static string[] turnN = new string[] { "w", "b" };
        //Kích thước mỗi ô trong bàn cờ, đơn vị pixel
        public const int piece_size = 73;
        //Quân cờ tạm, lưu ở bộ nhớ trước đó
        public static AbstractChessPiece tmp;
        //Tên quân cờ, bao gồm 2 kí tự: <màu cờ, w hoặc b> + <tên quân cờ, Mã kí hiệu là N, còn lại đều theo chữ cái viết hoa của tên quân cờ>
        protected string cName;
        //Thuộc tính quân cờ đã di chuyển hay chưa
        protected bool moved;
        //Điểm, tọa độ hàng, tọa độ cột
        protected int cScore, row, column;
        //Vector lưu những vị trí quân cờ có thể đi đến
        protected List<Piece> mov = new List<Piece>();
        //Vector lưu những vị trí quân cờ có thể đi đến
        protected List<Piece> eat = new List<Piece>();
        //Vị trí quân cờ có thể bị bắt qua đường, null tức là không có quân cờ để bắt
        public static Piece EP = null;
        //Thuộc tính bool, cho phép hiện gợi ý nước đi hay không
        public static bool AllowHint;
        #endregion

        //Nguyễn Quang Thạch
        //Nhóm hàm dựng
        #region Nhóm hàm dựng
        //Hàm dựng mặc định
        public AbstractChessPiece()
        {
            cName = "";
            cScore = 0;
            Image = null;
            Size = new Size(piece_size, piece_size);
            moved = false;
        }
        //Hàm dựng có tham số tọa độ
        public AbstractChessPiece(int r, int c)
        {
            cName = "";
            cScore = 0;
            Image = null;
            row = r;
            column = c;
            Size = new Size(piece_size, piece_size);
            BringToFront();
            Location = new Point(380 + c * piece_size, 100 + (7 - r) * piece_size);
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = cColor[(r + c) % 2];
            moved = false;
            MouseClick += AbstractChessPiece_Click;
        }
        #endregion

        //Nguyễn Quang Thạch
        //Nhóm hàm ảo
        #region Nhóm hàm ảo
        //Hàm cài đặt nước đi theo nguyên tắc cơ bản, được cài đặt tại những class con
        public virtual void Move_Chess(int t)
        {
        }
        #endregion

        //Nhóm hàm static
        #region Nhóm hàm static
        //Nguyễn Quang Thạch
        //Trả về số nước đi còn có thể đi
        public static int NumbersLeft()
        {
            List<Piece> tmpRange = new List<Piece>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cw[i, j].Get_name != "")
                    {
                        string tm = cw[i, j].Get_name.Substring(0, 1);
                        if (tm == turnN[(turn) % 2])
                        {
                            cw[i, j].Move_Chess(turn);
                            tmpRange.AddRange(cw[i, j].Get_EatRange);
                            tmpRange.AddRange(cw[i, j].Get_MoveRange);
                            cw[i, j].Reset_Temp();
                        }
                    }
                }
            }
            return tmpRange.Count;
        }

        //Nguyễn Quang Thạch
        //Kiểm tra trong một vector có chứa quân Vua hay không
        public static bool KingIsInRange(List<Piece> t, int n)
        {
            for (int i = 0; i < t.Count; i++)
                if (cw[t[i].x, t[i].y].Get_name == turnN[n % 2] + "K")
                    return true;
            return false;
        }

        //Nguyễn Quang Thạch
        //Kiểm tra Vua của lượt truyền tham số có bị chiếu hay không
        public static bool CheckKing(int t)
        {
            List<Piece> tmpRange = new List<Piece>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cw[i, j].Get_name != "")
                    {
                        string tm = cw[i, j].Get_name.Substring(0, 1);
                        if (tm == turnN[(turn + 1) % 2])
                        {
                            cw[i, j].Move_Chess(t + 1);
                            tmpRange.AddRange(cw[i, j].Get_EatRange);
                            cw[i, j].Reset_Temp();
                            if (KingIsInRange(tmpRange, t) == true)
                                return true;
                            tmpRange.Clear();
                        }
                    }
                }
            }
            return false;
        }

        //Nguyễn Quang Thạch
        //Kiểm tra tình hình của ván cờ
        public static void CheckCurrentGame()
        {
            //Đếm số nước đi còn lại
            int n = NumbersLeft();
            //Nếu Vua đang bị chiếu
            if (CheckKing(turn) == true)
            {
                //Vua vẫn còn nước đi thì chỉ bị chiếu thông thường, có hiện số nước đi còn có thể
                if (n != 0)
                {
                    instance.lbHistory.Items[instance.lbHistory.Items.Count - 1] += "+";
                    MessageBox.Show("Check! " + n.ToString() + " move(s) left!", "Chess ITUS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else    //Vua không còn nước đi tức là bị chiếu hết
                {
                    instance.Timer1.Stop();
                    instance.Timer2.Stop();
                    string pl = "White";
                    if (turn % 2 == 0)
                        pl = "Black";
                    instance.lbHistory.Items[instance.lbHistory.Items.Count - 1] += "#" + "\t" + pl + " wins!";
                    MessageBox.Show("Checkmate!", "Chess ITUS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else    //Nếu Vua đang không bị chiếu nhưng lại không còn nước đi tức là hòa cờ
            {
                if (n == 0)
                {
                    instance.Timer1.Stop();
                    instance.Timer2.Stop();
                    instance.lbHistory.Items[instance.lbHistory.Items.Count - 1] += "1/2-1/2";
                    MessageBox.Show("Draw due to no legal move(s) left!", "Chess ITUS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        //Nhóm hàm private
        #region Nhóm hàm private
        //Lê Thanh Tâm
        //Trả về giá trị cho viết một quân cờ có thể đến vị trí đó hay không
        private int CanGoTo(Piece p)
        {
            //-1 là không di chuyển được, 0 là di chuyển được, 1 là ăn được 
            for (int i = 0; i < tmp.mov.Count; i++)
            {
                if (tmp.mov[i].x == p.x && tmp.mov[i].y == p.y)
                    return 0;
            }
            for (int i = 0; i < tmp.eat.Count; i++)
            {
                if (tmp.eat[i].x == p.x && tmp.eat[i].y == p.y)
                    return 1;
            }
            return -1;
        }

        //Nguyễn Quang Thạch
        //Reset những nước đi đã gợi ý
        private void Reset_Temp()
        {
            if (AllowHint == true)
            {
                for (int i = 0; i < mov.Count; i++)
                {
                    if (cw[mov[i].x, mov[i].y].cName == "")
                        cw[mov[i].x, mov[i].y].Image = null;
                }
                for (int i = 0; i < eat.Count; i++)
                    cw[eat[i].x, eat[i].y].BackColor = cColor[(eat[i].x + eat[i].y) % 2];
            }
            //Xóa vector mov và eat
            mov.Clear();
            eat.Clear();
            //Khôi phục BackColor mặc định
            BackColor = cColor[(row + column) % 2];
        }
        
        //Nguyễn Quang Thạch
        //Hiện gợi ý nước đi
        private void Set_Hint()
        {
            //Nếu cho phép hiện gợi ý nước đi
            if (AllowHint == true)
            {
                for (int i = 0; i < mov.Count; i++)
                    cw[mov[i].x, mov[i].y].Image = Image.FromFile(Environment.CurrentDirectory + "\\" + instance.defIcon + "\\" + "dot.PNG");
                for (int i = 0; i < eat.Count; i++)
                    cw[eat[i].x, eat[i].y].BackColor = cColor[3];
            }
            //Thay đổi BackColor của quân cờ được chọn       
            BackColor = cColor[2];
        }

        #endregion

        //Nhóm hàm protected
        #region Nhóm hàm protected

        //Lê Thanh Tâm + Nguyễn Quang Thạch + Huỳnh Viết Thám
        //Di chuyển quân cờ P đến vị trí hiện tại
        protected void MoveFromP(ref AbstractChessPiece p)
        {
            string movement = "";
            //Nếu quân cờ P không phải là chốt, vì trong quy ước ghi biên bản, chốt không ghi tên
            if (p.cName.Substring(1, 1) != "P")
                movement = p.cName.Substring(1, 1);
            //Bổ sung quân cờ đi
            movement += Convert.ToChar(97 + p.column).ToString() + (p.row + 1).ToString();
            //Cộng điểm từ quân cờ bị ăn
            player[turn % 2].score += cScore;
            //Nếu ăn được quân đối phương (không phải là di chuyển đến ô trống)
            if (cScore != 0)
            {
                //Kí hiệu của nước đi ăn quân là chữ x
                movement += "x";
                //Thêm quân cờ ăn được vào thông tin người chơi
                player[turn % 2].AddEatenPiece(this.Image, this.cName);
            }
            else
            {   //Kí hiệu nước đi di chuyển thông thường
                movement += "-";
            }
            //Bổ sung điểm đến
            movement += Convert.ToChar(97 + column).ToString() + (row + 1).ToString();
            //Hủy quân cờ hiện tại
            Dispose();
            //Di chuyển đến vị trí mới và xóa vị trí cũ
            #region Di chuyển đến vị trí mới và xóa vị trí cũ
            //Khởi tạo lại quân cờ dựa vào tên của quân cờ P
            string nc = p.cName;
            int t = 0;
            if (nc[0] == 'b')
                t = 1;
            switch (nc[1])
            {
                case 'P':
                    {
                        if (t == 0)
                            cw[row, column] = new WhitePawn(row, column);
                        else
                            cw[row, column] = new BlackPawn(row, column);
                    }; break;
                case 'R': cw[row, column] = new Rook(row, column, t); ; break;
                case 'N': cw[row, column] = new Knight(row, column, t); ; break;
                case 'B': cw[row, column] = new Bishop(row, column, t); ; break;
                case 'Q': cw[row, column] = new Queen(row, column, t); ; break;
                case 'K': cw[row, column] = new King(row, column, t); ; break;
            }
            cw[row, column].moved = true;
            instance.Controls.Add(cw[row, column]);
            //Xóa quân cờ ở vị trí cũ
            p.Reset_Temp();
            int r = p.row, c = p.column;
            p.Dispose();
            cw[r, c] = new AbstractChessPiece(r, c);
            instance.Controls.Add(cw[r, c]);
            #endregion
            //Nếu quân cờ di chuyển là Vua, kiểm tra có phải thực hiện Nhập thành hay không
            if (cw[row, column].GetType() == typeof(King))
            {
                //Đo khoảng cách bước đi, nếu abs = 2 tức là Vua đã đi 2 bước ~ Nhập thành
                int n = column - p.column;
                if (n == 2)
                {
                    cw[row, 5].Dispose();
                    cw[row, 5] = new Rook(row, 5, t);
                    cw[row, 5].moved = true;
                    instance.Controls.Add(cw[row, 5]);
                    cw[row, 7].Dispose();
                    cw[row, 7] = new AbstractChessPiece(row, 7);
                    instance.Controls.Add(cw[row, 7]);
                    movement = "O-O";
                }
                else if (n == -2)
                {
                    cw[row, 3].Dispose();
                    cw[row, 3] = new Rook(row, 3, t);
                    cw[row, 3].moved = true;
                    instance.Controls.Add(cw[row, 3]);
                    cw[row, 0].Dispose();
                    cw[row, 0] = new AbstractChessPiece(row, 0);
                    instance.Controls.Add(cw[row, 0]);
                    movement = "O-O-O";
                }
            }
            //Nếu quân cờ di chuyển là Chốt
            else if (cw[row, column].Get_name.Substring(1, 1) == "P")
            {
                //Chốt đi tới dòng cuối cùng, Trắng đi đến dòng 7, Đen đi đến dòng 0
                if (row == ((turn + 1) % 2) * 7)
                {
                    //Hiện form lựa chọn phong cấp
                    Promotion exm = new Promotion(turn);
                    //Nếu hiện form nhưng không lựa chọn thì form liên tục mở đến khi nào chọn xong
                    while (exm.Get_typename == typeof(AbstractChessPiece).Name.ToString())
                        exm.ShowDialog();
                    //Hủy quân cờ hiện tại
                    cw[row, column].Dispose();
                    //Tái tạo quân cờ dựa trên lựa chọn
                    switch (exm.Get_typename)
                    {
                        case "Queen": cw[row, column] = new Queen(row, column, turn); break;
                        case "Rook": cw[row, column] = new Rook(row, column, turn); break;
                        case "Bishop": cw[row, column] = new Bishop(row, column, turn); break;
                        case "Knight": cw[row, column] = new Knight(row, column, turn); break;
                    }
                    //Ghi chép phong cờ là kí tự =
                    movement += "=" + cw[row, column].Get_name.Substring(1, 1);
                    instance.Controls.Add(cw[row, column]);
                }
                //Quân cờ đi là Chốt, và thuộc tính bắt chốt qua đường đang tồn tại
                else if (EP != null)
                {
                    //Kiểm tra xem có phải Chốt vừa thực hiện bắt chốt qua đường hay không
                    //Vì bản chất Chốt đi thẳng, ăn chéo nên phức tạp hơn
                    if (column == EP.y && Math.Abs(row - EP.x) == 1 && (p.row - EP.x == 0) && (Math.Abs(p.column - EP.y) == 1))
                    {
                        player[turn % 2].AddEatenPiece(cw[EP.x, EP.y].Image, cw[EP.x, EP.y].cName);
                        player[turn % 2].score += cw[EP.x, EP.y].cScore;
                        cw[EP.x, EP.y].Dispose();
                        cw[EP.x, EP.y] = new AbstractChessPiece(EP.x, EP.y);
                        instance.Controls.Add(cw[EP.x, EP.y]);
                        movement += "x";
                    }
                }
            }
            //Quân cờ thực hiện bắt chốt qua đường hay không cũng xem như là không còn khả năng bắt chốt qua đường nữa
            EP = null;
            //Nếu chốt khởi đầu đi 2 bước
            if (cw[row, column].Get_name.Substring(1, 1) == "P" && (Math.Abs(row - p.row) == 2))
            {
                EP = new Piece(row, column);
            }
            //Ghi chép vào nhật kí
            instance.lbHistory.Items.Add(movement);
            instance.lbHistory.TopIndex = instance.lbHistory.Items.Count - 1;
        }

        //Nguyễn Quang Thạch
        //Đánh dấu nước đi đến tọa độ x,y
        protected void Mark_Move(int x, int y, int t)
        {
            if ((x >= 0 && x <= 7) && (y >= 0 && y <= 7))
            {
                //Lấy chữ cái đầu tiên để xác định màu quân cờ
                string c1 = cName.Substring(0, 1);
                string c2 = cw[x, y].cName;
                if (c2 != "")
                    c2 = c2.Substring(0, 1);
                if (c1 != c2)
                {
                    if (c2 == "")   //Ô trống tức là nước đi di chuyển
                    {
                        Piece tmp = new Piece(x, y); mov.Add(tmp);
                    }
                    else            //Ô không trống tức là nước đi ăn quân cờ
                    {
                        Piece tmp = new Piece(x, y); eat.Add(tmp);
                    }
                    //Nếu lượt đi truyền vào tham số là lượt hiện tại, xét xem lượt đi có đúng hay không
                    //Giả sử di chuyển quân cờ và xem vua bị chiếu hay không, nếu bị chiếu thì thu hồi nước đi
                    if (t == turn)
                    {
                        string p1 = cName;
                        string p2 = cw[x, y].cName;
                        Image p0 = Image;
                        cName = "";
                        cw[x, y].cName = p1;
                        if (CheckKing(turn) == true)
                        {
                            if (c2 == "")
                                mov.RemoveAt(mov.Count - 1);
                            else
                                eat.RemoveAt(eat.Count - 1);
                        }
                        cName = p1;
                        Image = p0;
                        cw[x, y].cName = p2;
                    }
                }
            }
        }

        //Huỳnh Viết Thám
        //Các thao tác thay đổi lượt đi
        protected void ChangeTurn()
        {
            //Thêm thời gian cho người chơi vừa hoàn thành nước đi
            player[turn % 2].time += Player.timeAdd;
            //Hoán đổi lượt đồng hồ
            if (turn % 2 == 0)
            {
                instance.lbTime1.Text = string.Format("{0:00}:{1:00}", player[0].time / 60, player[0].time % 60);
                instance.lbScore1.Text = player[0].score.ToString();
                instance.Timer1.Stop();
                instance.Timer2.Start();
            }
            else
            {
                instance.lbTime2.Text = string.Format("{0:00}:{1:00}", player[1].time / 60, player[1].time % 60);
                instance.lbScore2.Text = player[1].score.ToString();
                instance.Timer2.Stop();
                instance.Timer1.Start();
            }
            //Thay đổi lượt
            turn++;
            //Mô phỏng ưu thế mỗi bên
            GetAdvantage();
            //Đổi vị trí icon chỉ lượt đi
            instance.pbDevil.Location = instance.pt[turn % 2];
            //Game thay đổi trạng thái, nếu tắt game sẽ hỏi có lưu hay không
            gameChanged = true;
            //Xem tình hình game hiện tại
            CheckCurrentGame();
        }
        #endregion

        //Nhóm hàm public
        #region Nhóm hàm public
        //Nguyễn Quang Thạch
        //Mô phỏng ưu thế cờ của mỗi bên, cập nhật giá trị vào thành progressbar
        public void GetAdvantage()
        {
            //Mảng số nguyên a lần lượt là giá trị điểm số (theo đánh giá) ưu thế của mỗi bên
            int[] a = new int[2];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cw[i, j].cName != "")
                    {
                        //Điểm ưu thế mô phỏng += tổng số nước đi có thể đi + tổng số quân cờ có thể ăn + tổng giá trị những quân cờ có thể ăn được
                        if (cw[i, j].cName.Substring(0, 1) == turnN[turn % 2])
                        {
                            cw[i, j].Move_Chess(turn);
                            a[turn % 2] += cw[i, j].Get_EatRange.Count + cw[i, j].Get_MoveRange.Count + cw[i, j].GetValueCanEat() + player[turn % 2].score;
                        }
                        else
                        {
                            cw[i, j].Move_Chess(turn + 1);
                            a[(turn + 1) % 2] += cw[i, j].Get_EatRange.Count + cw[i, j].Get_MoveRange.Count + cw[i, j].GetValueCanEat() + player[(turn + 1) % 2].score;
                        }
                        cw[i, j].Reset_Temp();
                    }
                }
            }
            //Cập nhật mô phỏng trên thanh progress
            instance.prgAdvantage.Maximum = a[0] + a[1];
            instance.prgAdvantage.Value = a[0];
        }

        //Lê Thanh Tâm + Nguyễn Quang Thạch + Huỳnh Viết Thám
        //Thao tác lựa chọn trên một quân cờ, dựa vào quân cờ trước đó để chọn trường hợp
        public void SelectPiece()
        {
            //Lấy màu chữ của quân cờ vừa chọn và quân cờ trước đó
            string s1 = cName, s2 = "";
            if (s1 != "")
                s1 = s1[0].ToString();
            if (tmp != null)
            {
                s2 = tmp.cName;
                s2 = s2[0].ToString();
            }
            //Click vào ô cùng lượt đi
            if (s1 == turnN[turn % 2])
            {
                if (tmp != null)
                    tmp.Reset_Temp();
                //Xóa và gán lại quân cờ tạm, hiển thị gợi ý
                tmp = this;
                Move_Chess(turn);
                Set_Hint();
            }
            //Click vào ô trống
            else if (s1 == "")
            {
                if (s2 == turnN[(turn) % 2])
                {
                    Piece p = new Piece(row, column);
                    //Đi được
                    if (CanGoTo(p) == 0)
                    {
                        MoveFromP(ref tmp);
                        pivot++;
                        while (pivot <= instance.hst.Count - 1 && instance.hst.Count != 1)
                        {
                            instance.hst.RemoveAt(instance.hst.Count - 1);
                        }
                        string t = instance.LoadHistory() + "\n" + turn.ToString() + "\n" + player[0].time + "\n" + player[1].time + "\n" + player[0].score.ToString() + "\n" + player[1].score.ToString() + "\n" + player[0].eaten + "\n" + player[1].eaten + "\n";
                        instance.hst.Add(t);
                        ChangeTurn();
                    }
                    //Không đi được
                    else
                    {
                        if (tmp != null)
                            tmp.Reset_Temp();
                        tmp = null;
                    }
                }
                else
                {
                    if (tmp != null)
                        tmp.Reset_Temp();
                    tmp = null;
                }
            }
            //click vào ô khác lượt đi
            else
            {
                if (s2 == turnN[turn % 2])
                {
                    Piece p = new Piece(row, column);
                    //ăn được
                    if (CanGoTo(p) == 1)
                    {
                        MoveFromP(ref tmp);
                        pivot++;
                        while(pivot<=instance.hst.Count - 1 && instance.hst.Count != 1)
                        {
                            instance.hst.RemoveAt(instance.hst.Count - 1);
                        }
                        string t = instance.LoadHistory() + "\n" + turn.ToString() + "\n" + player[0].time + "\n" + player[1].time + "\n" + player[0].score.ToString() + "\n" + player[1].score.ToString() + "\n" + player[0].eaten + "\n" + player[1].eaten + "\n";
                        instance.hst.Add(t);
                      
                        ChangeTurn();
                    }
                    //Không ăn được
                    else
                    {
                        if (tmp != null)
                            tmp.Reset_Temp();
                        tmp = null;
                    }
                }
                else
                {
                    if (tmp != null)
                        tmp.Reset_Temp();
                    tmp = null;
                }
            }
        }
        #endregion

        //Nguyễn Quang Thạch
        //Nhóm hàm get giá trị
        #region
        public List<Piece> Get_EatRange
        {   get
            {
                return eat;
            }
        }
        public List<Piece> Get_MoveRange
        {   get
            {
                return mov;
            }
        }
        public int Get_row
        {   get
            {
                return row;
            }
        }
        public int Get_column
        {   get
            {
                return column;
            }
        }
        public string Get_name
        {   get
            {
                return cName;
            }
        }
        //Lấy tổng giá trị của những quân cờ có thể ăn được
        private int GetValueCanEat()
        {
            int result = 0;
            for (int i = 0; i < eat.Count; i++)
            {
                result += cw[eat[i].x, eat[i].y].cScore;
            }
            return result;
        }
        #endregion

    }
}
public class Piece
{
    //Nguyễn Quang Thạch
    //Class điểm, gồm tọa độ x,y
    public int x, y;
    public Piece(int r, int c)
    {
        x = r;
        y = c;
    }
}