using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.GetComponent<Light>().count += 5;
        }
        else if (collision.gameObject.GetComponentInParent<PlayerMovement>() != null)
        {
            collision.gameObject.GetComponent<Light>().count += 5;
        }
    }
}
