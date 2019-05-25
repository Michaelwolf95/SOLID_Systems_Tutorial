using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MichaelWolfGames.Examples
{

    public class Character2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f; // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f; // Amount of force added when the player jumps.
        [SerializeField] private float m_GravityMultiplier = 2f;
        [SerializeField] private bool m_AirControl = false; // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround; // A mask determining what is ground to the character

        private bool m_Grounded; // Whether or not the player is grounded.
        private Transform m_GroundCheck; // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private Transform m_CeilingCheck; // A position marking where to check for ceilings
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true; // For determining which way the player is currently facing.
        //private Animator m_Anim; // Reference to the player's animator component.

        private bool m_MovementSupressed = false;

        private void Awake()
        {
            // Setting up references.
            //m_GroundCheck = transform.Find("GroundCheck");
            //m_CeilingCheck = transform.Find("CeilingCheck");
            m_GroundCheck = this.transform;
            //m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            foreach (var collider in colliders)
            {
                var go = collider.attachedRigidbody
                    ? collider.attachedRigidbody.gameObject
                    : collider.gameObject;
                if (go != gameObject)
                    m_Grounded = true;
            }
            // m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            //m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

            if (!m_Grounded)
            {
                //if(m_Rigidbody2D.velocity.y < 0f)
                m_Rigidbody2D.AddForce(Physics2D.gravity* (m_GravityMultiplier-1f));
            }
        }

        public void Move(float move, bool jump)
        {
            if(m_MovementSupressed) return;

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // The Speed animator parameter is set to the absolute value of the horizontal input.
                //m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                if (Mathf.Abs(move) < 0.1f)
                {
                    // Apply Friction
                    if (Mathf.Abs(m_Rigidbody2D.velocity.x) > 0f)
                    {
                        //m_Rigidbody2D.AddForce(new Vector2(-m_Rigidbody2D.velocity.x, 0f));
                        m_Rigidbody2D.velocity += new Vector2(-m_Rigidbody2D.velocity.x, 0f);
                    }
                }
                else
                {
                    //m_Rigidbody2D.AddForce(new Vector2(move*m_MaxSpeed, 0f));
                    m_Rigidbody2D.velocity += new Vector2(move * m_MaxSpeed, 0f);
                }

                m_Rigidbody2D.velocity = new Vector2(Mathf.Clamp(m_Rigidbody2D.velocity.x, -m_MaxSpeed, m_MaxSpeed), m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }

            // If the player should jump...
            if (m_Grounded && jump)
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                //m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }


        public void SupressMovement(float duration)
        {
            if (duration >= 0)
            {
                CancelInvoke("UnsupressMovement");
                m_MovementSupressed = true;
                Invoke("UnsupressMovement", duration);
            }
        }

        public void UnsupressMovement()
        {
            m_MovementSupressed = false;
        }

    }
}