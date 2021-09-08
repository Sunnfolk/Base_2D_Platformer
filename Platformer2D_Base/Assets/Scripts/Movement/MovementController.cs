using System;
using UnityEngine;

namespace Movement
{
    public class MovementController : MonoBehaviour
    {
        #region Script Controllers
            private PlayerInput m_Input;
            private CollisionsController m_Collisions;
            private JumpController m_Jump;
            private DashController m_Dash;
        #endregion
        

        private Rigidbody2D m_Rigidbody2D;
    
        // Start is called before the first frame update
        private void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Input = GetComponent<PlayerInput>();
            m_Collisions = GetComponent<CollisionsController>();
            m_Jump = GetComponent<JumpController>();
            m_Dash = GetComponent<DashController>();
        }

        private void Update()
        {
            /*IS GROUNDED*/ // if Not Grounded, Don't read code below
            if (!m_Collisions.IsGrounded()) return;
            
            
            /* JUMPING */
                m_Jump.Jumping(m_Rigidbody2D);
                m_Jump.LongJump(m_Input.longJump, m_Rigidbody2D);
        }
    }
}

