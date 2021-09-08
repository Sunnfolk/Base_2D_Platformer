using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float m_dashSpeed;
    [SerializeField] private float m_DownSpeed = 4f;
    [SerializeField] private LayerMask whatIsGround;

    /*COMPONENTS*/
    private PlayerInput m_Input;
    private Rigidbody2D m_Rigidbody2D;

    /*JUMPING*/
    private bool m_IsJumping = false;
    private float m_JumpTimeCounter;
    private float m_JumpTime = 0.25f;
    
    /*MISC*/
    private Vector2 m_Dir;
    private bool dashCheck;

    private void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        DownDash();

        if (IsGrounded())
        {
            GrapplingHook.Hooked = false;
        }
        
        if(GrapplingHook.Hooked) return;
        
        
        if (m_Input.jump)
        {
            Jumping();
        }
        
        LongJump();
        
        SetMaxVelocity();
        //print("Y Velocity: "+ (int) m_Rigidbody2D.velocity.y);

        OnWall();
        //print("On Wall: " + OnWall());

        dashCheck = !IsGrounded() && m_Input.downDash;
        print("DashCheck says:" + dashCheck);
        
    }

    private void FixedUpdate()
    {
        if (GrapplingHook.Hooked) return;
        //if (dashCheck) return;
        m_Rigidbody2D.velocity = new Vector2(m_Input.moveVector.x * moveSpeed, m_Rigidbody2D.velocity.y);
    }

    private void DownDash()
    {
        if (m_Input.downDash)
        {
            m_Rigidbody2D.velocity = new Vector2(0f, m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.AddForce(Vector2.down * m_DownSpeed, ForceMode2D.Force);
        }
    }

    private void Jumping()
    {
        if (!IsGrounded()) return;
        
            m_IsJumping = true; //Long Jump
            m_JumpTimeCounter = m_JumpTime; // Long Jump
        m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpForce);
    }
    
    public void JustJump()
    {
        m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpForce);
        m_Rigidbody2D.AddRelativeForce(m_Rigidbody2D.velocity, ForceMode2D.Impulse);
    }

    public void ExtraJump()
    {
        m_Rigidbody2D.AddRelativeForce(m_Rigidbody2D.velocity, ForceMode2D.Impulse);
    }

    private void LongJump()
    {
        if (m_Input.longJump && m_IsJumping)
        {
            if (m_JumpTimeCounter > 0)
            {
                m_Rigidbody2D.velocity = Vector2.up * jumpForce;
                m_JumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                m_IsJumping = false;
            }
        }
        if (!m_Input.longJump)
        {
            m_IsJumping = false;
        }
    }

    private void SetMaxVelocity()
    {
        if (IsGrounded()) return;
        if (m_Rigidbody2D.velocity.y < -16f)
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, -16f);
        }
    }
    

    private bool IsGrounded()
    {
        var position = transform.position;
        var direction = Vector2.down;
        const float distance = 1.1f;
        
        Debug.DrawRay(position, direction, new Color(1f, 0f, 1f));
        var hit = Physics2D.Raycast(position, direction, distance, whatIsGround);
        
        return hit.collider != null;
    }


    
    private bool OnWall()
    {
        if (m_Input.moveVector.x != 0)
        {
            m_Dir = new Vector2(m_Input.moveVector.x, 0f);
        }
        
        var position = transform.position;
        const float distance = 0.4f;
        
        Debug.DrawRay(position, m_Dir, new Color(1f, 0f, 1f));
        var hit = Physics2D.Raycast(position, m_Dir, distance, whatIsGround);
        
        return hit.collider != null;
    }
}
