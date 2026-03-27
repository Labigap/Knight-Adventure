using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections;

public class player : MonoBehaviour
{
  [SerializeField] private float speed = 7f;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        inputVector = inputVector.normalized;
        Debug.Log(inputVector);
        rb.MovePosition(rb.position + inputVector * (speed * Time.fixedDeltaTime)); 
    }
}
