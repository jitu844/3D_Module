using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastNormal : MonoBehaviour
{

    bool raycast = false;


    private Vector3 lastMousePosition;
    public float rotationSpeed = 5f;
    Camera Cam;
    [SerializeField] Animator Circle;
    [SerializeField] Animator Circle1;
    [SerializeField] Animator Circle2;
    [SerializeField] Animator Triangle;
    [SerializeField] Animator Triangle1;
    [SerializeField] Animator Triangle2;
    [SerializeField] Animator Square;
    [SerializeField] Animator Square1;
    [SerializeField] Animator Square2;
    [SerializeField] GameObject Text_Circle;
    [SerializeField] GameObject Text_Rectangle;
    [SerializeField] GameObject Text_Triangle;
    
    void Start()
    {
        Text_Circle.SetActive(false);
        Text_Rectangle.SetActive(false);    
        Text_Triangle.SetActive(false); 
        raycast = true;
        Cam = Camera.main;
        print(Cam.name);
        Circle.enabled = false;
        Circle1.enabled = false;
        Circle2.enabled = false;
        Triangle.enabled = false;
        Triangle1.enabled = false;
        Triangle2.enabled = false;
        Square.enabled = false;
        Square1.enabled = false;
        Square2.enabled = false;
    }


    void Update()
    {
        
        HandleCameraRotation();
        MouseControle();
        Condition();

    }

    void HandleCameraRotation()
    {
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 delta = Input.mousePosition - lastMousePosition;
                float yaw = delta.x * rotationSpeed * Time.deltaTime;
                float pitch = -delta.y * rotationSpeed * Time.deltaTime;

                transform.eulerAngles += new Vector3(pitch, yaw, 0f);
                lastMousePosition = Input.mousePosition;
            }
        }
    }
    private void MouseControle()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = Cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);
    }

    private void Condition()
    {
        
        if (Input.GetMouseButtonDown(0) && raycast)
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.CompareTag("Circle"))
                {
                   Circle.enabled = true;
                    Text_Circle.SetActive(true);
                }
                if (hit.collider.CompareTag("Circle1"))
                {
                    Circle1.enabled = true;
                    Text_Circle.SetActive(true);
                }
                if (hit.collider.CompareTag("Circle2"))
                {
                    Text_Circle.SetActive(true);
                    Circle2.enabled = true;    
                }
                if (hit.collider.CompareTag("Square"))
                {

                    Square.enabled = true;
                    Text_Rectangle.SetActive(true); 
                }
                if (hit.collider.CompareTag("Square1"))
                {
                    Text_Rectangle.SetActive(true);
                    Square1.enabled = true;
                }
                if (hit.collider.CompareTag("Square2"))
                {
                    Text_Rectangle.SetActive(true);
                    Square2.enabled = true;
                }
                if (hit.collider.CompareTag("Triangle"))
                {
                    Text_Triangle.SetActive(true);
                    Triangle.enabled = true;
                }
                if (hit.collider.CompareTag("Triangle1"))
                {
                    Text_Triangle.SetActive(true);
                    Triangle1.enabled = true;
                }
                if (hit.collider.CompareTag("Triangle2"))
                {
                    Text_Triangle.SetActive(true);
                    Triangle2.enabled = true;
                }
               

            }
        }

    }
}
