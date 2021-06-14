using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this class manages selections, this primarily includes keeping track on all selections and creating an interface to remove selections;
public class SelectionManager : MonoBehaviour
{
    private List<GameObject> currentlySelected;

    private void Start()
    {
        currentlySelected = new List<GameObject>();
    }

    // Start is called before the first frame update

    public void AddToList(GameObject selectedObject)
    {
        currentlySelected.Add(selectedObject);
    }

    public void RemoveFromList(GameObject deselectedObject)
    {
        currentlySelected.Remove(deselectedObject);
    }

    public void EmptySelection()
    {
        int size = currentlySelected.Count;
        for(int i = 0; i < size; i++)
        {
            currentlySelected[0].GetComponent<Selectable>().DeSelect();
        }

    }
}
