using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string nextLevel = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var scene = SceneManager.LoadSceneAsync(nextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
