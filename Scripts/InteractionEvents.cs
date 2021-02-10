// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace CandyCoded
{

    [Flags]
    public enum InteractionEventType
    {

        None = 0,

        Everything = ~0,

        Click = 1 << 0,

        Down = 1 << 1,

        Enter = 1 << 2,

        Exit = 1 << 3,

        Up = 1 << 4

    }

    [Serializable]
    public class InteractionEvent : UnityEvent<InteractionEventType, PointerEventData>
    {

    }

    /// <summary>
    ///     InteractionEvents
    /// </summary>
    public class InteractionEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,
        IPointerUpHandler, IPointerClickHandler
    {

        public InteractionEventType eventTypes;

        public InteractionEvent InteractionEventHandler;

        public void OnPointerClick(PointerEventData eventData)
        {

            HandleEvent(InteractionEventType.Click, eventData);

        }

        public void OnPointerDown(PointerEventData eventData)
        {

            HandleEvent(InteractionEventType.Down, eventData);

        }

        public void OnPointerEnter(PointerEventData eventData)
        {

            HandleEvent(InteractionEventType.Enter, eventData);

        }

        public void OnPointerExit(PointerEventData eventData)
        {

            HandleEvent(InteractionEventType.Exit, eventData);

        }

        public void OnPointerUp(PointerEventData eventData)
        {

            HandleEvent(InteractionEventType.Up, eventData);

        }

        private void HandleEvent(InteractionEventType eventType, PointerEventData eventData)
        {

            if (((int)eventTypes).Contains((int)eventType))
            {

                InteractionEventHandler?.Invoke(eventType, eventData);

            }

        }

    }

}
