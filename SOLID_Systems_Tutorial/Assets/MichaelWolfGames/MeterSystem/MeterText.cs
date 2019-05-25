using UnityEngine.UI;

namespace MichaelWolfGames.MeterSystem
{
    public class MeterText : MeterBase
    {
        public Text m_Text;
        public bool ShowPercent;
        public bool Bold;
        public bool CastAsInteger;

        protected virtual void Start()
        {
            if (!m_Text) m_Text = this.GetComponent<Text>();
        }

        protected override void UpdateMeter(float percentValue)
        {
            if (m_Text)
            {
                string str = "";
                if (ShowPercent)
                {
                    str = Meterable.PercentValue.ToString("P");
                }
                else
                {
                    if(CastAsInteger)
                        str = ((int)Meterable.CurrentValue) + "/" + ((int)Meterable.MaxValue);
                    else
                        str = (Meterable.CurrentValue).ToString("0.##") + "/" + Meterable.MaxValue.ToString("0.##");
                }

                if (Bold) str = "<b>" + str + "</b>";

                m_Text.text = str;
            }
        }
    }
}