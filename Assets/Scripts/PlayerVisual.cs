using UnityEngine;

public class Playervisual : MonoBehaviour
{
    private Animator animator;

    private SpriteRenderer spriteRanderer;

    private const string ISRUNNING = "IsRunning";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRanderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool(ISRUNNING, player.Instance.isRunning());
        AdjustPlayerFacingDirection();
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        Vector3 playerPosition = player.Instance.GetPlayerPosition();

        if (mousePos.x < playerPosition.x)
        {
            spriteRanderer.flipX = true;
        }
        else
        {
            spriteRanderer.flipX = false;
        }
    }

}
