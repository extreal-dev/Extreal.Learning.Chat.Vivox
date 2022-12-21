﻿using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ExtrealCoreLearning.VoiceChatControl
{
    public class VoiceChatControlScope : LifetimeScope
    {
        [SerializeField] private VoiceChatControlView voiceChatControlView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(voiceChatControlView);

            builder.RegisterEntryPoint<VoiceChatControlPresenter>();
        }
    }
}