using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace ExtrealCoreLearning.TextChatControl
{
    public class TextChatMessageView : MonoBehaviour
    {
        [SerializeField] private TMP_Text messageText;

        public async UniTask ShowMessageAsync(string message)
        {
            messageText.text = message;
            await FadeoutAsync();
            Destroy(gameObject);
        }

        private async UniTask FadeoutAsync()
        {
            int changes = 20;
            TimeSpan fadeoutTime = TimeSpan.FromSeconds(5);
            for (float i = 0; i <= changes; i++)
            {
                messageText.color = new Color(1, 1, 1, 1.0f - i / changes);
                await UniTask.Delay(fadeoutTime / changes);
            }
        }
    }
}