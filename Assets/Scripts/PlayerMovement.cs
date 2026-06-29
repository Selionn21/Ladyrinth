using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool onGround;

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        if (inputX != 0)
            transform.localScale = new Vector3(inputX,1,1);

        rb.linearVelocity = new Vector2 (inputX * speed, rb.linearVelocityY);
        anim.SetInteger("InputX", (int)inputX);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
            rb.AddForce(Vector2.one * jumpForce, ForceMode2D.Impulse);        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }
}
