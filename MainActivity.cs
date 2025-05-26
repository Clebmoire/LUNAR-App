using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Webkit;
using Microsoft.Maui;
using UniApp.Services;

namespace UniApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                               ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity, IUnityLauncher
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        // Unity → MAUI messaging
        [Java.Interop.Export("SendToMaui")]
        [JavascriptInterface]
        public void SendToMaui(string message)
        {
            RunOnUiThread(() =>
            {
                if (message == "Arrived")
                {
                    Destination.Instance?.Arrival();
                }
                else if (message.StartsWith("Distance:"))
                {
                    string distanceStr = message.Replace("Distance:", "");
                    if (double.TryParse(distanceStr, out double distance))
                    {
                        Console.WriteLine($"Total Path Distance: {distance} meters");
                    }
                }
            });
        }

        // MAUI → Unity launching
        public void LaunchUnity(string destinationName)
        {
            try
            {
                var intent = new Intent(this, Java.Lang.Class.ForName("com.unity3d.player.UnityPlayerActivity"));
                intent.PutExtra("destination", destinationName);
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                Android.Util.Log.Error("UNITY_LAUNCH", "❌ Failed to launch Unity: " + ex.Message);
            }

        }

    }
}
