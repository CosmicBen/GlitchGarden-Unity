using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Animator))]
public class Fox : MonoBehaviour
{
    private Attacker myAttacker;
    private Animator myAnimator;

    private void Start()
    {
        myAttacker = GetComponent<Attacker>();
        myAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject targetObject = collision.gameObject;

        if (targetObject.GetComponent<Defender>() != null)
        {
            Gravestone gravestone = targetObject.GetComponent<Gravestone>();

            if (gravestone != null)
            {
                myAnimator.SetTrigger("Jump");
            }
            else
            {
                myAttacker.Attack(targetObject);
            }
        }
    }
}
