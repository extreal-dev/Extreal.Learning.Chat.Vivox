using System;
using Extreal.Core.Common.System;
using UniRx;

namespace ExtrealCoreLearning.VoiceChatControl
{
    public class VoiceChatChannel : DisposableBase
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

        protected override void ReleaseManagedResources()
        {
            isMute.Dispose();
        }
    }
}