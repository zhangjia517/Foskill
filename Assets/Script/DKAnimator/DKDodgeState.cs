using UnityEngine;

public class DKDodgeState : StateMachineBehaviour
{
    private Animator _animator;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animator = animator;
        _animator.SetBool("Dodge", false);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetAxis("Horizontal").Equals(0) && Input.GetAxis("Vertical").Equals(0))
        {
            vertical = 1;
        }
        iTween.MoveBy(_animator.gameObject, iTween.Hash("amount", ((new Vector3(horizontal, 0, vertical)).normalized * 5), "time", 2f));
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        iTween.Stop(_animator.gameObject);
        _animator.SetBool("Dodge", false);
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}