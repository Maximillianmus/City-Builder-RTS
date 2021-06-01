using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 11;
    public float scrollSpeed = 1;
    public float panThickness = 1;

    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    

    private Vector3 InputHelper() 
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(forward) || Input.mousePosition.y >= 0 + panThickness) 
        {
            direction += Vector3.forward;
        }

        if (Input.GetKey(backward) || Input.mousePosition.y <= Screen.height - panThickness)
        {
            direction += Vector3.back;
        }

        if (Input.GetKey(left) || Input.mousePosition.x <= Screen.width - panThickness)
        {
            direction += Vector3.left;
        }

        if (Input.GetKey(right) || Input.mousePosition.x >= 0 + panThickness)
        {
            direction += Vector3.right;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + InputHelper();
    }
}
