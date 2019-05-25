using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MichaelWolfGames.Examples
{
    /// <summary>
    /// 
    /// 
    /// Michael Wolf
    /// November, 2018
    /// </summary>
    public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [TextArea(2,4)]
        public string textValue = "[HoverText value not set]";
        public HoverTextController controller;
        protected bool isHovered = false;

        protected virtual void Start()
        {
            if(controller == null)
            {
                controller = GetComponentInParent<HoverTextController>();
            }
        }

        protected virtual void OnDisable()
        {
            if (controller != null)
            {
                controller.HideText(this);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(controller != null)
            {
                controller.SetCurrentHover(this);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (controller != null)
            {
                controller.HideText(this);
            }
        }

        public virtual void OnTextShown()
        {
            isHovered = true;
        }

        public virtual void OnTextHidden()
        {
            isHovered = false;
        }

        //private void Update()
        //{
        //    if(isHovered)
        //    {

        //    }
        //}
    }
}