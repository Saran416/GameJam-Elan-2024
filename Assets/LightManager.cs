using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Light : MonoBehaviour
{
    public int count = 10;
    public bool isOn = false;
    public GameObject torch;
    private float startTime = 0f;
    public Text countDisplay;
    public float tempTime = 0f;
    public GameObject img;

    public void Start()
    {
        torch.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.E) && !isOn && count > 0){
            startTime = Time.time;
            tempTime = Time.time;
            isOn  = true;
            torch.SetActive(true);
            count--;
        }
        if (isOn)
        {
            img.GetComponent<Transform>().localScale = new Vector3(1 - (Time.time - tempTime) / 4f, 0.15f, 1f);
        }
        countDisplay.text = "Matches Left: " + count;
        
        if (Time.time - startTime > 4f)
        {
            isOn = false;
            torch.SetActive(false);
        }
        
    }
}
