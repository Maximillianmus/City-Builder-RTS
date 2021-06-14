using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour
{
    public bool isSelected;
    protected SelectionManager selectionManager;

    private void Awake()
    {
        selectionManager = FindObjectOfType<SelectionManager>();
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


    //toggles the game object
    public  void Toggle()
    {
        if (isSelected)
            selectionManager.RemoveFromList(gameObject);
        else
            selectionManager.AddToList(gameObject);

        isSelected = !isSelected;
        ToggleHelper();
    }



    //contains object specific functionality on select
    protected abstract void SelectHelper();

    //contains object specific functionality on deselect
    protected abstract void DeSelectHelper();

    //contains object specific functionality on toggle
    protected abstract void ToggleHelper();
}
