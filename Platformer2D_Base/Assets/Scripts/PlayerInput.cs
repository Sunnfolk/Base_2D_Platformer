using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    #region JUMP
        public bool jump => m_Jump;
        private bool m_Jump;
        
        public bool longJump => m_LongJump;
        private bool m_LongJump;
        
    #endregion

    #region DASH
        public bool downDash => m_DownDawsh;
        private bool m_DownDawsh;

        public bool horizontalDash => m_HorizontalDash;
        private bool m_HorizontalDash;
    #endregion
    
    #region MOUSE
    
        public Vector2 mousePosition => m_MousePos;
        private Vector2 m_MousePos;
    
        #region LeftMouse
        
        public bool mouseLeftClicked => m_MouseLeftClicked;
        private bool m_MouseLeftClicked;

        public bool mouseLeftHeld => m_MouseLeftHeld;
        private bool m_MouseLeftHeld;
        
        #endregion
        #region RightMouse
        
        public bool mouseRightClicked => m_MouseRightClicked;
        private bool m_MouseRightClicked;

        public bool mouseRightHeld => m_MouseRightHeld;
        private bool m_MouseRightHeld;
        
        #endregion
        
    #endregion

    #region WALK
        public Vector2 moveVector => m_MoveVector;
        private Vector2 m_MoveVector;
    #endregion
 

    private void Update()
    {
        m_Jump = Keyboard.current.spaceKey.wasPressedThisFrame;
        m_LongJump = Keyboard.current.spaceKey.isPressed;
        
        m_DownDawsh = Keyboard.current.sKey.isPressed;
        m_HorizontalDash = Keyboard.current.fKey.wasPressedThisFrame;
        
        m_MousePos = Mouse.current.position.ReadValue();
        
        m_MouseLeftClicked = Mouse.current.leftButton.wasPressedThisFrame;
        m_MouseLeftHeld = Mouse.current.leftButton.isPressed;
        
        m_MouseRightClicked = Mouse.current.rightButton.wasPressedThisFrame;
        m_MouseRightHeld = Mouse.current.rightButton.isPressed;
        
        m_MoveVector.x = (Keyboard.current.aKey.isPressed ? -1f : 0f) + (Keyboard.current.dKey.isPressed ? 1f : 0f);
        m_MoveVector.y = (Keyboard.current.sKey.isPressed ? -1f : 0f) + (Keyboard.current.wKey.isPressed ? 1f : 0f);
    }
}
