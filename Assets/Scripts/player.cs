using UnityEngine;

public class player : MonoBehaviour
{
    public static player Instance { get; private set; }

  [SerializeField] private float speed = 7f;

    private Rigidbody2D rb;

    private float minMovingSpeed = 0.1f;
    private bool IsRunning = false;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        inputVector = inputVector.normalized;
        Debug.Log(inputVector);
        rb.MovePosition(rb.position + inputVector * (speed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed)
        {
            IsRunning = true;
        }
        else
        {
            IsRunning = false;
        }
    }

    public bool isRunning()
    {
        return IsRunning;
    }

    public Vector3 GetPlayerPosition()
    {
        Vector3 PlayerPosition = Camera.main.WorldToScreenPoint(transform.position);
        return PlayerPosition;
    }

}
