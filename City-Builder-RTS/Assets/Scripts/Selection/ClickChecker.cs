using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//this object currently only handles clicking in the world and not UI
//so if UI clicking should be implemented this is probably a fitting place to do it
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
                    selected.Toggle();

                //if more types of clicking should be added, they should be added here. For example UI
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
               //should probably be movement for units or deselect for everything else.
            }

        }
    }

}
