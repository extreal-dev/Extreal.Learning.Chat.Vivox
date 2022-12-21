using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ExtrealCoreLearning.TextChatControl
{
    public class TextChatControlView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField messageInputField;
        [SerializeField] private Button sendButton;
        [SerializeField] private GameObject textChatMessagePrefab;

        public IObservable<string> OnSendButtonClicked => onSendButtonClicked;
        private readonly Subject<string> onSendButtonClicked = new Subject<string>();

        private void Awake()
        {
            sendButton.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ =>
            {
                onSendButtonClicked.OnNext(messageInputField.text);
                messageInputField.text = string.Empty;
            });
        }

        public void ShowTextChatMessage(string message)
        {
            var textChatMessageObject = Instantiate(textChatMessagePrefab, new Vector3(0, 10, 10), Quaternion.identity);
            var textChatMessageView = textChatMessageObject.GetComponent<TextChatMessageView>();
            textChatMessageView.ShowMessageAsync(message).Forget();
        }

        private void OnDestroy()
        {
            onSendButtonClicked.Dispose();
        }
    }
}