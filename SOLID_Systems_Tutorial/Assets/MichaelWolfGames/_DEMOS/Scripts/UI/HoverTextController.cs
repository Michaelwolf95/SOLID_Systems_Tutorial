using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MichaelWolfGames.Examples
{
    /// <summary>
    /// Simple hover text system for demos.
    /// 
    /// Michael Wolf
    /// November, 2018
    /// </summary>
    public class HoverTextController : MonoBehaviour
    {
        public GameObject hoverTextPanel;
        public Text textElement;

        [SerializeField] private HoverText current;

        private void Start()
        {
            current = null;
            hoverTextPanel.SetActive(false);
            textElement.text = "HOVER TEXT NOT SET";
        }
        
        public void SetCurrentHover(HoverText hover)
        {
            if(hover == null)
            {
                if(current != null)
                {
                    HideText(current);
                    current = null;
                }
            }
            else if (current != null)
            {
                SwapText(hover);
                current = hover;
            }
            else
            {
                ShowText(hover);
                current = hover;
            }
        }

        public void ShowText(HoverText hover)
        {
            //Debug.Log("Showing...");
            textElement.text = hover.textValue;
            hoverTextPanel.SetActive(true);
            hover.OnTextShown();
        }

        public void HideText(HoverText hover)
        {
            //Debug.Log("Hiding...");
            hoverTextPanel.SetActive(false);
            textElement.text = "[None]";
            hover.OnTextHidden();
            if(hover == current)
            {
                current = null;
            }
        }

        public void SwapText(HoverText hover)
        {
            Debug.Log("Swapping...");
            if (current != null)
            {
                current.OnTextHidden();
            }
            textElement.text = hover.textValue;
            hover.OnTextShown();
        }


    }
}