using UnityEngine;
using System;
public class PlayerTriggerController : MonoBehaviour
{
    public static event Action<AbstractTrigger> onTriggerCollision;
    private void OnTriggerEnter2D(Collider2D other)
    {
        AbstractTrigger abstractTrigger = other.GetComponent<AbstractTrigger>();
        onTriggerCollision?.Invoke(abstractTrigger);
        Destroy(other.gameObject);
    }
}
