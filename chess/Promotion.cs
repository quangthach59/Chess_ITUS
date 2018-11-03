using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace chess
{
	public partial class Promotion : Form
	{
        //Huỳnh Viết Thám
        public static AbstractChessPiece tmp = new AbstractChessPiece();
        public static Promotion promo;
		public Promotion(int t):base()
		{
            //Tham số t truyền vào là lượt đi của quân phong cờ
            //t chẵn là quân Trắng, t lẻ là quân Đen
            InitializeComponent();
            //Load icon của form
            Icon = Icon.ExtractAssociatedIcon(Environment.CurrentDirectory + "\\img\\logo.ico");
            //Gán promo là this để có thể truy xuất trong hàm static
            promo = this;
            //Xóa lựa chọn trước đó nếu có
            if (tmp!=null)
            {
                tmp.Dispose();
                tmp = new AbstractChessPiece();
            }
            //Khởi tạo 4 lựa chọn quân cờ
            AbstractChessPiece[] p = new AbstractChessPiece[4];
            p[0] = new Queen(0, 0, t);
            p[1] = new Rook(0, 1, t);
            p[2] = new Bishop(0, 2, t);
            p[3] = new Knight(0, 3, t);
            for (int i = 0; i < 4; i++)
            {
                p[i].Location = new Point(3 + i * AbstractChessPiece.piece_size, 3);
                p[i].MouseClick += AbstractChessPiece_Click;
                p[i].MouseClick -= Form1.AbstractChessPiece_Click;
                Controls.Add(p[i]);
            }           
        }
		public static void AbstractChessPiece_Click(object sender, EventArgs e)
		{   
            //Gán quân cờ tmp bằng quân cờ được chọn
			AbstractChessPiece s = (AbstractChessPiece)sender;
            tmp = s;
            promo.Close();
		}
        public string Get_typename
        {
            //Lấy tên của kiểu quân cờ, trả về chuỗi
            get
            {
                return tmp.GetType().Name;
            }
        }
    }
}
