using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour
{
    public bool isSelected;
    protected SelectionManager selectionManager;

    private KeyCode multiSelectHoldButton;
    private KeyBindings keyBindings;

    private void Awake()
    {
        selectionManager = FindObjectOfType<SelectionManager>();
        keyBindings = FindObjectOfType<KeyBindings>();
        multiSelectHoldButton = keyBindings.multiSelectHoldButton;

    }



    //selects the game object
    public  void Select()
    {
        if(!isSelected)
        {
           
   
            selectionManager.AddToList(gameObject);
            isSelected = true;
            SelectHelper();
        }

    }

    //deslects the game object
    public  void DeSelect()
    {
        if (isSelected)
        {
            selectionManager.RemoveFromList(gameObject);
            isSelected = false;
            DeSelectHelper();
        }

    }


    //Toggles between selections
    //is the default way of selecting objects in the world so it handles multi selecting
    public  void Toggle()
    {
        if (isSelected)
        {
            //checks is a multi select is happening or not
            //if it is only this objects is deselected
            //if it is not this object is instead selected
            if (!Input.GetKey(multiSelectHoldButton))
                selectionManager.KeepOne(gameObject);
            else
                DeSelect();
        }
        else
        {
            //checks is a multi select is happening or not, deselects everything if it is not
            if (!Input.GetKey(multiSelectHoldButton))
                selectionManager.EmptySelection();

            Select();
        }
        ToggleHelper();
    }


    //contains object specific functionality on select
    protected abstract void SelectHelper();

    //contains object specific functionality on deselect
    protected abstract void DeSelectHelper();

    //contains object specific functionality on toggle
    protected abstract void ToggleHelper();
}
