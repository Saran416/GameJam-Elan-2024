using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public GameObject[] wavepoints;
    public int currIndex = 0;
    public float speed = 2f;

    private void Update()
    {
        if (Vector3.Distance(transform.position, wavepoints[currIndex].transform.position) < 0.1f)
        {
            currIndex++;
            if(currIndex >= wavepoints.Length) {
                currIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, wavepoints[currIndex].transform.position, speed*Time.deltaTime);
    }

   
}
