using System;
using UniRx;
using VContainer.Unity;

namespace ExtrealCoreLearning.TextChatControl
{
    public class TextChatControlPresenter : IInitializable, IDisposable
    {
        private readonly TextChatControlView textChatControlView;

        private readonly CompositeDisposable disposables = new CompositeDisposable();

        public TextChatControlPresenter(TextChatControlView textChatControlView)
        {
            this.textChatControlView = textChatControlView;
        }

        public void Initialize()
        {
            textChatControlView.OnSendButtonClicked.Subscribe(message =>
            {
                textChatControlView.ShowTextChatMessage(message);
            }).AddTo(disposables);
        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}