using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace MichaelWolfGames.MeterSystem
{
    public class Meter : MeterBase
    {
        public Image FillImage;
        public bool InvertFill = false;

        protected virtual void Start()
        {
            if (!FillImage) FillImage = this.GetComponent<Image>();
        }

        protected override void UpdateMeter(float percentValue)
        {
            if (FillImage)
            {
                FillImage.fillAmount = (InvertFill)? 1- percentValue : percentValue;
            }
        }
    }
}
