using System;
using Extreal.Core.Logging;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ExtrealCoreLearning.VoiceChatControl
{
    public class VoiceChatControlView : MonoBehaviour
    {
        private readonly static ELogger Logger = LoggingManager.GetLogger(nameof(VoiceChatControlView));

        [SerializeField] private Button voiceButton;

        public IObservable<Unit> OnVoiceButtonClicked
            => voiceButton.OnClickAsObservable().TakeUntilDestroy(this);

        public void toggleMute(bool isMute)
        {
            if (Logger.IsDebug())
            {
                Logger.LogDebug($"isMute: {isMute}");
            }
            voiceButton.GetComponent<Image>().color = isMute ? Color.gray : Color.red;
        }
    }
}