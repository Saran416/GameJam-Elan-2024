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

    // 0: Sin
    // 1: Constant
    public int gravityType = 0;

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

    float CalcGravity(float x)
    {
        float coeff = 2 * Mathf.PI * frequency / transform.localScale.x;

        switch (gravityType)
        {
            case 0:
                return coeff * Mathf.Cos(coeff * x + phase);
            case 1:
                return x + phase;
            default:
                return 0.0f;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (switchGravity)
        {
            float x = (player.position - playerEnterPos).x;

            

            body.velocity = new Vector3(body.velocity.x, Amplitude * CalcGravity(x), body.velocity.z);
        }
    }
}
