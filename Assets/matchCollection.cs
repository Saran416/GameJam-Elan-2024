using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchCollection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PlayerObj")
        {
            Debug.Log("tesxt");
        }
    }
}
