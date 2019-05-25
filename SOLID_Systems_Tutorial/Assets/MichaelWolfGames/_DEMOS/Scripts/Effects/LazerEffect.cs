using UnityEngine;

namespace MichaelWolfGames.Demos
{
    public class LazerEffect : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public LayerMask hitMask;
        public GameObject hitParticles;
        void Start()
        {
            if (!lineRenderer)
            {
                lineRenderer = GetComponent<LineRenderer>();
            }

            if (lineRenderer)
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(this.transform.position, transform.right, 100f, hitMask.value);
                if (hit.collider != null)
                {
                    lineRenderer.SetPosition(1, transform.InverseTransformPoint((Vector3)hit.point + transform.right*0.25f));
                    hitParticles.transform.position = hit.point;
                    hitParticles.transform.LookAt((Vector3)hit.point - transform.right);
                }
            }
        }
    }
}