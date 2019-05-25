using UnityEngine;

namespace MichaelWolfGames.Examples
{
    public class Character2DUserControl : MonoBehaviour
    {
        private Character2D m_Character;
        private bool m_Jump;

        private void Awake()
        {
            m_Character = GetComponent<Character2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            float h = Input.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, m_Jump);
            m_Jump = false;
        }
    }
}