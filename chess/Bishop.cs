using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static chess.Form1;
namespace chess
{
    class Bishop:AbstractChessPiece
    {
        //Lê Thanh Tâm
        public Bishop(int r, int c, int turn):base(r,c)
        {
            cName = turnN[turn % 2] + "B";
            Image = Image.FromFile(Environment.CurrentDirectory + "\\" + instance.defIcon + "\\" + cName + ".PNG");          
            cScore = 3;         
        }
        public override void Move_Chess(int t)
        {
            base.Move_Chess(t);
            int i = row, j = column;
            //Xét khả năng đi đến cách đường chéo từ vị trí hiện tại, sẽ dừng khi ra khỏi bàn cờ hoặc gặp quân cờ bất kì
            while (i<7 && j<7)
            {
                i++; j++;
                Mark_Move(i, j, t);
                if (cw[i, j].Get_name != "")
                    break;
            }
            i = row; j = column;
            while (i > 0 && j > 0)
            {
                i--; j--;
                Mark_Move(i, j, t);
                if (cw[i, j].Get_name != "")
                    break;
            }
            i = row; j = column;
            while (i > 0 && j < 7)
            {
                i--; j++;
                Mark_Move(i, j, t);
                if (cw[i, j].Get_name != "")
                    break;
            }
            i = row; j = column;
            while (i < 7 && j > 0)
            {
                i++; j--;
                Mark_Move(i, j, t);
                if (cw[i, j].Get_name != "")
                    break;
            }
        }
        
    }
}
