using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private bool spawn = true;
    [SerializeField] private float minSpawnDelay = 1.0f;
    [SerializeField] private float maxSpawnDelay = 5.0f;
    [SerializeField] private Attacker[] attackerPrefabs = new Attacker[0];

    private IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackerPrefabs.Length);
        Spawn(attackerPrefabs[attackerIndex]);
    }

    private void Spawn(Attacker attackerPrefab)
    {
        Attacker attacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity);
        attacker.transform.SetParent(transform);
    }

    public void StopSpawning()
    {
        spawn = false;
    }
}
