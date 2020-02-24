using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WoerterLernen.ViewModels
{
    public class TestPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private double x;

        public double X
        {
            get { return x; }
            set { x = value; OnPropertyChanged(); }
        }

        private double y;

        public double Y
        {
            get { return y; }
            set { y = value; OnPropertyChanged(); }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }

        private double prevX;

        public double PrevX
        {
            get { return prevX; }
            set { prevX = value; OnPropertyChanged(); }
        }

        private double rotation;

        public double Rotation
        {
            get { return rotation; }
            set { rotation = value; OnPropertyChanged(); }
        }



    }
}
