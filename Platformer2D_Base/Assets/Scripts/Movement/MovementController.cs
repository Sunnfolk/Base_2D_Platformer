using System;
using UnityEngine;

namespace Movement
{
    public class MovementController : MonoBehaviour
    {
        private PlayerInput m_Input;
        private CollisionsController m_Collisions;
        private JumpController m_Jump;
        private DashController m_Dash;

        private Rigidbody2D m_Rigidbody2D;
    
        // Start is called before the first frame update
        void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Input = GetComponent<PlayerInput>();
            m_Collisions = GetComponent<CollisionsController>();
            m_Jump = GetComponent<JumpController>();
            m_Dash = GetComponent<DashController>();
        }

        private void Update()
        {
            /* JUMPING */
            m_Jump.Jumping(m_Collisions.IsGrounded(),m_Rigidbody2D);
            m_Jump.LongJump(m_Input.longJump, m_Rigidbody2D);
            
        }
    }
}
