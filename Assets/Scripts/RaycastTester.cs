//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//[System.Serializable]
//public class StringAudioPair
//{
//    public string label;
//    public AudioClip audioClip;
//}

//[RequireComponent(typeof(LineRenderer))]
//public class RaycastTester : MonoBehaviour
//{
//    [SerializeField] GameObject text_Circle;
//    [SerializeField] GameObject text_Square;
//    [SerializeField] GameObject text_Triangle;
//    //[SerializeField] GameObject text_1;
//    [SerializeField] GameObject Managr;

//    public float rayDistance = 2f;
//    public Color rayColor = Color.red;
//    public float rotationSpeed = 5f;

//    private LineRenderer lineRenderer;
//    private Vector3 lastMousePosition;

//    public TMP_Text narrationTxt;
//    public AudioSource narrationSrc;

//    public List<StringAudioPair> narrationPairs = new List<StringAudioPair>();

//    void Start()
//    {
//        Managr.SetActive(true);
//        text_Circle.SetActive(false);
//        text_Square.SetActive(false);
//        text_Triangle.SetActive(false);
//        //text_1.SetActive(false);

//        StartCoroutine(Activity());
//        // Set up the line renderer
//        lineRenderer = GetComponent<LineRenderer>();
//        lineRenderer.positionCount = 2;
//        lineRenderer.startWidth = 0.5f;
//        lineRenderer.endWidth = 0.5f;
//        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
//        lineRenderer.startColor = rayColor;
//        lineRenderer.endColor = rayColor;

//        Cursor.lockState = CursorLockMode.None;
//        Cursor.visible = true;
//    }

//    void Update()
//    {
//        HandleCameraRotation();
//        UpdateRay();
//        HandleRaycast();
//    }

//    IEnumerator PlayNarration(int id)
//    {

//        var pair = narrationPairs[id];
//        narrationTxt.text = pair.label;
//        narrationSrc.clip = pair.audioClip;
//        narrationSrc.Play();
//        yield return new WaitUntil(() => !narrationSrc.isPlaying);

//    }

//    void HandleCameraRotation()
//    {
//        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
//        {
//            if (Input.GetMouseButtonDown(0))
//            {
//                lastMousePosition = Input.mousePosition;
//            }

//            if (Input.GetMouseButton(0))
//            {
//                Vector3 delta = Input.mousePosition - lastMousePosition;
//                float yaw = delta.x * rotationSpeed * Time.deltaTime;
//                float pitch = -delta.y * rotationSpeed * Time.deltaTime;

//                transform.eulerAngles += new Vector3(pitch, yaw, 0f);
//                lastMousePosition = Input.mousePosition;
//            }
//        }
//    }

//    void UpdateRay()
//    {
//        Vector3 origin = transform.position;
//        Vector3 direction = transform.forward;
//        Vector3 end = origin + direction * rayDistance;

//        lineRenderer.SetPosition(0, origin);
//        lineRenderer.SetPosition(1, end);

//    }
//    IEnumerator Activity()
//    {
//        yield return PlayNarration(0);

//        yield return PlayNarration(1);

//        yield return PlayNarration(2);
//    }


//    void HandleRaycast()
//    {
//        if (Input.GetMouseButtonDown(0) && !(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
//        {
//            RaycastHit hit;
//            Debug.Log("enter");



//            if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
//            {
//                Debug.Log("enter2");

//                if (hit.collider.CompareTag("Circle"))
//                {
//                    Debug.Log("Circle");
//                    text_Circle.SetActive(true);
//                    Destroy(text_Circle, 5f);
//                }
//                if (hit.collider.CompareTag("Square"))
//                {
//                    Debug.Log("Square");
//                    text_Square.SetActive(true);
//                    Destroy(text_Square, 6f);
//                }
//                if (hit.collider.CompareTag("Triangle"))
//                {
//                    Debug.Log("Triangle");
//                    text_Triangle.SetActive(true);
//                    Destroy(text_Triangle, 6f);

//                }



//            }
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTester : MonoBehaviour
{
    [SerializeField] GameObject text_Circle;
    [SerializeField] GameObject text_Square;
    [SerializeField] GameObject text_Triangle;
    [SerializeField] GameObject text_Next;
    [SerializeField] GameObject Managr;
    [SerializeField] GameObject Next_Button;


    private Vector3 lastMousePosition;
    public float rotationSpeed = 5f;
    Camera Cam;

    void Start()
    {

        text_Next.SetActive(false);
        Next_Button.SetActive(false);
        Managr.SetActive(true);
        text_Circle.SetActive(false);
        text_Square.SetActive(false);
        text_Triangle.SetActive(false);
        //text_1.SetActive(false);
        //text_Clock.SetActive(false);
        //text_Door.SetActive(false);
        //text_Pizza.SetActive(false);
        Cam = Camera.main;
        print(Cam.name);
    }

   

    void Update()
    {
       
        HandleCameraRotation();
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = Cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.collider.tag);
                //if (hit.collider.CompareTag("Clock"))
                //{
                //    Debug.Log("Clock");
                //    text_Clock.SetActive(true);
                //    Destroy(text_Clock, 5f);
                //}
                //else
                //{

                //}
                //if (hit.collider.CompareTag("Door"))
                //{
                //    Debug.Log("Door");
                //    text_Door.SetActive(true);
                //    Destroy(text_Door, 6f);
                //}
                //else
                //{

                //}
                //if (hit.collider.CompareTag("Pizza"))
                //{
                //    Debug.Log("Triangle");
                //    text_Pizza.SetActive(true);
                //    Destroy(text_Pizza, 6f);

                //}
                //else
                //{

                //}
                if (hit.collider.CompareTag("Circle"))
                {
                    Debug.Log("Circle");
                    text_Circle.SetActive(true);
                    Destroy(text_Circle, 5f);
                }
                if (hit.collider.CompareTag("Square"))
                {
                    Debug.Log("Square");
                    text_Square.SetActive(true);
                    Destroy(text_Square, 6f);
                    
                }
                if (hit.collider.CompareTag("Triangle"))
                {
                    Debug.Log("Triangle");
                    text_Triangle.SetActive(true);
                    Destroy(text_Triangle, 6f);
                    
                    StartCoroutine(DelayFunction());

                }

            }
        }


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
    IEnumerator DelayFunction()
    {
        yield return new WaitForSeconds (6);
        Next_Button.SetActive(true);
        text_Next.SetActive(true);
        
    }





}

