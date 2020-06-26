using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    private float _baseDamage = 1f;
    public float Value
    {
        get { return _baseDamage * _modifier; }
        set { _baseDamage = value > 0 ? value : 0f; }
    }

    private float _modifier = 1f;

    public void Buff(float buffPercentage)
    {
        _modifier += buffPercentage > 0f ? buffPercentage : 0f;
    }

    public void RemoveBuff(float buffPercentage)
    {
        _modifier -= buffPercentage > 0f ? buffPercentage : 0f;
    }

    public void Debuff(float buffPercentage)
    {
        _modifier -= buffPercentage > 0f ? buffPercentage : 0f;
    }

    public void RemoveDebuff(float buffPercentage)
    {
        _modifier += buffPercentage > 0f ? buffPercentage : 0f;
    }
    // Use this for initialization

}
