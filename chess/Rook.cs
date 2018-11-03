using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static chess.Form1;
namespace chess
{
    class Rook : AbstractChessPiece
    {
        //Lê Thanh Tâm
        public Rook(int r, int c, int turn):base(r, c)
        {
            cName = turnN[turn % 2] + "R";
            Image = Image.FromFile(Environment.CurrentDirectory + "\\" + instance.defIcon + "\\" + cName + ".PNG");
            cScore = 7;
        }
        public override void Move_Chess(int t)
        {
            base.Move_Chess(t);
            //Xét khả năng đi đến cách đường thẳng từ vị trí hiện tại, sẽ dừng khi ra khỏi bàn cờ hoặc gặp quân cờ bất kì
            for (int i=column+1;i<8;i++)
            {
                Mark_Move(row, i, t);
                if (cw[row, i].Get_name != "")
                    break;
            }
            for (int i = column - 1; i>=0; i--)
            {
                Mark_Move(row, i, t);
                if (cw[row, i].Get_name != "")
                    break;
            }
            for (int i = row + 1; i < 8; i++)
            {
                Mark_Move(i, column, t);
                if (cw[i, column].Get_name != "")
                    break;
            }
            for (int i = row - 1; i >=0; i--)
            {
                Mark_Move(i, column, t);
                if (cw[i, column].Get_name != "")
                    break;
            }
        }
    }
}
