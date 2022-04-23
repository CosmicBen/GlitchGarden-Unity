using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{
    private Attacker myAttacker;

    private void Start()
    {
        myAttacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject targetObject = collision.gameObject;
        
        if (targetObject.GetComponent<Defender>() != null)
        {
            myAttacker.Attack(targetObject);
        }
    }
}
