using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace chess
{
	partial class frmAbout : Form
	{
        //Nguyễn Quang Thạch
		public frmAbout()
		{
			InitializeComponent();
            //Load icon và các hình ảnh để hiển thị
            pbGroup.Image = Image.FromFile(Environment.CurrentDirectory + "\\img\\group.JPG");
            pbGroup.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.Image = Image.FromFile(Environment.CurrentDirectory + "\\img\\hcmus_logo.PNG");
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            Icon = Icon.ExtractAssociatedIcon(Environment.CurrentDirectory + "\\img\\logo.ico");
            pbLogoDesign.Image = Image.FromFile(Environment.CurrentDirectory + "\\img\\logo.PNG");
        }
    }
}
