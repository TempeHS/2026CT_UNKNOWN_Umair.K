using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement
    public float moveSpeed = 5f;
    public float acceleration = 60f;
    public float deceleration = 80f;

    // Input
    private Vector2 moveInput;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Target velocity
        Vector2 targetVelocity = moveInput * moveSpeed;

        // Current velocity
        Vector2 currentVelocity = rb.linearVelocity;

        // Calculate acceleration per axis
        float accelX = Mathf.Abs(targetVelocity.x) > 0.01f ? acceleration : deceleration;
        float accelY = Mathf.Abs(targetVelocity.y) > 0.01f ? acceleration : deceleration;

        // Apply acceleration
        float newVelX = Mathf.MoveTowards(currentVelocity.x, targetVelocity.x, accelX * Time.fixedDeltaTime);
        float newVelY = Mathf.MoveTowards(currentVelocity.y, targetVelocity.y, accelY * Time.fixedDeltaTime);

        rb.linearVelocity = new Vector2(newVelX, newVelY);
    }
}
