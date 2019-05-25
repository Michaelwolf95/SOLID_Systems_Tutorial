using UnityEngine;

namespace MichaelWolfGames.Examples
{
    public class Spawner : MonoBehaviour
    {
        public GameObject Prefab;

        public void Spawn()
        {
            GameObject.Instantiate(Prefab, this.transform.position, this.transform.rotation, null);
        }
    }
}