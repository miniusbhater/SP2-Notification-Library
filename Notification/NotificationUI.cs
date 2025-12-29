using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Notification
{
    public class NotificationUI
    {
        public Canvas Canvas;
        public RectTransform Container;

       public static NotificationUI Create()
        {
            NotificationUI ui = new NotificationUI();
            GameObject canvas2 = new GameObject("NotificationCanvas");
            UnityEngine.Object.DontDestroyOnLoad(canvas2);
            Canvas canvas = canvas2.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 9999;
            ui.Canvas = canvas;
            CanvasScaler scaler = canvas2.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            GraphicRaycaster raycaster = canvas2.AddComponent<GraphicRaycaster>();
            GameObject container = new GameObject("Container");
            container.transform.SetParent(canvas2.transform, false);
            RectTransform rect = container.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(1f, 1f);
            rect.anchorMax = new Vector2(1f, 1f);
            rect.pivot = new Vector2(1f, 1f);
            rect.anchoredPosition = new Vector2(-20f, -20f);
            rect.sizeDelta = new Vector2(200f, 300f); // This size is terrible but it gets the job done i guess and im too lazy to start testing different sizes (Someone make a PR or something idk)
            ui.Container = rect;
            VerticalLayoutGroup layoutGroup = container.AddComponent<VerticalLayoutGroup>();
            layoutGroup.childAlignment = TextAnchor.UpperRight;
            layoutGroup.spacing = 8f;
            layoutGroup.childForceExpandHeight = false;
            layoutGroup.childForceExpandWidth = true;
            ContentSizeFitter fitter = container.AddComponent<ContentSizeFitter>();
            fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            return ui;
        }
    }

}
