using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public bool jump => m_Jump;
    private bool m_Jump;
    
    public bool longJump => m_LongJump;
    private bool m_LongJump;

    
    public Vector2 moveVector => m_MoveVector;
    private Vector2 m_MoveVector;

    private void Update()
    {
        m_MoveVector.x = (Keyboard.current.aKey.isPressed ? -1f : 0f) + (Keyboard.current.dKey.isPressed ? 1f : 0f);
        m_MoveVector.y = (Keyboard.current.sKey.isPressed ? -1f : 0f) + (Keyboard.current.wKey.isPressed ? 1f : 0f);
        
        m_Jump = Keyboard.current.spaceKey.wasPressedThisFrame;
        m_LongJump = Keyboard.current.spaceKey.isPressed;
    }
}