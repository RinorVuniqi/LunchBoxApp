using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVFoundation;
using Foundation;
using LunchBoxApp.Domain.Services.Abstract;
using UIKit;

namespace LunchBoxApp.iOS.Services
{
    public class PlatformSoundPlayer : ISoundPlayer
    {
        private AVAudioPlayer _notification;
        private string successPath = "Sounds/success.mp3";
        private string deniedPath = "Sounds/denied.mp3";

        public Task PlaySuccessSound()
        {
            var session = AVAudioSession.SharedInstance();
            session.SetCategory(AVAudioSessionCategory.Ambient);
            session.SetActive(true);

            NSUrl soundUrl = new NSUrl(successPath);
            NSError err;
            _notification = new AVAudioPlayer(soundUrl, "mp3", out err);
            _notification.Play();

            return Task.Delay(0);
        }

        public Task PlayDeniedSound()
        {
            var session = AVAudioSession.SharedInstance();
            session.SetCategory(AVAudioSessionCategory.Ambient);
            session.SetActive(true);

            NSUrl soundUrl = new NSUrl(deniedPath);
            NSError err;
            _notification = new AVAudioPlayer(soundUrl, "mp3", out err);
            _notification.Play();

            return Task.Delay(0);
        }
    }
}