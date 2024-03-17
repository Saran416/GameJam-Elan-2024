using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour
{
    public Transform player;
    public Rigidbody body;

    public float frequency = 1.0f;
    public float phase = 0.0f;
    public float Amplitude = 10.0f;

    public float gravityField = 1.0f;
    
    public Vector3 playerEnterPos = Vector3.zero;

    bool switchGravity = false;

    // Start is called before the first frame update
    void Start()
    {
        ;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switchGravity = true;

            other.gameObject.GetComponentInParent<WallRunTutorial>().SinGravity = true;

            playerEnterPos = other.transform.position;

            body.useGravity = false;

            player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switchGravity = false;

            other.gameObject.GetComponentInParent<WallRunTutorial>().SinGravity = false;

            playerEnterPos = other.transform.position;

            body.useGravity = true;

            player = other.transform;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (switchGravity)
        {
            float x = (player.position - playerEnterPos).x;

            float coeff = 2 * Mathf.PI * frequency / transform.localScale.x;

            body.velocity = new Vector3(body.velocity.x, Amplitude * coeff * Mathf.Cos(coeff * x + phase), body.velocity.z);
        }
    }
}
