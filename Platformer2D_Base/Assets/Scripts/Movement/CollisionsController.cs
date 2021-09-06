using UnityEngine;

namespace Movement
{
    public class CollisionsController : MonoBehaviour
    {
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private Vector2 m_Dir;
    
        public bool IsGrounded()
        {
            var position = transform.position;
            var direction = Vector2.down;
            const float distance = 1.1f;
        
            Debug.DrawRay(position, direction, new Color(1f, 0f, 1f));
            var hit = Physics2D.Raycast(position, direction, distance, whatIsGround);
        
            return hit.collider != null;
        }

        public bool OnWall(float xInput)
        {
            if (xInput != 0)
            {
                m_Dir = new Vector2(xInput, 0f);
            }
        
            var position = transform.position;
            const float distance = 0.4f;
        
            Debug.DrawRay(position, m_Dir, new Color(1f, 0f, 1f));
            var hit = Physics2D.Raycast(position, m_Dir, distance, whatIsGround);
        
            return hit.collider != null;
        }
    }
}
