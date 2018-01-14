using System.Threading.Tasks;
using Android.Media;
using LunchBoxApp.Domain.Services.Abstract;
using Xamarin.Forms;

[assembly: Dependency(typeof(LunchBoxApp.Droid.Services.PlatformSoundPlayer))]

namespace LunchBoxApp.Droid.Services
{
    public class PlatformSoundPlayer : ISoundPlayer
    {
        private MediaPlayer _notification;

        public Task PlaySuccessSound()
        {
            _notification = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.success);
            _notification.Start();

            return Task.Delay(0);
        }

        public Task PlayDeniedSound()
        {
            _notification = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.denied);
            _notification.Start();

            return Task.Delay(0);
        }
    }
}