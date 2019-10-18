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
        private List<LernElement> lernElements = new List<LernElement>();

        public int CurElem { get; private set; }

        public TestPage()
        {
            InitializeComponent();
            IListInitializer listInit = new FromMemory();
            lernElements = listInit.Read();
            if (CurElem < lernElements.Count)
            {
                loadCurElem();
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
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
            ++CurElem;
            if (CurElem >= lernElements.Count)
            {
                CurElem = 0;
            }
            loadCurElem();
        }

        private void loadCurElem()
        {
            var el = lernElements[CurElem];
            ErsteWort.Text = el.ErsteSpracheWort;
            ErsteTranskription.Text = el.ErsteSpracheTranskription;
            Ubersetzung.Text = el.ZweiteSpracheWort;

            ErsteTranskription.IsVisible = !string.IsNullOrWhiteSpace(ErsteTranskription.Text);

            Fortschritt.Text = $"{CurElem + 1} Wort von {lernElements.Count}";
        }
        private void Nachste_Clicked(object sender, EventArgs e)
        {
            hideAntwortKnoepfe();
        }

        private void Richtig_Clicked(object sender, EventArgs e)
        {
            hideAntwortKnoepfe();
            loadNachsteElement();
        }

        private void Falsch_Clicked(object sender, EventArgs e)
        {
            hideAntwortKnoepfe();
            loadNachsteElement();
        }
    }
}