#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

#endregion

namespace clrh82{
    public partial class Index : Form{
        private readonly KumaList _kumaList;
        private readonly List<PictureBox> _pictureList = new List<PictureBox>();

        public Index(){
            InitializeComponent();

            _pictureList.Add(pictureBox1);
            _pictureList.Add(pictureBox2);
            _pictureList.Add(pictureBox3);
            _pictureList.Add(pictureBox4);
            _pictureList.Add(pictureBox5);
            _pictureList.Add(pictureBox6);
            _pictureList.Add(pictureBox7);
            _pictureList.Add(pictureBox8);
            _pictureList.Add(pictureBox9);

            _kumaList = new KumaList(imageList1, _pictureList);
        }

        //var Path = Context.Server.MapPath("~/Resources/Designer/001.jpg");
        //pictureBox1.Image = new UrlResourceHandle("/Resources/Designer/001.jpg");
        //pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.UrlResourceHandle("http://address_of_my_image.jpg");

        private void timer1_Tick(object sender, EventArgs e){
            _kumaList.Action();
        }


        private void pictureBox3_MouseClick(object sender, MouseEventArgs e){
            timer1.Enabled = false;
            int target = -1;
            if (sender == pictureBox1){
                target = 0;
            } else if (sender == pictureBox2){
                target = 1;
            } else if (sender == pictureBox3){
                target = 2;
            } else if (sender == pictureBox4){
                target = 3;
            } else if (sender == pictureBox5){
                target = 4;
            } else if (sender == pictureBox6){
                target = 5;
            } else if (sender == pictureBox7){
                target = 6;
            } else if (sender == pictureBox8){
                target = 7;
            } else if (sender == pictureBox9){
                target = 8;
            }
            _kumaList.Click(target);
            timer1.Enabled = true;
        }

        private void Index_SizeChanged(object sender, EventArgs e){
            int width = Width;
            if (width < 0){
                return;
            }
            int height = Height;
            if (height < 0) {
                return;
            }
            //縦横の小さい数値を使用する
            int max = width;
            if (height < max){
                max = height;
            }
            //余白計算
            int size = (max - 20) / 3;
            int margin = max - (size*3);
            margin = margin /= 2;

            for (int i = 0; i < 9; i++){
                _pictureList[i].Width = size;
                _pictureList[i].Height = size;
            }


            _pictureList[0].Left = margin;
            _pictureList[1].Left = margin + size;
            _pictureList[2].Left = margin + size*2;

            _pictureList[3].Left = margin;
            _pictureList[4].Left = margin + size;
            _pictureList[5].Left = margin + size*2;

            _pictureList[6].Left = margin;
            _pictureList[7].Left = margin + size;
            _pictureList[8].Left = margin + size*2;


            _pictureList[0].Top = margin;
            _pictureList[1].Top = margin;
            _pictureList[2].Top = margin;

            _pictureList[3].Top = margin + size;
            _pictureList[4].Top = margin + size;
            _pictureList[5].Top = margin + size;

            _pictureList[6].Top = margin + size*2;
            _pictureList[7].Top = margin + size*2;
            _pictureList[8].Top = margin + size*2;

        }

        private void Index_KeyDown(object objSender, KeyEventArgs objArgs) {
            //if()
        }
    }
}
