using UnityEngine;

namespace Movement
{
    public class JumpController : MonoBehaviour
    {
        /*JUMPING*/
        [SerializeField] private float jumpForce = 7f;
        private bool m_IsJumping = false;
        private float m_JumpTimeCounter;
        private const float k_JumpTime = 0.25f;

        public void Jumping(Rigidbody2D rigidbody2D)
        {
            m_IsJumping = true; //Long Jump
            m_JumpTimeCounter = k_JumpTime; // Long Jump
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }

        public void LongJump(bool longJump, Rigidbody2D rigidbody2D)
        {
            if (longJump && m_IsJumping)
            {
                if (m_JumpTimeCounter > 0)
                {
                    rigidbody2D.velocity = Vector2.up * jumpForce;
                    m_JumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    m_IsJumping = false;
                }
            }
            if (!longJump)
            {
                m_IsJumping = false;
            }
        }
    }
}
