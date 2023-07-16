using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    [SerializeField]private SpawnPointHelper helper;

    private void OnEnable() {
        Trap.trapSprung += ResetBall;
    }
    private void OnDisable() {
        Trap.trapSprung -= ResetBall;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<BallController>()) {
            ResetBall();
        }
    }

    public void ResetBall(){
        
        //reset points and coins
        GameManager.Instance.points = 0;
        GameManager.Instance.coins = 0;

        //spawn ball to starting position
        ball.transform.position = helper.GetBallSpawnPoint();
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    }
}
