using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    float jump_power;

    Animator animator;
    Rigidbody2D body;

    bool jumping;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            StartJump();
        }
    }

    void StartJump()
    {
        jumping = true;
        body.AddForce(jump_power * new Vector3(0, 1, 0), ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
    }

    void EndJump()
    {
        jumping = false;
        animator.SetTrigger("GroundHit");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") && jumping)
        {
            EndJump();
        }
    }

    public void DoSwipeAction(Dir swipe)
    {
        if (swipe == Dir.Up && !jumping)
            StartJump();
    }
}
