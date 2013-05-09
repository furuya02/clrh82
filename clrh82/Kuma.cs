using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Forms;

namespace clrh82{
    public class Kuma{
        private readonly ImageList _imageList;
        private readonly PictureBox _pictureBox;
        private Status _status = Status.Idle;

        private int _count;

        public Kuma(ImageList imageList, PictureBox pictureBox){
            _imageList = imageList;
            _pictureBox = pictureBox;
        }

        public void SetStatus(Status status){
            _status = status;
            switch (_status) {
                case Status.Idle:
                    _pictureBox.Image = _imageList.Images[0];
                    break;
                case Status.Try:
                    _count = 0;
                    _pictureBox.Image = _imageList.Images[10];
                    break;
                case Status.Die:
                    _count = 0;
                    _pictureBox.Image = _imageList.Images[8];
                    break;
            }
        }

        public Status Action(){
            _count++;
            if (_status == Status.Try){
                if (4 < _count){
                    SetStatus(Status.Idle);
                }
            }
            if (_status == Status.Die){
                if (6 < _count){
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

