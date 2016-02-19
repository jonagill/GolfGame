using UnityEngine;
using System;
using System.Collections.Generic;


public class RenderCallbacks : SingletonBehaviour<RenderCallbacks>
{
    public Action OnPostRenderCallbacks;

    private void Awake()
    {
        if (GetComponent<Camera>() == null)
        {
            Debug.LogError("RenderCallbacks needs to be on a camera!");
        }
    }

    private void OnPostRender()
    {
        if (OnPostRenderCallbacks != null)
        {
            OnPostRenderCallbacks();
        }
    }
}
