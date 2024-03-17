using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mdie : MonoBehaviour
{
    public Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponentInParent<Rigidbody>().velocity = Vector3.zero;

        other.gameObject.GetComponentInParent<Rigidbody>().transform.position = respawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
