using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpPower = 5.0f;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer render;
    float hSpeed;
    float vSpeed;

    bool isGround
    {
        set
        {
            anim.SetBool("IsGround", value);
        }
        get
        {
            return anim.GetBool("IsGround");
        }
    }

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        Vector2 startVec = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(startVec, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));

        Debug.DrawRay(startVec, Vector2.down * 1.5f, new Color(0, 0, 1));
        if (null != hit.collider)
        {
            Debug.Log(hit.collider.name);
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    private void Move() {
        hSpeed = Input.GetAxis("Horizontal") * moveSpeed;
        anim.SetFloat("hSpeed", Mathf.Abs(hSpeed));
        transform.Translate(Vector2.right * hSpeed * Time.deltaTime);

        if (hSpeed > 0)
        {
            render.flipX = false;
        }
        else if (hSpeed < 0)
        {
            render.flipX = true;
        }
    }

    private void Jump() {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGround = true;
        }
        vSpeed = rigid.velocity.y;
        anim.SetFloat("vSpeed", vSpeed);
    }
}
