using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] private GameObject trapPrefab;
    private float trapSpawnTimer = 3f;
    private int maxTraps = 3;
    private float timeSinceLastSpawn;

    public int trapCount;

    private void Start()
    {
        timeSinceLastSpawn = trapSpawnTimer;
        trapCount = 0;
    }

    private void OnEnable() {
        Trap.trapDespawn +=ReduceTrapCount;
        Trap.trapSprung += ReduceTrapCount;
    }

    private void OnDisable() {
        Trap.trapDespawn -=ReduceTrapCount;
        Trap.trapSprung -= ReduceTrapCount;
    }

    private void ReduceTrapCount(){trapCount-=1;}

    private void Update()
    {
        // spawn traps with a delay
        if (trapCount < maxTraps) {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= trapSpawnTimer) {
                SpawnTrap();
                timeSinceLastSpawn = 0f;
            }
        }
    }

    [SerializeField] private SpawnPointHelper spawnHelper;

    private void SpawnTrap()
    {
        Instantiate(trapPrefab, spawnHelper.GetRandomSpawnPoint(), Quaternion.identity);
        trapCount++;
    }

}
