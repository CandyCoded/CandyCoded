// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CandyCoded.Experimental
{

    [AddComponentMenu("CandyCoded / Forms / Form Label")]
    public class FormLabel : MonoBehaviour, IPointerClickHandler
    {

        private EventSystem _eventSystem;

#pragma warning disable CS0649
        [SerializeField]
        private Selectable _selectable;
#pragma warning restore CS0649

        public void OnPointerClick(PointerEventData eventData)
        {

            _eventSystem.SetSelectedGameObject(_selectable.gameObject, null);

        }

        private void Awake()
        {

            _eventSystem = EventSystem.current;

        }

        private void OnEnable()
        {

            if (!_selectable)
            {

                _selectable = gameObject.transform.parent.GetComponentInChildren<Selectable>();

            }

        }

    }

}
