using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //[SerializeField] private Material highlightMaterial;
    //// Update is called once per frame
    //private void Update()
    //{
    //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        var selection = hit.transform;
    //        var selectionRanderer = selection.GetComponent<Renderer>();
    //        if (selectionRanderer != null)
    //        {
    //            selectionRanderer.material = highlightMaterial;
    //        }
    //    }
    //}
    [SerializeField] GameObject text_Door;
    [SerializeField] GameObject text_Pizza;
    [SerializeField] GameObject text_Clock;
    [SerializeField] GameObject text_Next;
    [SerializeField] GameObject Next_Button;
    
    bool raycast = false;
    


    private Vector3 lastMousePosition;
    public float rotationSpeed = 5f;
    Camera Cam;

    void Start()
    {
        Next_Button.SetActive(false);
        text_Next.SetActive(false);
        text_Door.SetActive(false);
        text_Pizza.SetActive(false);
        raycast = true;
        Cam = Camera.main;
        print(Cam.name);
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
                if (hit.collider.CompareTag("Clock"))
                {
                    Debug.Log("Clock");
                    text_Clock.SetActive(true);
                    Destroy(text_Clock, 3f);
                    
                }
                //else if (!hit.collider.CompareTag("Clock"))
                //{
                //    text_Clock1.SetActive(true);
                //    Destroy(text_Clock1, 5f);

                //}
                if (hit.collider.CompareTag("Door"))
                {
                    Debug.Log("Door");
                    text_Door.SetActive(true);
                    Destroy(text_Door, 3f);
                    
                }
                if (hit.collider.CompareTag("Pizza"))
                {
                    Debug.Log("Triangle");
                    text_Pizza.SetActive(true);
                    Destroy(text_Pizza,3f);
                    StartCoroutine(Control());
                }

            }
        }

    }

    IEnumerator Control()
    {
        yield return new WaitForSeconds(5f);
        text_Next.SetActive(true);
        Next_Button.SetActive(true);    
    }





}
