using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    [SerializeField]
    float hazan_multiplier;

    public void ApplyPickUp(Pickup p)
    {
        if (p.GetType() == typeof(SarahPickUp))
            StartCoroutine(ApplySarahPickUp(p.Effect_Time, p.Effect_Value));
        else if (p.GetType() == typeof(PolicePickUp))
            ApplyPolicePickUp(p.Effect_Time, p.Effect_Value);
        else if (p.GetType() == typeof(MiriPickUp))
            ApplyMiriPickUp(p.Effect_Time, p.Effect_Value);
        else if (p.GetType() == typeof(DuckPickUp))
            ApplyDuckPickUp(p.Effect_Time, p.Effect_Value);
        else if (p.GetType() == typeof(HazanPickUp))
            ApplyHazanPickUp(p.Effect_Time, p.Effect_Value);
    }

    IEnumerator ApplySarahPickUp(float effect_time, float effect_value)
    {
        Player player = FindObjectOfType<Player>();
        player.SetJumpPower(effect_value);
        yield return new WaitForSeconds(effect_time);
        player.SetJumpPower(-effect_value);
    }
    private void ApplyPolicePickUp(float effect_time, float effect_value)
    {
        GameManager.instance.ModifyPopularity(effect_value);
    }
    private void ApplyMiriPickUp(float effect_time, float effect_value)
    {
        GameManager.instance.ModifyMandats(effect_value);
    }
    private void ApplyDuckPickUp(float effect_time, float effect_value)
    {

    }
    private void ApplyHazanPickUp(float effect_time, float effect_value)
    {
        GameManager.instance.ModifyMandats(effect_value * -1);
        GameManager.instance.ModifyPopularity(effect_value * hazan_multiplier);
    }
}
