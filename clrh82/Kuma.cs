using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Web;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Server;


namespace clrh82{
    public class Kuma{
        private readonly ImageList _imageList;
        private readonly PictureBox _pictureBox;
        private Status _status;
        private Random _random;
        private int _pattern;
        private int _count;

        public Kuma(ImageList imageList, PictureBox pictureBox){
            _imageList = imageList;
            _pictureBox = pictureBox;
            _random = new Random((int) DateTime.Now.Ticks);
            SetStatus(Status.Idle);

        }

        public void SetStatus(Status status){
            int imgNo = 0;
            _status = status;
            switch (_status) {
                case Status.Idle:
                    //0,1,2,3
                    _pattern = _random.Next(4);
                    break;
                case Status.Try:
                    _count = 0;
                    if (_pattern == 0){
                        imgNo = 10;
                    }else if (_pattern == 1){
                        imgNo = 1;
                    } else if (_pattern == 2) {
                        imgNo = 2;
                    } else if (_pattern == 3) {
                        imgNo = 3;
                    } else if (_pattern == 4) {
                        imgNo = 4;
                    }
                    break;
                case Status.Die:
                    _count = 0;
                    Console.Beep(196, 100);
                    if (_pattern == 0){
                        //6,7,8
                        imgNo += 6 + _random.Next(3);
                    }else{
                        //5
                        imgNo =  5;
                    }
                    break;
                case Status.Sleep:
                    _count = 0;
                    break;
            }
            _pictureBox.Image = _imageList.Images[imgNo];
        }

        public Status Action(){
            _count++;
            if (_status == Status.Try){
                if (6 < _count){
                    SetStatus(Status.Sleep);
                }
            }else if (_status == Status.Die){
                if (8 < _count){
                    SetStatus(Status.Sleep);
                }
            }else if (_status == Status.Sleep) {
                if (8 < _count) {
                    SetStatus(Status.Idle);
                }
            }
            return _status;
        }

        public Status GetStatus(){
            return _status;
        }
    }
}

