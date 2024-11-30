
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")] [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 5f;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rb2D;
    [SerializeField] private LayerMask _mask;
    private Ray _ray;
    [SerializeField] private float _groundCheckRadius = 0.8f;

    public static Player Instance;
    private bool _groundCheck;

    private int _jumpCount;
    private const int _maxJumpCount = 2;

    private void Awake()

    {
        Instance = this;
    }

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _jumpCount = _maxJumpCount;

    }

    private void Update()
    {
     CheckGround();
    }

    internal void Move(float horizontalInput)
    {
        _rb2D.linearVelocity = new Vector2(horizontalInput * _speed, _rb2D.linearVelocity.y);
        if (horizontalInput > 0)
        {
            _sprite.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            _sprite.flipX = true;
        }

    }


    internal void Jump()
    {
        CheckGround();
    if (_jumpCount > 0)
        {
            _groundCheck = false;
            _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, _jumpForce);
            _jumpCount--;

        }
    }

    public bool CheckGround()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckRadius, _mask);
      _groundCheck = hit.collider != null;
        if (_groundCheck)
        {
            _jumpCount = _maxJumpCount;
      }

        return _groundCheck;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * _groundCheckRadius, Color.red);

    }

  
}

    
    