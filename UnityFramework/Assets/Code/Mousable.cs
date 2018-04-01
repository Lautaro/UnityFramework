using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mousable : MonoBehaviour
{

    public Action<GameObject> OnDown;
    public Action<GameObject> OnDrag;
    public Action<GameObject> OnUp;
    public Action<GameObject> OnEnter;
    public Action<GameObject> OnOver;
    public Action<GameObject> OnExit;

    [SerializeField]
    private GameObject returnGO;

    /// <summary>
    /// The GameObject you want to get when this object interacts with parent. It could be its parent. 
    /// </summary>
    public GameObject ReturnGO
    {
        get
        {
            if (returnGO == null)
            {
                return gameObject;
            }
            return returnGO;
        }

        set
        {
            returnGO = value;
        }
    }

    void OnMouseDown()
    {
        if (OnDown != null)
        {
            OnDown(ReturnGO);
        }
    }

    void OnMouseDrag()
    {
        if (OnDrag != null)
        {
            OnDrag(ReturnGO);
        }
    }

    void OnMouseUp()
    {
        if (OnUp != null)
        {
            OnUp(ReturnGO);
        }
    }

    void OnMouseEnter()
    {
        if (OnEnter != null)
        {
            OnEnter(ReturnGO);
        }
    }

    void OnMouseOver()
    {
        if (OnOver != null)
        {
            OnOver(ReturnGO);
        }
    }

    void OnMouseExit()
    {
        if (OnExit != null)
        {
            OnExit(ReturnGO);
        }
    }

}
