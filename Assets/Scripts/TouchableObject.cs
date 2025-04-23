using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchableObject : MonoBehaviour
{
    [SerializeField] GameObject text;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.tag == "Circle")
        {
            text.SetActive(true);
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
