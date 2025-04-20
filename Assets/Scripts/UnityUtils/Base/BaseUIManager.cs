using System;
using System.Collections.Generic;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.BaseClasses
{
    public class BaseUIManager : MonoBehaviour
    {
        protected Dictionary<UIActionType, object> _uiActionMap = new();

        protected virtual void Awake()
        {
            InitializeBaseUIAction();
        }

        private void InitializeBaseUIAction()
        {
            AddUIActionToMap<bool, GameObject>(UIActionType.SetPanelVisibility, (active, panel) => panel.SetActive(active));
            AddUIActionToMap<string, TextMeshProUGUI>(UIActionType.SetText, (textString, textObject) => textObject.text = textString);
            AddUIActionToMap<Slider, float>(UIActionType.SetSlider, (slider, value) => slider.value = value);
            AddUIActionToMap<Image, Sprite>(UIActionType.SetImage, (image, sprite) => image.sprite = sprite);
        }

        protected void AddUIActionToMap<T>(UIActionType actionType, Action<T> action)
        {
            _uiActionMap[actionType] = action;
        }

        protected void AddUIActionToMap<T1, T2>(UIActionType actionType, Action<T1, T2> action)
        {
            _uiActionMap[actionType] = action;
        }

        protected void ExecuteUIAction<T>(UIActionType actionType, T value)
        {
            if (_uiActionMap.TryGetValue(actionType, out var action) && action is Action<T> typedAction)
            {
                typedAction(value);
            }
            else
            {
                Debug.LogWarning("Undefined action Type!!");
            }
        }

        protected void ExecuteUIAction<T1, T2>(UIActionType actionType, T1 value1, T2 value2)
        {
            if (_uiActionMap.TryGetValue(actionType, out var action) && action is Action<T1, T2> typedAction)
            {
                typedAction?.Invoke(value1, value2);
            }
            else
            {
                Debug.LogWarning("Undefined action Type!!");
            }
        }
    }
}

public enum UIActionType
{
    SetPanelVisibility,
    SetText,
    SetImage,
    SetSlider
}
