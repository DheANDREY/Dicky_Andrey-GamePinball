using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    private float posX = 6.22f;
    private float posY = 0.3f;
    private float posZ = -6.7f;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == ball) {
            //reset points and coins
            GameManager.Instance.points = 0;
            GameManager.Instance.coins = 0;

            //spawn ball to starting position
            ball.transform.position = new Vector3(posX, posY, posZ);
        }
    }
}
