using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace DamageCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        const int level = 50;

        TextView lblAtk;
        EditText txtAtk;
        TextView lblHp;
        EditText txtHp;
        TextView lblDef;
        EditText txtDef;
        TextView lblPower;
        EditText txtPower;
        TextView lblPowerStat;
        EditText txtPowerStat;
        TextView lblStat;
        EditText txtStat;
        Button btnCal;
        TextView lblResult;
        TextView txtResult;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            lblAtk = FindViewById<TextView>(Resource.Id.lblAtk);
            txtAtk = FindViewById<EditText>(Resource.Id.txtAtk);
            lblHp = FindViewById<TextView>(Resource.Id.lblHp);
            txtHp = FindViewById<EditText>(Resource.Id.txtHp);
            lblDef = FindViewById<TextView>(Resource.Id.lblDef);
            txtDef = FindViewById<EditText>(Resource.Id.txtDef);
            lblPower = FindViewById<TextView>(Resource.Id.lblPower);
            txtPower = FindViewById<EditText>(Resource.Id.txtPower);
            lblPowerStat = FindViewById<TextView>(Resource.Id.lblPowerStat);
            txtPowerStat = FindViewById<EditText>(Resource.Id.txtPowerStat);
            lblStat = FindViewById<TextView>(Resource.Id.lblStat);
            txtStat = FindViewById<EditText>(Resource.Id.txtStat);

            lblResult = FindViewById<TextView>(Resource.Id.lblResult);
            txtResult = FindViewById<TextView>(Resource.Id.txtResult);

            FindViewById<Button>(Resource.Id.btnCal).Click += (o, e) =>
            {
                int atk = Convert.ToInt32(txtAtk.Text);
                int hp = Convert.ToInt32(txtHp.Text);
                int def = Convert.ToInt32(txtDef.Text);
                int power = Convert.ToInt32(txtPower.Text);
                double powerStat = Convert.ToDouble(txtPowerStat.Text);
                double stat = Convert.ToDouble(txtStat.Text);

                double damage;

                damage = level * 2 / 5 + 2;
                damage = Math.Floor(damage) * power * powerStat * atk / def / 50 + 2;
                damage = Math.Floor(damage) * 0.85;
                damage = Math.Floor(damage) * stat;
                damage = hp - Math.Floor(damage);

                txtResult.Text = Convert.ToString(damage);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}