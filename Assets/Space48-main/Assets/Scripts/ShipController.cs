using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 100f;
    private Rigidbody rb;

    public ShipShooter shooter;
    public ShipShield shield;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement();
        HandleInput();
    }

    void HandleMovement()
    {
        float move = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");

        rb.MovePosition(rb.position + transform.forward * move * moveSpeed * Time.deltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotate * rotationSpeed * Time.deltaTime, 0f));
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.Space))
               shooter.TryShoot();

        if (Input.GetKey(KeyCode.LeftShift))
            shield.Activate();
        else
            shield.Deactivate();
    }
}