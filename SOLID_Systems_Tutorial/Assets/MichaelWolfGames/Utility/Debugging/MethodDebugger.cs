using UnityEngine;
using UnityEngine.Events;

namespace MichaelWolfGames.Utility
{
    /// <summary>
    /// Utility class to debug methods without having to write them into the class.
    /// Gauruntees that the debug key does not make its way into builds.
    /// 
    /// Michael Wolf
    /// June 8th, 2017
    /// </summary>
    public class MethodDebugger : MonoBehaviour
    {
        [SerializeField] private KeyCode m_DebugKey;
        [SerializeField] private string m_DebugLogMessage = "";
        [SerializeField] private UnityEvent m_DebugEvent;
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(m_DebugKey))
            {
                if(m_DebugLogMessage.Length > 0) Debug.Log("[MethodDebugger]: " + m_DebugLogMessage);
                m_DebugEvent.Invoke();
            }
        }
#endif
    }
}