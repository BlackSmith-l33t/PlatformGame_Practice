using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;

    public float jumpPower = 3.0f;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 startVec = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(startVec, Vector2.down, 1.2f, LayerMask.GetMask("Ground"));
        Debug.DrawRay(startVec, Vector2.down * 1.2f, new Color(0, 0, 1));

        if (null != hit.collider)
        {
            anim.SetBool("bJump", false);
        }
        else
        {
            anim.SetBool("bJump", true);
        }
    }

    public void Jump()
    {
        rigid.velocity = new Vector2(-1, 1) * jumpPower;
    }

    public void Die()
    {
        anim.SetTrigger("Die");
    }

    public void OnEndDieEffect()
    {
        Destroy(gameObject);
    }
}
