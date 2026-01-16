using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    PlayerInput input;
    InputAction move;
    Vector2 moveDir;
    Vector2 lastMoveDir;
    public float moveSpeed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        move = input.actions.FindAction("Move");
        lastMoveDir = Vector2.down;
    }

    void Update()
    {
        moveDir = move.ReadValue<Vector2>();

        anim.SetFloat("MoveX", moveDir.x);
        anim.SetFloat("MoveY", moveDir.y);
        anim.SetFloat("MoveMagnitude", moveDir.magnitude);

        if(moveDir != Vector2.zero)
        {
            lastMoveDir = moveDir;
            anim.SetFloat("LastMoveX", lastMoveDir.x);
            anim.SetFloat("LastMoveY", lastMoveDir.y);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }
}