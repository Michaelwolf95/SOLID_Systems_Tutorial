using System.Collections;
using System.Collections.Generic;
using MichaelWolfGames.DamageSystem;
using MichaelWolfGames.Tools;
using UnityEngine;

public class EnumFlagsTest : MonoBehaviour
{

    [System.Flags]
    public enum MyMaskedEnum
    {
        Flag0 = (1 << 0),
        Flag1 = (1 << 1),
        Flag2 = (1 << 2),
        Flag3 = (1 << 3),
    }
    [System.Flags]
    public enum DamageTypeFlags
    {
        Default = (1 << 0),
        Melee = (1 << 1),
        Fire = (1 << 2),
        Ice = (1 << 3),
        Nature = (1 << 4),
        Electric = (1 << 5),

    }

    public MyMaskedEnum myEnum;
    [SerializeField] [EnumFlagsAttribute] MyMaskedEnum m_flags;
    [SerializeField] [EnumFlagsAttribute] Damage.DamageType m_type;
    [Header("Compare Test")]
    [SerializeField] [EnumFlags] private DamageTypeFlags typeFilter;
    [SerializeField] private Damage.DamageType type;

    void Start()
    {
        Debug.Log(m_flags);
        Debug.Log(m_type);
        Debug.Log(Damage.DamageType.Fire & Damage.DamageType.Ice);

        // Try comparing filter to enum?

    }
}