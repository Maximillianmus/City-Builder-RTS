using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangelingSelectable : Selectable
{
    public Material activeMaterial;
    private Material unActiveMaterial;
    private Renderer rendererComponent;

    protected override void DeSelectHelper()
    {
        rendererComponent.material = unActiveMaterial;
    }

    protected override void SelectHelper()
    {
        print("selected");
        rendererComponent.material = activeMaterial;

    }

    protected override void ToggleHelper()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        rendererComponent = GetComponent<Renderer>();
        unActiveMaterial = rendererComponent.material;
    }

}
