using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

namespace Hotbar.UI
{
    [RequireComponent(typeof(EventTrigger))]
    public class UIButtonBase : MonoBehaviour
    {
        private float scaleUpSize = 1.075f;
        private EventTrigger eventTrigger;
        private Button button;
        private float initialScale;

        private void Awake()
        {
            initialScale = transform.localScale.x;
            button = GetComponent<Button>();
            eventTrigger = GetComponent<EventTrigger>();

            var pointerEnterEntry = new EventTrigger.Entry();
            pointerEnterEntry.eventID = EventTriggerType.PointerEnter;
            pointerEnterEntry.callback.AddListener(OnPointerEnter);
            eventTrigger.triggers.Add(pointerEnterEntry);

            var pointerExitEntry = new EventTrigger.Entry();
            pointerExitEntry.eventID = EventTriggerType.PointerExit;
            pointerExitEntry.callback.AddListener(OnPointerExit);
            eventTrigger.triggers.Add(pointerExitEntry);
        }

        public void OnPointerEnter(BaseEventData data)
        {
            button.DOKill();
            button.transform.DOScale(initialScale * scaleUpSize, 0.3f);
        }

        public void OnPointerExit(BaseEventData data)
        {
            button.DOKill();
            button.transform.DOScale(initialScale, 0.3f);
        }
    }
}
