using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pointer : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPont;
    [SerializeField] float targetDistance;
    bool isFireing = false;
    void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        ProccessFiring();
        moveCrosshair();
        moveTargetPoint();
        AimLaser();
    }
   
    void ProccessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFireing;
        }
    }
    void moveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
    void moveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPont.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    void AimLaser()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPont.position - laser.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
