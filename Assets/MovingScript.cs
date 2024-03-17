using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public GameObject[] wavepoints;
    public int currIndex = 0;
    public float speed = 2f;

    Rigidbody thisRB;
    private void Start()
    {
        thisRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, wavepoints[currIndex].transform.position) < 0.1f)
        {
            currIndex++;
            if (currIndex >= wavepoints.Length)
            {
                currIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, wavepoints[currIndex].transform.position, speed*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.transform.SetParent(null);
        }
    }

}
