using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIdle : StateMachineBehaviour
{
    Monster monster;
    float curTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.gameObject.GetComponent<Monster>();
        curTime = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        curTime += Time.deltaTime;
        if (curTime > 3.0f)
        {
            monster.Jump();
            animator.SetBool("bJump", true);
        }
    }
}
