using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Threading;

namespace PostXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LinternaView : ContentPage
	{
        static Dictionary<char, string> translator;
        public LinternaView ()
		{
			InitializeComponent ();
            InitialiseDictionary();
            this.btnencender.Clicked += Btnencender_Clicked;
            this.btnapagar.Clicked += Btnapagar_Clicked;
            this.btnmorse.Clicked += Btnmorse_Clicked;
            this.btnmorsetext.Clicked += Btnmorsetext_Clicked;


        }

        private void Btnmorsetext_Clicked(object sender, EventArgs e)
        {
            String texto = this.txtTexto.Text;
            this.lblmorse.Text = translate(texto);
            
        }

        private void Btnmorse_Clicked(object sender, EventArgs e)
        {
            String texto = this.txtTexto.Text;
            String morse = translate(texto);
            Thread.Sleep(500);

            foreach (char letra in morse)
            {
                
                if (letra == '.')
                {

                    Flashlight.TurnOnAsync();
                    Thread.Sleep(500);
                    Flashlight.TurnOffAsync();
                }
                if (letra == '−')
                {
                    Flashlight.TurnOnAsync();
                    Thread.Sleep(1300);
                    Flashlight.TurnOffAsync();
                }
                if (letra == '/')
                {
                    Flashlight.TurnOffAsync();
                    Thread.Sleep(2000);                    
                }
            }
        }

        private void Btnapagar_Clicked(object sender, EventArgs e)
        {
          
                // Turn On
                Flashlight.TurnOffAsync();
        }

        private  void Btnencender_Clicked(object sender, EventArgs e)
        {
            
                // Turn On
                  Flashlight.TurnOnAsync();
        }


        private static void InitialiseDictionary()
        {
            char dot = '.';
            char dash = '−';

            translator = new Dictionary<char, string>()
            {
                {'a', string.Concat(dot, dash)},
                {'b', string.Concat(dash, dot, dot, dot)},
                {'c', string.Concat(dash, dot, dash, dot)},
                {'d', string.Concat(dash, dot, dot)},
                {'e', dot.ToString()},
                {'f', string.Concat(dot, dot, dash, dot)},
                {'g', string.Concat(dash, dash, dot)},
                {'h', string.Concat(dot, dot, dot, dot)},
                {'i', string.Concat(dot, dot)},
                {'j', string.Concat(dot, dash, dash, dash)},
                {'k', string.Concat(dash, dot, dash)},
                {'l', string.Concat(dot, dash, dot, dot)},
                {'m', string.Concat(dash, dash)},
                {'n', string.Concat(dash, dot)},
                {'o', string.Concat(dash, dash, dash)},
                {'p', string.Concat(dot, dash, dash, dot)},
                {'q', string.Concat(dash, dash, dot, dash)},
                {'r', string.Concat(dot, dash, dot)},
                {'s', string.Concat(dot, dot, dot)},
                {'t', string.Concat(dash)},
                {'u', string.Concat(dot, dot, dash)},
                {'v', string.Concat(dot, dot, dot, dash)},
                {'w', string.Concat(dot, dash, dash)},
                {'x', string.Concat(dash, dot, dot, dash)},
                {'y', string.Concat(dash, dot, dash, dash)},
                {'z', string.Concat(dash, dash, dot, dot)},
                {'0', string.Concat(dash, dash, dash, dash, dash)},
                {'1', string.Concat(dot, dash, dash, dash, dash)},
                {'2', string.Concat(dot, dot, dash, dash, dash)},
                {'3', string.Concat(dot, dot, dot, dash, dash)},
                {'4', string.Concat(dot, dot, dot, dot, dash)},
                {'5', string.Concat(dot, dot, dot, dot, dot)},
                {'6', string.Concat(dash, dot, dot, dot, dot)},
                {'7', string.Concat(dash, dash, dot, dot, dot)},
                {'8', string.Concat(dash, dash, dash, dot, dot)},
                {'9', string.Concat(dash, dash, dash, dash, dot)}
            };
        }
        private static string translate(string input)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char character in input)
            {
                if (translator.ContainsKey(character))
                {
                    sb.Append(translator[character] + " ");
                }
                else if (character == ' ')
                {
                    sb.Append("/ ");
                }
                else
                {
                    sb.Append(character + " ");
                }
            }
            return sb.ToString();
        }
    }
}