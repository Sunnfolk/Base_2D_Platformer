using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GrapplingHook : MonoBehaviour
{

    public static bool Hooked;
    
    public LayerMask ropeLayerMask;

    public float distance = 90.0f;

    private bool checker = true;
    private Vector2 LookDirection;

    private PlayerInput _Input;
    private PlayerMove _move;
    private LineRenderer line;
    private DistanceJoint2D rope;
    
    private void Start()
    {
        rope = gameObject.AddComponent<DistanceJoint2D>();
        line = GetComponent<LineRenderer>();
        
        _Input = GetComponent<PlayerInput>();
        _move = GetComponent<PlayerMove>();
        rope.enabled = false;
        line.enabled = false;
    }

    private void Update()
    {
        line.SetPosition(0, transform.position);

        LookDirection = Camera.main.ScreenToWorldPoint(_Input.mousePosition) - transform.position;
        Debug.DrawLine(transform.position, LookDirection);

        if (_Input.mouseLeftClicked && checker)
        {
            var hit = Physics2D.Raycast(transform.position, LookDirection, distance, ropeLayerMask);

            if (hit.collider != null)
            {
                checker = false;
                SetRope(hit);
            }
            
        }
        else if (_Input.mouseLeftClicked && !checker)
        {
            _move.ExtraJump();
            checker = true;
            DestroyRope();
        }
        else if (_Input.jump && !checker)
        {
            _move.JustJump();
            checker = true;
            DestroyRope();
        }
    }

    private void DestroyRope()
    {
        rope.enabled = false;
        line.enabled = false;
    }

    private void SetRope(RaycastHit2D hit)
    {
        rope.enabled = true;
        rope.connectedAnchor = hit.point;

        line.enabled = true;
        line.SetPosition(1, hit.point);

        Hooked = true;
    }
}
