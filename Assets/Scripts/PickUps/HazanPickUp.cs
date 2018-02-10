using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazanPickUp : Pickup
{

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            GameManager.instance.ApplyPickUp(this);
        base.OnTriggerEnter2D(collision);
    }
}
