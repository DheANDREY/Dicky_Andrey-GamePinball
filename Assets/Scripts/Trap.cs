using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trap : MonoBehaviour
{
    public delegate void OnTrapEvent();
    public static event OnTrapEvent trapSprung,trapDespawn;
    [SerializeField]private float despawnTimer=10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallController>())
        {
            trapSprung.Invoke();
            Destroy(gameObject);
        }
    }
    void Update()
    {
        despawnTimer-=Time.deltaTime;
        if(despawnTimer<=0)
        {
            trapDespawn.Invoke();
            Destroy(this.gameObject);
        }
    }
}
