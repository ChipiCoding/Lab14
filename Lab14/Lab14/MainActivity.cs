using Android.App;
using Android.Widget;
using Android.OS;
using SALLab14;

namespace Lab14
{
    [Activity(Label = "Lab14", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button buttonValidate = FindViewById<Button>(Resource.Id.buttonValidate);
            buttonValidate.Click += delegate
            {
                ValidateAsync();
            };
        }

        public async void ValidateAsync()
        {
            ServiceClient Service = new ServiceClient();
            ResultInfo SvcResult = await Service.ValidateAsync(this);

            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alert = builder.Create();
            alert.SetTitle("Resultado de la verificación");
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage($"{SvcResult.Status}\n{SvcResult.FullName}\n{SvcResult.Token}");
            alert.SetButton("Ok", (s, ev) => { });
            alert.Show();
            //FindViewById<TextView>(Resource.Id.TextViewResult).Text = $"\n{SvcResult.Status.ToString()}\n{SvcResult.Token}";
            //ValidationData.Result = $"\n{SvcResult.Status.ToString()}\n{SvcResult.Token}";
        }
    }
}

