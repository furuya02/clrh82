using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Forms;

namespace clrh82 {
    public class KumaList {
        readonly List<Kuma> _ar = new List<Kuma>();
        private Random _random;

        public KumaList(ImageList imageList,IEnumerable<PictureBox> pictureList){
            _random = new Random(DateTime.Now.Second);
            
            foreach (var picture in pictureList) {
                _ar.Add(new Kuma(imageList, picture));
            }
            
        }

        public void Action(){
            lock (this){
                var tryCount = 0;
                foreach (var kuma in _ar) {
                    if (Status.Try == kuma.Action()) {
                        tryCount++;
                    }
                }
                while (tryCount < 2) {
                    int index = _random.Next(9);
                    if (_ar[index].GetStatus() == Status.Idle) {
                        _ar[index].SetStatus(Status.Try);
                        tryCount++;
                    }

                }
            }
        }

        public void Click(int target){
            if (target < 0){
                return;
            }
            lock (this){
                if (Status.Try == _ar[target].GetStatus()) {
                    _ar[target].SetStatus(Status.Die);
                }
            }
            
        }
    }
}