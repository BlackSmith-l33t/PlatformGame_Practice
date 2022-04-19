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

    public void Idle()
    {
        StartCoroutine(IdlePatten());
    }
    public void Jump()
    {
        StartCoroutine(JumpPatten());
    }
    IEnumerator IdlePatten()
    {
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("bJump", true);
        yield return null;
    }

    IEnumerator JumpPatten()
    {
        rigid.AddForce(new Vector2(-1, 1) * jumpPower, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.0f);
        //anim.SetBool("bJump", false);
        //yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter");
        anim.SetBool("bJump", false);
    }
}
