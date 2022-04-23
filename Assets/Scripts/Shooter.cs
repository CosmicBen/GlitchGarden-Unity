using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private const string PROJECTILE_PARENT_NAME = "Projectiles";
    private GameObject projectileParent = null;

    [SerializeField] private Transform projectileSpawnPosition = null;
    [SerializeField] private GameObject projectilePrefab = null;
    private AttackerSpawner myLaneSpawner = null;
    private Animator myAnimator = null;
    
    private void Start()
    {
        myAnimator = GetComponent<Animator>();

        CreateProjectileParent();
        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            myAnimator.SetBool("IsAttacking", true);
        }
        else
        {
            myAnimator.SetBool("IsAttacking", false);
        }
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

        if (projectileParent == null)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        
        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;

            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        return myLaneSpawner != null && myLaneSpawner.transform.childCount > 0;
    }

    public void Fire()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, projectileSpawnPosition.position, Quaternion.identity);
        projectileObject.transform.SetParent(projectileParent.transform);

    }
}
