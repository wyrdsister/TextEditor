using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpicyEditor
{
    public class SkinResourceDictionary : ResourceDictionary
    {
        private Uri _greenSource;
        private Uri _blueSource;
        private Uri _purpleSource;

        public Uri GreenSource
        {
            get { return _greenSource; }
            set
            {
                _greenSource = value;
                UpdateSource();
            }
        }

        public Uri BlueSource
        {
            get { return _blueSource; }
            set
            {
                _blueSource = value;
                UpdateSource();
            }
        }

        public Uri PurpleSource
        {
            get { return _purpleSource; }
            set
            {
                _purpleSource = value;
                UpdateSource();
            }
        }

        public void UpdateSource()
        {
            var val = MainWindow.Skin == Skin.Green ? GreenSource : (MainWindow.Skin == Skin.Blue ? BlueSource : PurpleSource);
            if (val != null && base.Source != val)
                base.Source = val;
        }
    }
}