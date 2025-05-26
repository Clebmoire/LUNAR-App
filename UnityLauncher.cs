using Android.Content;
using Android.Util;
using UniApp.Platforms.Android;
using UniApp.Services;

[assembly: Dependency(typeof(UniApp.Platforms.Android.UnityLauncher))]

namespace UniApp.Platforms.Android
{
    public class UnityLauncher : IUnityLauncher
    {
        public void LaunchUnity(string destinationName)
        {
            try
            {
                var context = global::Android.App.Application.Context;
                var intent = new Intent();
                intent.SetClassName(context, "com.unity3d.player.UnityPlayerActivity");
                intent.PutExtra("destinationName", destinationName);
                intent.AddFlags(ActivityFlags.NewTask);

                context.StartActivity(intent);
                Log.Debug("UnityLauncher", $"Launching Unity with destination: {destinationName}");
            }
            catch (System.Exception ex)
            {
                Log.Error("UnityLauncher", $"Failed to launch Unity: {ex.Message}");
            }
        }
    }
}
