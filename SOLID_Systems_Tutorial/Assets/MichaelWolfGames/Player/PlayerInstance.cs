using UnityEngine;

namespace MichaelWolfGames
{
    /// <summary>
    /// Static reference for finding the root of the Player GameObject.
    /// Though it does not derive from our regular Singleton<T> base class,
    /// this follows a "yielding" singleton pattern;
    /// When a new instance is created, while another one exists, it  will destroy itself.
    /// This way, we do not spawn an extra player while one currently exists.
    /// 
    /// Michael Wolf
    /// September 13, 2017
    /// </summary>
    public class PlayerInstance : MonoBehaviour
    {
        private static PlayerInstance _instance;
        public static PlayerInstance Instance
        {
            get
            {
                if(_instance == null)
                {
                    Debug.LogWarning("[PlayerInstance]: No PlayerInstance currently exists.");
                    return null;
                }
                return _instance;
            }
        }
        public static Transform PlayerRoot
        {
            get
            {
                if(_instance)
                {
                    return _instance.transform;
                }
                return null;
            }
        }

        #region MonoBehaviour Callbacks

        /// <summary>
        /// Sets the instance reference to itself whenever a new instance is created.
        /// If another one exists, it will log an error and destroy itself.
        /// Note: We might want to change it so that it destroys the OTHER instance, if it turns out to be easier in practice.
        /// </summary>
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Debug.LogError("[PlayerInstance]: There should never be more than one PlayerInstance. Destroying new Instance.");
                Destroy(this.gameObject);
                return;
            }
            _instance = this;
        }

        /// <summary>
        /// Resets the instance reference to null when the player is destroyed.
        /// Specifically, during scene loading, but also for any other reason.
        /// </summary>
        private void OnDestroy()
        {
            if (this == _instance)
            {
                _instance = null;
            }
        }
        #endregion
    }
}