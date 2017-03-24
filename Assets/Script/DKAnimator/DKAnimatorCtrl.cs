using UnityEngine;

public class DKAnimatorCtrl : MonoBehaviour
{
    protected Animator PlayerAnimator;

    public void Start()
    {
        PlayerAnimator = GetComponent<Animator>();

        if (PlayerAnimator.layerCount >= 2)
            PlayerAnimator.SetLayerWeight(1, 1);
    }

    public void Update()
    {
        if (PlayerAnimator)
        {
//            AnimatorStateInfo stateInfo = PlayerAnimator.GetCurrentAnimatorStateInfo(0);

            if (Input.GetButtonDown("Attack1")) PlayerAnimator.SetBool("Attack1", true);
            if (Input.GetButtonUp("Attack1")) PlayerAnimator.SetBool("Attack1", false);
            if (Input.GetKeyDown(KeyCode.X))
            {
                PlayerAnimator.SetBool("Dodge", true);
            }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            PlayerAnimator.SetFloat("Speed", h * h + v * v);
        }
    }
}