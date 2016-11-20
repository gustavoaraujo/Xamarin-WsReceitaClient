using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using WsReceita.Models;
using ClientRest.WS;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            TextView txData = FindViewById<TextView>(Resource.Id.txData);
            TextView txCancelada = FindViewById<TextView>(Resource.Id.txCancelada);
            TextView txNumReceita = FindViewById<TextView>(Resource.Id.txNumReceita);
            TextView txUtilizada = FindViewById<TextView>(Resource.Id.txUtilizada);
            EditText edtNumeroReceita = FindViewById<EditText>(Resource.Id.edtNumeroReceita);

            button.Click += delegate
            {
                string txtNumeroReceita = edtNumeroReceita.Text.ToString();

                int numero = 0;

                if (!int.TryParse(txtNumeroReceita, out numero))
                    Toast.MakeText(this, "Digite um número de receita válido.", ToastLength.Long).Show();
                else
                {
                    NumeroReceita numReceita = new NumeroReceita()
                    {
                        Numero = numero
                    };

                    Receita r = new Operacoes().ObterReceitaMedica(numReceita);

                    txData.Text = r.Data.ToString();
                    txCancelada.Text = r.Cancelada.ToString();
                    txNumReceita.Text = r.NumReceita.ToString();
                    txUtilizada.Text = r.Utilizada.ToString();
                }
            };
        }
    }
}

