using UnityEngine;
using System.Collections;

public class DKRunState : StateMachineBehaviour
{

    private PlayerConcrete _dkConcrete;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _dkConcrete = animator.transform.GetComponent<PlayerConcrete>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        animator.gameObject.transform.Translate(animator.transform.forward * vertical * 0.08f * _dkConcrete.RunSpeed, Space.World);
        animator.gameObject.transform.Rotate(animator.transform.up * _dkConcrete.RotateSpeed * 2f * horizontal);

        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("Dodge", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
