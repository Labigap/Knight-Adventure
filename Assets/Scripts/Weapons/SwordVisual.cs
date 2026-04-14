using UnityEngine;

public class SwordVisual : MonoBehaviour
{
    [SerializeField] private Sword sword;

    private Animator animator;
    private const string ATTACK = "Attack";

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
