using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public static PickUpManager instance;
    Player player;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        player = FindObjectOfType<Player>();
    }

    public void ApplyPickup(PickupType type,Pickup pickup)
    {
        if (type == PickupType.Sarah)
        {
            StartCoroutine(ApplySarah(pickup));
        }
        else if (type == PickupType.Miri)
        {
            ApplyMiri(pickup);
        }
        else if(type == PickupType.Hazan)
        {
            ApplyHazan(pickup);
        }
        else if(type == PickupType.Police)
        {
            ApplyPolice(pickup);
        }
        else if(type == PickupType.Duck)
        {
            ApplyDuck(pickup);
        }
    }

    IEnumerator ApplySarah(Pickup pickup)
    {
        player.SetJumpPower(pickup.Effect_Value);
        yield return new WaitForSeconds(pickup.Effect_Time);
        player.SetJumpPower(-pickup.Effect_Value);
    }

    void ApplyMiri(Pickup pickup)
    {
        GameManager.instance.ModifyMandats(pickup.Effect_Value);
    }

    void ApplyHazan(Pickup pickup)
    {
    }

    void ApplyPolice(Pickup pickup)
    {
        GameManager.instance.ModifyPopularity(pickup.Effect_Value);
    }

    void ApplyDuck(Pickup pickup)
    {
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
    }
}
