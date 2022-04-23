using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const string DEATH_VFX_PARENT_NAME = "Death VFXs";
    private GameObject deathVfxParent = null;

    [SerializeField] private float health = 100.0f;
    [SerializeField] private GameObject deathVfx = null;

    private void Start()
    {
        SetDeathVfxParent();
    }

    private void SetDeathVfxParent()
    {
        deathVfxParent = GameObject.Find(DEATH_VFX_PARENT_NAME);

        if (deathVfxParent == null)
        {
            deathVfxParent = new GameObject(DEATH_VFX_PARENT_NAME);
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            TriggerDeathVfx();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVfx()
    {
        if (deathVfx != null)
        {
            GameObject deathVfxObject = Instantiate(deathVfx, transform.position, Quaternion.identity);
            deathVfxObject.transform.SetParent(deathVfxParent.transform);
            Destroy(deathVfxObject, 3.0f);
        }
    }
}
