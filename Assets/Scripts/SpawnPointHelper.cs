using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointHelper : MonoBehaviour
{
    //boundary points to limit x coordinate of spawn area
    [SerializeField] private Transform topLeftUpper,topLeftLower, topRightUpper,topRightLower
        , bottomLeftUpper,bottomLeftLower, bottomRightUpper, bottomRightLower; 


    public Vector3 GetRandomSpawnPoint()
    {
        Vector3 spawnPoint;
        float randomZ, randomX;

        int breakoutCounter=0, breakoutLimit=30;
        do{

            randomZ = Random.Range(bottomLeftLower.position.z,topLeftUpper.position.z);

            //Generate X coordinate based on generated Z, making sure X stays within bounds
            if(randomZ > topLeftLower.position.z){
                float topLeftZDistance = Mathf.Abs(topLeftUpper.position.z - topLeftLower.position.z);
                float tValue1 = Mathf.Abs(topLeftUpper.position.z-randomZ);
                Vector3 leftBoundary = Vector3.Lerp(topLeftUpper.position,topLeftLower.position,tValue1);

                float topRightZDistance = Mathf.Abs(topRightUpper.position.z - topRightLower.position.z);
                float tValue2 = Mathf.Abs(topRightUpper.position.z-randomZ);
                Vector3 rightBoundary = Vector3.Lerp(topRightUpper.position,topRightLower.position,tValue2);

                randomX = Random.Range(leftBoundary.x,rightBoundary.x);
            }
            else if(randomZ > bottomLeftUpper.position.z){
                randomX = Random.Range(bottomLeftUpper.position.x,bottomRightUpper.position.x);
            }
            else{
                float bottomLeftZDistance = Mathf.Abs(bottomLeftUpper.position.z - bottomLeftLower.position.z);
                float tValue1 = Mathf.Abs(bottomLeftUpper.position.z-randomZ);
                Vector3 leftBoundary = Vector3.Lerp(bottomLeftUpper.position,bottomLeftLower.position,tValue1);

                float bottomRightZDistance = Mathf.Abs(bottomRightUpper.position.z - bottomRightLower.position.z);
                float tValue2 = Mathf.Abs(bottomRightUpper.position.z-randomZ);
                Vector3 rightBoundary = Vector3.Lerp(bottomRightUpper.position,bottomRightLower.position,tValue2);

                randomX = Random.Range(leftBoundary.x,rightBoundary.x);
            }

            spawnPoint = new Vector3(randomX, 0.24f, randomZ);

            //Breakout to prevent infinite looping
            breakoutCounter++; 
            //Debugging infinite looping by checking which colliders overlap
            if(breakoutCounter==breakoutLimit)
            {
                Debug.Log("Limit reached, point:"+spawnPoint);
                Collider[] cols = Physics.OverlapSphere(spawnPoint,0.3f);
                foreach (var col in cols)
                {
                    Debug.Log(col.gameObject.name);
                }
            }

        // //Check collider
        // //restart generation if coin still overlaps
        }while(Physics.OverlapSphere(
            spawnPoint
            ,0.3f)
        .Length>0 && breakoutCounter<breakoutLimit);

        return spawnPoint;
    }

    [SerializeField] private Transform ballSpawnPoint;
    public Vector3 GetBallSpawnPoint(){return ballSpawnPoint.position;}
}

