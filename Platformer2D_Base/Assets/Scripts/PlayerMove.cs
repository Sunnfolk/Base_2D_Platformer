using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField]private float jumpForce = 7f;
    [SerializeField] private LayerMask whatIsGround;
    
    
    private PlayerInput m_Input;
    private Rigidbody2D m_Rigidbody2D;

    private bool m_IsJumping = false;
    private float m_JumpTimeCounter;
    private float m_JumpTime = 0.25f;
    

    private void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (m_Input.jump)
        {
            Jumping();
        }
        LongJump();
        
    }

    private void FixedUpdate()
    {
        m_Rigidbody2D.velocity = new Vector2(m_Input.moveVector.x * moveSpeed, m_Rigidbody2D.velocity.y);
    }

    private void Jumping()
    {
        if (!IsGrounded()) return;
            m_IsJumping = true; //Long Jump
            m_JumpTimeCounter = m_JumpTime; // Long Juump
        m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpForce);
    }

    private void LongJump()
    {
        if (!m_Input.longJump && !m_IsJumping)
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
    

    private bool IsGrounded()
    {
        var position = transform.position;
        var direction = Vector2.down;
        const float distance = 1.5f;
        
        Debug.DrawRay(position, direction, new Color(1f, 0f, 1f));
        var hit = Physics2D.Raycast(position, direction, distance, whatIsGround);

        return hit.collider != null;
    }
}
