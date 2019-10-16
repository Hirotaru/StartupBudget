using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WoerterLernen
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TestPage : ContentPage
    {

        public TestPage()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }

        private void Check_Clicked(object sender, EventArgs e)
        {

        }

        private void Pruefen_Clicked(object sender, EventArgs e)
        {
            showAntwortKnoepfe();
        }
        private void hideAntwortKnoepfe()
        {
            Ubersetzung.IsVisible = false;
            AntwortKnoepfe.IsVisible = false;
        }

        private void showAntwortKnoepfe()
        {
            Ubersetzung.IsVisible = true;
            AntwortKnoepfe.IsVisible = true;
        }
        private void loadNachsteElement()
        {

        }
        private void Nachste_Clicked(object sender, EventArgs e)
        {
            hideAntwortKnoepfe();
        }

        private void Richtig_Clicked(object sender, EventArgs e)
        {
            hideAntwortKnoepfe();
        }

        private void Falsch_Clicked(object sender, EventArgs e)
        {
            hideAntwortKnoepfe();
        }
    }
}