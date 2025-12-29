using UnityEngine;
using UnityEngine.UI;

namespace Notification
{
    internal class NotificationElement
    {
        public GameObject Root;
        public Text SenderText;
        public Text MessageText;

        public static NotificationElement Create(RectTransform parent, string sender, string message)
        {
            NotificationElement elem = new NotificationElement();
            GameObject rootObj = new GameObject("Notification");
            rootObj.transform.SetParent(parent, false);
            elem.Root = rootObj;
            RectTransform rootRect = rootObj.AddComponent<RectTransform>();
            rootRect.pivot = new Vector2(1, 1);
            rootRect.anchorMin = new Vector2(1, 1);
            rootRect.anchorMax = new Vector2(1, 1);
            rootRect.sizeDelta = new Vector2(parent.rect.width, 80f);
            Image bg = rootObj.AddComponent<Image>();
            bg.color = new Color(0f, 0f, 0f, 0.75f);
            LayoutElement layout = rootObj.AddComponent<LayoutElement>();
            layout.preferredHeight = 80f;
            layout.minHeight = 80f;
            layout.flexibleWidth = 0;

            //Container
            GameObject containerObj = new GameObject("Container");
            containerObj.transform.SetParent(rootObj.transform, false);
            RectTransform containerRect = containerObj.AddComponent<RectTransform>();
            containerRect.anchorMin = Vector2.zero;
            containerRect.anchorMax = Vector2.one;
            containerRect.offsetMin = new Vector2(10f, 10f);
            containerRect.offsetMax = new Vector2(-10f, -10f);
            VerticalLayoutGroup vLayout = containerObj.AddComponent<VerticalLayoutGroup>();
            vLayout.childAlignment = TextAnchor.UpperLeft;
            vLayout.spacing = 2f;
            vLayout.childForceExpandHeight = false;
            vLayout.childForceExpandWidth = true;

            //Sender text
            GameObject senderObj = new GameObject("Sender");
            senderObj.transform.SetParent(containerObj.transform, false);
            Text senderText = senderObj.AddComponent<Text>();
            senderText.text = sender;
            senderText.color = Color.gray;
            senderText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            senderText.fontSize = 10;
            senderText.alignment = TextAnchor.UpperLeft;
            senderText.horizontalOverflow = HorizontalWrapMode.Wrap;
            senderText.verticalOverflow = VerticalWrapMode.Overflow;
            senderText.resizeTextForBestFit = false;
            LayoutElement senderLayout = senderObj.AddComponent<LayoutElement>();
            senderLayout.preferredHeight = 10;
            senderLayout.flexibleWidth = 1;
            elem.SenderText = senderText;

            //Message text shit
            GameObject messageObj = new GameObject("Message");
            messageObj.transform.SetParent(containerObj.transform, false);
            Text messageText = messageObj.AddComponent<Text>();
            messageText.text = message;
            messageText.color = Color.white;
            messageText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            messageText.fontSize = 14;
            messageText.alignment = TextAnchor.UpperLeft;
            messageText.horizontalOverflow = HorizontalWrapMode.Wrap;
            messageText.verticalOverflow = VerticalWrapMode.Overflow;
            messageText.resizeTextForBestFit = false;
            RectTransform msgRect = messageObj.GetComponent<RectTransform>();
            msgRect.anchorMin = new Vector2(0, 0);
            msgRect.anchorMax = new Vector2(1, 1);
            msgRect.offsetMin = Vector2.zero;
            msgRect.offsetMax = Vector2.zero;
            var autoShrink = messageObj.AddComponent<AutoShrinkText>();
            autoShrink.minFontSize = 6;
            autoShrink.maxFontSize = 16;
            return elem;
        }
    }


    // This next part is mostly chatGPT as at some point i broke resizing and spent about 2 hours trying to find out why so i gave up :sob:
    [RequireComponent(typeof(Text))]
    public class AutoShrinkText : MonoBehaviour
    {
        public int minFontSize = 6;
        public int maxFontSize = 16;
        private Text txt;
        private RectTransform rect;

        void Awake()
        {
            txt = GetComponent<Text>();
            rect = GetComponent<RectTransform>();
            AdjustFontSize();
        }
        void LateUpdate()
        {
            AdjustFontSize();
            Destroy(this);
        }

        public void AdjustFontSize()
        {
            txt.fontSize = maxFontSize;
            float boxHeight = rect.rect.height;
            TextGenerator textGen = txt.cachedTextGenerator;
            for (int size = maxFontSize; size >= minFontSize; size--)
            {
                txt.fontSize = size;
                textGen.Invalidate();
                textGen.Populate(txt.text, txt.GetGenerationSettings(rect.rect.size));
                if (textGen.lineCount * txt.font.lineHeight <= boxHeight)
                    break;
            }
        }
    }

}
