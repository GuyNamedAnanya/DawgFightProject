using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int damage = 20;

    public int DamageDealt()
    {
        return damage;
    }

    public void Hit()
    {
        //destroys object on hit
        Destroy(gameObject);
    }
}
