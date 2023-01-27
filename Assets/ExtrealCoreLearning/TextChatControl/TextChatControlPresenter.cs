using Extreal.Core.Common.System;
using UniRx;
using VContainer.Unity;

namespace ExtrealCoreLearning.TextChatControl
{
    public class TextChatControlPresenter : DisposableBase, IInitializable
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

        protected override void ReleaseManagedResources()
        {
            disposables.Dispose();
        }
    }
}