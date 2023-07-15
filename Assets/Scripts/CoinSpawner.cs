using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    private float coinSpawnDelay = 3f;
    private int maxCoins = 3;
    private float coinDisappearDelay = 10f;
    private float timeSinceLastSpawn;

    public int coinsCount;
    public static CoinSpawner Instance {get; private set;}

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        timeSinceLastSpawn = coinSpawnDelay;
        coinsCount = 0;
    }

    private void Update()
    {
        // spawn coins with a delay
        if (coinsCount < maxCoins) {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= coinSpawnDelay) {
                SpawnCoin();
                timeSinceLastSpawn = 0f;
            }
        }
    }

    private void SpawnCoin()
    {
        GameObject newCoin = Instantiate(coinPrefab, GetRandomPosition(), Quaternion.identity);
        coinsCount++;

        // Destroy the coin if not hit after a delay
        StartCoroutine(DestroyCoin(newCoin));
    }

    private IEnumerator DestroyCoin(GameObject coin)
    {
        yield return new WaitForSeconds(coinDisappearDelay);

        if (coin != null) {
            coinsCount--;
            Destroy(coin);
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-5f, 5.5f), 0.12f, Random.Range(-5.5f, -1f));
    }
}
