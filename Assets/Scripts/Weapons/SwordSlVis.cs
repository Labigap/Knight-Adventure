using UnityEngine;

public class SwordSlVis : MonoBehaviour
{
    [SerializeField] private Sword sword;

    private const string ATTACK = "Attack";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        sword.OnSwordSwing += SwordOnSwordSwing;
    }

    private void SwordOnSwordSwing(object sender, System.EventArgs e)
    {
        animator.SetTrigger(ATTACK);
    }
}
