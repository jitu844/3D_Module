using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkingeffect : MonoBehaviour
{
    public Color startColor = Color.yellow;
    public Color endColor = Color.black;
    [Range(0,10)]
    public float speed = 1.0f;
    Renderer ren;
    void Awake()
    {
        ren = GetComponent<Renderer>();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
        {
           ren.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time + speed,1));

        }
    }
}
