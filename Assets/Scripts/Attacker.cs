using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 5.0f)] private float currentSpeed = 1.0f;
    private GameObject currentTarget;
    private Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        FindObjectOfType<LevelController>().AttackerSpawned();
    }


    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();

        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (currentTarget == null)
        {
            myAnimator.SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        myAnimator.SetBool("IsAttacking", target != null);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget != null)
        {
            Health targetHealth = currentTarget.GetComponent<Health>();

            if (targetHealth != null)
            {
                targetHealth.DealDamage(damage);
            }
        }
    }
}
