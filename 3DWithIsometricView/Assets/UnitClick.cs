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

                //shift + click
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    //Shift clicked
                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject); //(clickable game object
                }

                //click
                else
                {
                    UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
                }

            }
            else
            {
                //if we didn't click clickable object && we are not holding shift
                if(!Input.GetKey(KeyCode.LeftShift)) 
                {
                    UnitSelections.Instance.DeselectAll();
                }
            }

        }

        /*if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groudMarker.transform.position = hit.point;
                groudMarker.SetActive(true);
                groudMarker.SetActive(false);
            }
        }*/
    }

    
}
