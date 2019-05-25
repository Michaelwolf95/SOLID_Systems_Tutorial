using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace MichaelWolfGames
{
	
	public class PlayerStartPoint : MonoBehaviour
	{
	    [SerializeField] private bool _projectRotation = true;

	    private void Start()
        {
            SetPlayerPosition();
        }

        private void SetPlayerPosition()
        {
            var playerInstance = PlayerInstance.Instance;
            if (playerInstance)
            {
                PlayerInstance.PlayerRoot.position = this.transform.position;
                if (_projectRotation)
                {
                    PlayerInstance.PlayerRoot.LookAt(Vector3.ProjectOnPlane(PlayerInstance.PlayerRoot.forward, Vector3.up), Vector3.up);
                }
                else
                {
                    PlayerInstance.PlayerRoot.rotation = this.transform.rotation;
                }
            }
        }
    }
}