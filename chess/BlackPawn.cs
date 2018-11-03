using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static chess.Form1;
namespace chess
{
    class BlackPawn:AbstractChessPiece
    {
        //Huỳnh Viết Thám
        public BlackPawn(int r, int c) : base(r, c)
        {
            Image = Image.FromFile(Environment.CurrentDirectory + "\\" + instance.defIcon + "\\" + "bP.PNG");
            cScore = 1;
            cName = "bP";           
        }
        public override void Move_Chess(int t)
        {
            base.Move_Chess(t);
            //Quân cờ chưa đi đến hàng cuối cùng
            if (row!=0)
            {
                //Trước mặt không có quân cờ, 
                if (cw[row - 1, column].Get_name == "")
                    Mark_Move(row - 1, column, t);
                //Chốt đang ở vị trí ban đầu, có thể đi 2 bước, với điều kiện ô trước mặt không có quân cờ
                if (row == 6 && cw[row - 1, column].Get_name == "" && cw[row - 2, column].Get_name == "")
                    Mark_Move(row - 2, column, t);
                //Ăn quân cờ bên phải
                if (column != 7 && cw[row - 1, column + 1].Get_name != "")
                    Mark_Move(row - 1, column + 1, t);
                //Ăn quân cờ bên trái
                if (column !=0 && cw[row - 1, column - 1].Get_name != "")
                    Mark_Move(row - 1, column - 1, t);
                //Phát hiện có quân chốt đối phương đi 2 bước
                if (EP != null)
                    if (row == EP.x && Math.Abs(column - EP.y) == 1)
                        Mark_Move(row - 1, EP.y, t);
            }            
        }
    }
}
