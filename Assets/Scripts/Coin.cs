using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float rotationSpeed = 100f;

    void Update()
    {
        // rotate coin
        gameObject.transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bola")
        {
            CoinSpawner.Instance.coinsCount--;
            GameManager.Instance.coins++;
            Destroy(gameObject);
        }
    }
}
