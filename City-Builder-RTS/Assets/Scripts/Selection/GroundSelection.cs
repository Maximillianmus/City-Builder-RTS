using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSelection : Selectable
{

    protected override void DeSelectHelper()
    {

    }

    protected override void SelectHelper()
    {
        selectionManager.EmptySelection();
    }

    protected override void ToggleHelper()
    {

    }
}
