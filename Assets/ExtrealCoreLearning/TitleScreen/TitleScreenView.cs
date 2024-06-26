﻿using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ExtrealCoreLearning.TitleScreen
{
    public class TitleScreenView : MonoBehaviour
    {
        [SerializeField] private Button goButton;

        public IObservable<Unit> OnGoButtonClicked
            => goButton.OnClickAsObservable().TakeUntilDestroy(this);
    }
}