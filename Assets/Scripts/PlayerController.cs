using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header(" - Movement - ")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [Header(" - References - ")]
    [SerializeField] Transform groundPivot;
    [SerializeField] LayerMask groundMask;

    Rigidbody2D rb2D;
    Animator animator;

    Vector2 inputMove;

    //Animator values
    int VELOCITYX = Animator.StringToHash("velocityX");
    int VELOCITYY = Animator.StringToHash("velocityY");
    int ISGROUNDED = Animator.StringToHash("isGrounded");

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        InvokeRepeating(nameof(SanityLog), 0, 3);
    }

    void SanityLog()
    {
        Debug.Log("Sanity Log");
    }

    void Update()
    {
        animator.SetFloat(VELOCITYX, Mathf.Abs(rb2D.linearVelocityX));
        animator.SetFloat(VELOCITYY, rb2D.linearVelocityY);
        animator.SetBool(ISGROUNDED, IsGrounded());
        Flip();
    }

    void FixedUpdate()
    {
        rb2D.linearVelocityX = inputMove.x * speed;
    }

    public void OnMove(InputValue value)
    {
        Debug.Log("On Move");
        inputMove = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        Debug.Log("On Move");
        rb2D.linearVelocityY = jumpForce;
    }

    bool IsGrounded()
    {
        var isGrounded = Physics2D.OverlapCircle(groundPivot.position, .2f, groundMask);
        return isGrounded != null;
    }

    void Flip()
    {
        if(transform.localScale.x * inputMove.x < 0)
        {
            transform.localScale = new Vector3(
                -transform.localScale.x,
                 transform.localScale.y,
                 transform.localScale.z
            );
        }
    }
}
