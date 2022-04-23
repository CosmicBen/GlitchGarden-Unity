using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private LivesDisplay livesDisplay = null;

    private void Awake()
    {
        livesDisplay = FindObjectOfType<LivesDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        livesDisplay.TakeLife();
        Destroy(collision.gameObject);
    }
}
