using UnityEngine;

public class DKAnimatorCtrl : MonoBehaviour
{
    protected Animator PlayerAnimator;
    private GameObject _focus;

    public void Start()
    {
        PlayerAnimator = GetComponent<Animator>();

        if (PlayerAnimator.layerCount >= 2)
            PlayerAnimator.SetLayerWeight(1, 1);

        _focus = PlayerAnimator.transform.FindChild("Focus").gameObject;
    }

    public void Update()
    {
        if (!PlayerAnimator) return;
        //AnimatorStateInfo stateInfo = PlayerAnimator.GetCurrentAnimatorStateInfo(0);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        PlayerAnimator.SetFloat("Speed", h * h + v * v);

        ChangeDir();

        if (Input.GetButtonDown("Attack1")) PlayerAnimator.SetBool("Attack1", true);
        if (Input.GetButtonUp("Attack1")) PlayerAnimator.SetBool("Attack1", false);
    }

    private void ChangeDir()
    {
        float horizontal = Input.GetAxis("ChangeDir");
        _focus.transform.Rotate(_focus.transform.up * 1 * 2f * horizontal);
    }
}