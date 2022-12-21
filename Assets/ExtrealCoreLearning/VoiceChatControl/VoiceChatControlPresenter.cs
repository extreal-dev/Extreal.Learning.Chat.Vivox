using System;
using UniRx;
using VContainer.Unity;

namespace ExtrealCoreLearning.VoiceChatControl
{
    public class VoiceChatControlPresenter : IInitializable, IDisposable
    {
        private readonly VoiceChatControlView voiceChatControlView;
        private readonly CompositeDisposable disposables = new CompositeDisposable();

        private readonly VoiceChatChannel voiceChatChannel;
        
        public VoiceChatControlPresenter(VoiceChatControlView voiceChatControlView)
        {
            this.voiceChatControlView = voiceChatControlView;
            voiceChatChannel = new VoiceChatChannel();
        }
        
        public void Initialize()
        {
            voiceChatChannel.IsMute.Subscribe(isMute =>
            {
                voiceChatControlView.toggleMute(isMute);
            }).AddTo(disposables);

            voiceChatControlView.OnVoiceButtonClicked.Subscribe(_ =>
            {
                voiceChatChannel.ToggleMute();
            }).AddTo(disposables);
        }

        public void Dispose()
        {
            voiceChatChannel.Dispose();
            disposables.Dispose();
        }
    }
}