using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static chess.Form1;
namespace chess
{
    class Queen:Bishop
    {
        //Lê Thanh Tâm
        //Quân Hậu có khả năng của quân Tượng và quân Xe, ở đây cho quân Hậu kế thừa quân Tượng
        //và sao chép lại nước đi của quân Xe
        public Queen(int r, int c, int turn):base(r,c,turn)
        {
            cName = turnN[turn % 2].ToString() + "Q";
            Image = Image.FromFile(Environment.CurrentDirectory + "\\" + instance.defIcon + "\\" + cName + ".PNG");
            cScore = 10;
        }
        public override void Move_Chess(int t)
        {
            base.Move_Chess(t);
            int r = row, c = column;
            for (int i = column + 1; i < 8; i++)
            {
                Mark_Move(row, i, t);
                if (cw[row, i].Get_name != "")
                    break;
            }
            for (int i = column - 1; i >= 0; i--)
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
            for (int i = row - 1; i >= 0; i--)
            {
                Mark_Move(i, column, t);
                if (cw[i, column].Get_name != "")
                    break;
            }
        }
    }
}
