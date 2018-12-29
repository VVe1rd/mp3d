using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimate : MonoBehaviour {

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");

        animator.SetFloat("HSpeed", xMov);
        animator.SetFloat("VSpeed", zMov);
    }

}
