using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rb2D;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Transform _groundCheckPos;
    [SerializeField] private Vector2 _groundCheckSize;
    [SerializeField] private LayerMask _groundLayer;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameManager.Instance.OnGameStarted.AddListener(ActivatePlayer);
    }

    public void SetJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            _rb2D.linearVelocityY = 0f;
            _rb2D.AddForceY(_jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(_groundCheckPos.position, _groundCheckSize, 0f, _groundLayer);
    }

    private void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }
}
