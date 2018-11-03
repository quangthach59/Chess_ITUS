using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static chess.Form1;
using System.Windows.Forms;
namespace chess
{
    class King:AbstractChessPiece
    {
        //Nguyễn Quang Thạch
        public King(int r, int c, int turn) : base(r, c)
        {
            cName = turnN[turn % 2] + "K";
            Image = Image.FromFile(Environment.CurrentDirectory + "\\" + instance.defIcon + "\\" + cName + ".PNG");
            cScore = 100;
        }
        public override void Move_Chess(int t)
        {
            base.Move_Chess(t);
            //Kiểm tra khả năng đi đến những ô xung quanh
            Mark_Move(row + 1, column + 1, t);
            Mark_Move(row + 1, column, t);
            Mark_Move(row + 1, column - 1, t);
            Mark_Move(row, column + 1, t);
            Mark_Move(row, column - 1, t);
            Mark_Move(row - 1, column + 1, t);
            Mark_Move(row - 1, column, t);
            Mark_Move(row - 1, column - 1, t);
            //Nếu vua chưa di chuyển và đang không bị chiếu
            if (moved == false && t==turn && CheckKing(t)==false)
            {
                //Kiểm tra điều kiện nhập thành cánh trái (cánh Hậu)
                if (LeftCastling(t) == true && cw[row, 0].Get_name== turnN[t % 2] + "R")
                    Mark_Move(row, column - 2, t);
                //Kiểm tra điều kiện nhập thành cánh phải (cánh Vua)
                if (RightCastling(t) == true && cw[row, 7].Get_name == turnN[t % 2] + "R")
                    Mark_Move(row, column + 2, t);
            }
        }
        private bool LeftCastling(int t)
        {
            //Kiểm tra những ô mà vua có thể đi tới có ô cột 3 hay không
            for (int i = 0; i < mov.Count; i++)
            {
                if (mov[i].x == 7 * (t % 2) && mov[i].y == 3)
                    return true;
            }
            return false;
        }
        private bool RightCastling(int t)
        {
            //Kiểm tra những ô mà vua có thể đi tới có ô cột 5 hay không
            for (int i = 0; i < mov.Count; i++)
            {
                if (mov[i].x == 7 * (t % 2) && mov[i].y == 5)
                    return true;
            }
            return false;
        }
    }
}
