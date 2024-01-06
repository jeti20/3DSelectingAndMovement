using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera myCam;

    //public GameObject groudMarker;

    public LayerMask clickable;
    public LayerMask ground;

    private void Start()
    {
        myCam = Camera.main;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            //if we click clickableobject
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
            }
            else
            {
                UnitSelections.Instance.DeselectAll();

            }

        }
    }
  
}
