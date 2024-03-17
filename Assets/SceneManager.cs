using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var scene = SceneManager.LoadSceneAsync("FGravity");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
