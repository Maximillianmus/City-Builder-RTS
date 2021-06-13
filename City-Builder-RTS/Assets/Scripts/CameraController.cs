using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 11;
    public float scrollSpeed = 1;
    public float panThickness = 1;
    public float rotationSpeed = 100;
    public float lookSpeed = 10;

    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public KeyCode rotateLeft = KeyCode.Q;
    public KeyCode rotateRight = KeyCode.E;

    public KeyCode mouse2 = KeyCode.Mouse2;


    public LayerMask layerMask;

    private Transform mainCamera;
    private float lookXAngle = 38.765f;


    private Vector3 InputHelper() 
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(forward)  || Input.mousePosition.y >= Screen.height - panThickness) 
        {
            direction += transform.forward;
        }

        if (Input.GetKey(backward) || Input.mousePosition.y <= 0 + panThickness)
        {
            direction += -transform.forward;
        }

        if (Input.GetKey(left)  || Input.mousePosition.x <= 0 + panThickness)
        {
            direction += -transform.right;
        }

        if (Input.GetKey(right) || Input.mousePosition.x >= Screen.width - panThickness)
        {
            direction += transform.right;
        }


        direction = direction.normalized * panSpeed * Time.deltaTime;

        if (Input.mouseScrollDelta.y > 0)
        {
            direction += Vector3.up * scrollSpeed;
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            direction += Vector3.down * scrollSpeed;
        }

        return direction;
    }

    void CameraRotation()
    {
        RaycastHit hit;

        
        if (Physics.Raycast(transform.position, mainCamera.forward, out hit, 200, layerMask))
        {
            if (Input.GetKey(rotateLeft))
            {
                transform.RotateAround(hit.point, Vector3.up, -rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(rotateRight))
            {
                transform.RotateAround(hit.point, Vector3.up, rotationSpeed * Time.deltaTime);
            }
            //Debug.DrawRay(transform.position, mainCamera.forward * hit.distance, Color.yellow);
        }
    }

    void CameraLook() 
    {

        if (Input.GetKey(mouse2)) 
        {



            float newX = mainCamera.localEulerAngles.x;
            float newY = mainCamera.localEulerAngles.y;

            if (Input.GetAxis("Mouse Y") != 0)
            {
                //mainCamera.rotation = mainCamera.rotation * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * lookSpeed, -Vector3.right);
                lookXAngle -= Input.GetAxis("Mouse Y") * lookSpeed;
                lookXAngle = Mathf.Clamp(lookXAngle, -90, 90);
                newX = lookXAngle;
                print(lookXAngle);

            }


            if (Input.GetAxis("Mouse X") != 0)
            {
                transform.rotation = transform.rotation * Quaternion.AngleAxis(Input.GetAxis("Mouse X") * lookSpeed, Vector3.up);
            }





            mainCamera.localEulerAngles = new Vector3(newX, newY, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + InputHelper();
        CameraRotation();
        CameraLook();
    }
}
