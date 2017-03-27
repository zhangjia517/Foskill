using UnityEngine;

public class DKRunState : StateMachineBehaviour
{
    private PlayerConcrete _dkConcrete;
    private GameObject _focus;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _dkConcrete = animator.transform.GetComponent<PlayerConcrete>();
        _focus = animator.transform.FindChild("Focus").gameObject;
        _focus.transform.localRotation = Quaternion.Euler(Vector3.Lerp(_focus.transform.localRotation.eulerAngles, new Vector3(0, 0, 0), 4));
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        animator.gameObject.transform.Translate(animator.transform.forward * vertical * 0.08f * _dkConcrete.RunSpeed, Space.World);
        animator.gameObject.transform.Rotate(animator.transform.up * _dkConcrete.RotateSpeed * 2f * horizontal);

        if (Input.GetButtonDown("Dodge"))
        {
            animator.SetBool("Dodge", true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}