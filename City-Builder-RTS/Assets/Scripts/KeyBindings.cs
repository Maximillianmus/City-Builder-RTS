using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//class that contains all keybindings, this helps make sure that all changes are uniform and stops overlapping keys
public class KeyBindings : MonoBehaviour
{
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public KeyCode rotateLeft = KeyCode.Q;
    public KeyCode rotateRight = KeyCode.E;


    public KeyCode mainClick = KeyCode.Mouse0;
    public KeyCode secondaryClick = KeyCode.Mouse1;


    public KeyCode scrollwheelClick = KeyCode.Mouse2;

}
