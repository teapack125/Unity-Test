using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private const float Y_ANG_MIN = -3.0f;
    private const float Y_ANG_MAX = 80.0f;


    public GameObject player;

    private Transform lookAt;
    private Transform camTransform;

    private Camera cam;

    private float distance = 5.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensitivityX = 4.0f;
    public float sensitivityY = 4.0f;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        cam = Camera.main;
        lookAt = player.transform; 
        camTransform = transform;
       
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = player.transform.position + offset;

        currentX += Input.GetAxis("Mouse X")*sensitivityX;
        currentY -= Input.GetAxis("Mouse Y")*sensitivityY;

        currentY = Mathf.Clamp(currentY, Y_ANG_MIN, Y_ANG_MAX);
    }
    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
