using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    [Min(0f)]
    public float Speed = 1.0f;

    public bool isActivate = true;

    private float _VerticalInput;
    private float _HorizontalInput;
    [SerializeField]
    private Rigidbody2D _rb;

    void FixedUpdate()
    {
        if (isActivate)
        {
            _VerticalInput = Input.GetAxis("Vertical");
            _HorizontalInput = Input.GetAxis("Horizontal");

            _rb.velocity = new Vector2(_HorizontalInput, _VerticalInput) * Speed;
        }
    }
}
