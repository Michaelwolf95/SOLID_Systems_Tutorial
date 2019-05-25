using UnityEngine;
using System.Collections;

namespace MichaelWolfGames.ResourceSystem
{
    public class SimpleManaAbility : MonoBehaviour
    {
        public ManaPool m_ManaPool;
        public KeyCode m_AbilityKey = KeyCode.LeftShift;
        public float manaCost = 25f;

        private void Start()
        {
            if (!m_ManaPool) m_ManaPool = GetComponent<ManaPool>();
            if (!m_ManaPool) m_ManaPool = GetComponentInParent<ManaPool>();

        }

        private void Update()
        {
            if (Input.GetKeyDown(m_AbilityKey))
            {
                if (m_ManaPool.TryDrawResource(manaCost))
                {
                    DoAbility();
                }
            }
        }

        public void DoAbility()
        {
            Debug.Log("Doing Ability");
        }
    }
}