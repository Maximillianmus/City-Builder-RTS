using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickChecker : MonoBehaviour
{

    private KeyBindings keybindings;


    private KeyCode mainClick;
    private KeyCode secondaryClick;
    // Start is called before the first frame update
    void Start()
    {

        keybindings = FindObjectOfType<KeyBindings>();
        mainClick = keybindings.mainClick;
        secondaryClick = keybindings.secondaryClick;

    }


    private void Update()
    {
        //checks main key, and selects the object if possible
        if (Input.GetKeyDown(mainClick))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Selectable selected = hit.collider.GetComponent<Selectable>();
                if (selected != null)
                    selected.Select();
            }
           
        }

        //checks secondary key
        if (Input.GetKeyDown(secondaryClick))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
               //no functionality as of right now
            }

        }
    }

    //activates when the object is clicked on
    //TODO add left and right click

}
