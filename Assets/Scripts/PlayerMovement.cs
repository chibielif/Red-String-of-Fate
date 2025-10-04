using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private bool _isFrozen = false;

    void Start()
    {
       _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
    }
    

    public void SetFrozen(bool value)
    {
        _isFrozen = value;

        if (value)
        {
            _moveInput = Vector2.zero;
            _rb.linearVelocity = Vector2.zero;
        }
        
    }

    void OnMove(InputValue value)
    {
        if (_isFrozen) return;
        _moveInput = value.Get<Vector2>();
    }
    void Run()
    {
        if (_isFrozen) return;
        Vector2 playerVelocity = new Vector2(_moveInput.x * runSpeed, _moveInput.y * runSpeed);
        _rb.linearVelocity = playerVelocity;
    }
}
