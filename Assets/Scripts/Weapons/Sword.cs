using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sword : MonoBehaviour
{
    public event EventHandler OnSwordSwing;

    public void Attack()
    {
        OnSwordSwing?.Invoke(this, EventArgs.Empty);
    }
}
