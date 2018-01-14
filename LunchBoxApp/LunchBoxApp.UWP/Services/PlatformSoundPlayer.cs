using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using LunchBoxApp.Domain.Services.Abstract;
using Xamarin.Forms;

[assembly:Dependency(typeof(LunchBoxApp.UWP.Services.PlatformSoundPlayer))]

namespace LunchBoxApp.UWP.Services
{
    internal class PlatformSoundPlayer : ISoundPlayer
    {
        MediaElement _sound = new MediaElement();


        public async Task PlaySuccessSound()
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package
                .Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("success.mp3");
            var stream = await file.OpenReadAsync();
            _sound.SetSource(stream, file.ContentType);
            _sound.Play();
        }

        public async Task PlayDeniedSound()
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package
                .Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("denied.mp3");
            var stream = await file.OpenReadAsync();
            _sound.SetSource(stream, file.ContentType);
            _sound.Play();
        }
    }
}
