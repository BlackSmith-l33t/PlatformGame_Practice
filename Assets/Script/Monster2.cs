using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonoBehaviour
{
    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Vector2 startVec = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(startVec, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));

        Debug.DrawRay(startVec, Vector2.down * 1.4f, new Color(0, 1, 0));      
    }
    private void Move()
    {

    }
}
