using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float rotationSpeed = 360.0f;
    [SerializeField] private float damage = 100.0f;

    private void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(0.0f, 0.0f, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health attackerHealth = collision.GetComponent<Health>();
        Attacker attacker = collision.GetComponent<Attacker>();

        if (attackerHealth != null && attacker != null)
        {
            Destroy(gameObject);
            attackerHealth.DealDamage(damage);
        }
    }
}
