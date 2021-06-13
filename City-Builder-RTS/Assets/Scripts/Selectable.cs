using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour
{
    public bool isSelected;

    public abstract bool Select();

    public abstract bool deSelect();
}
