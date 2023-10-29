using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    public SpriteRenderer renderer;
    public Sprite[] sprites;
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

            _VerticalInput = Input.GetAxisRaw("Vertical");
            _HorizontalInput = Input.GetAxisRaw("Horizontal");

            if (_VerticalInput > 0)
            {
                renderer.sprite = sprites[0];
            }
            else if (_VerticalInput < 0)
            {
                renderer.sprite = sprites[1];
            }
            else if (_HorizontalInput > 0)
            {
                renderer.sprite = sprites[3];
            }
            else if (_HorizontalInput < 0)
            {
                renderer.sprite = sprites[2];
            }

            _rb.velocity = new Vector2(_HorizontalInput, _VerticalInput) * Speed;
        }
    }

    public void StopMove()
    {
        _rb.velocity = Vector2.zero;
    }
}