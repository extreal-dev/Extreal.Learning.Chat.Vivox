using System;
using UniRx;

namespace ExtrealCoreLearning.VoiceChatControl
{
    public class VoiceChatChannel : IDisposable
    {
        public IObservable<bool> IsMute => isMute;
        private ReactiveProperty<bool> isMute = new ReactiveProperty<bool>();

        public VoiceChatChannel()
        {
            isMute.Value = true;
        }

        public void ToggleMute()
        {
            isMute.Value = !isMute.Value;
        }

        public void Dispose()
        {
            isMute.Dispose();
        }
    }
}