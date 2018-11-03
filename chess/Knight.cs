using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static chess.Form1;
namespace chess
{
    class Knight:AbstractChessPiece
    {
        //Huỳnh Viết Thám
        public Knight(int r, int c, int turn) : base(r, c)
        {
            cName = turnN[turn % 2] + "N";
            Image = Image.FromFile(Environment.CurrentDirectory + "\\" + instance.defIcon + "\\" + cName + ".PNG");
            cScore = 2;         
        }
        public override void Move_Chess(int t)
        {
            base.Move_Chess(t);
            //Xét các khả năng di chuyển, quân Mã có nhiều nhất 8 khả năng di chuyển đến những ô xung quanh
            Mark_Move(row + 1, column + 2, t);
            Mark_Move(row + 1, column - 2, t);
            Mark_Move(row - 1, column + 2, t);
            Mark_Move(row - 1, column - 2, t);
            Mark_Move(row + 2, column + 1, t);
            Mark_Move(row + 2, column - 1, t);
            Mark_Move(row - 2, column + 1, t);
            Mark_Move(row - 2, column - 1, t);
        }
    }
}
