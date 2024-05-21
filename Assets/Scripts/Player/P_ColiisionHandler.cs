using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ColiisionHandler : MonoBehaviour
{
    [SerializeField] private P_Stat stat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask otherLayer = collision.gameObject.layer;
        if (otherLayer == LayerMask.NameToLayer("Enemy"))
        {
            stat.CurrentDistance -= stat.CollisionDamageValue;
        }
    }
}
