using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickButten : MonoBehaviour
{
    [SerializeField] TMP_Text playeingtext;
    [SerializeField] float destance = 100f;
   
   

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            float distance = 100f;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
            {
                Debug.Log(hit.collider.name);
            }
        }













        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit,Mathf.Infinity))
        //{
        //    if (hit.collider.CompareTag("Circle"))
        //    {
        //        TextMeshPro tmp = hit.collider.GetComponent<TextMeshPro>();
        //        //playeingtext.text = hit.collider.GetComponent<TMPro()>;
        //        Debug.Log("Clicked on a circle!");

        //        // Do something here
        //    }
        //    if (hit.collider.CompareTag("Square"))
        //    {
        //        Debug.Log("Clicked on a Square!");
        //    }
        //    if (hit.collider.CompareTag("Triangle"))
        //    {
        //        Debug.Log("Clicked on a Triangle!");
        //    }
        //}
        //}

    }


}
