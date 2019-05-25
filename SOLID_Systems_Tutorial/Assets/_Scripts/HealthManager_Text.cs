using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLID_Tutorial.HealthSystem;
using UnityEngine.UI;

public class HealthManager_Text : HealthManagerEventSubscriberBase
{
    [SerializeField] private Text text;

    protected override void Awake()
    {
        base.Awake();
        if (text == null) text = GetComponent<Text>();

        if (text != null && owner != null)
            UpdateText();
    }

    protected override void OnTakeDamage(object sender, float damage)
    {
        UpdateText();
    }

    protected override void OnDeath()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (text == null) return;

        text.text = owner.CurrentHealth.ToString("0.##") 
            + "/" + owner.MaxHealth.ToString("0.##");
    }

}
