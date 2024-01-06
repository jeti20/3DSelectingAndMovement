using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class UnitSelections : MonoBehaviour
{
    #region SINGLETON
    private static UnitSelections _instance;
    public static UnitSelections Instance {  get { return _instance; } }


    private void Awake()
    {
        //if an instance of this already exist and it isnt this one
        if (_instance != null && _instance != this)
        {
            //destrony this instance
            Destroy(this.gameObject);
        }
        else
        {
            //and make the instance
            _instance = this;
        }
    }
    #endregion

    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();

    public void ClickSelect(GameObject unitToAdd)
    {
        Deselect();
        unitSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true); // ON marker if it is selected
        unitToAdd.GetComponent<UnitMovement>().enabled = true; //if unit selected enable movement
    }

    public void Deselect()
    {
        foreach (var unit in unitSelected) 
        {
            unit.GetComponent<UnitMovement>().enabled = false; //if unit selected diseable movement
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }
        unitSelected.Clear();
    }

    //following
    public float followSpeed = 5f;
    public float minDistance = 2f;
    void Update()
    {
        if (unitList.Count > 0 && unitSelected.Count > 0)
        {
            foreach (var unit in unitList)
            {
                if (!unitSelected.Contains(unit))
                {
                    Vector3 targetPosition = unitSelected[0].transform.position;
                    Vector3 direction = targetPosition - unit.transform.position;

                    if (direction.magnitude < minDistance)
                    {
                        Vector3 avoidDirection = unit.transform.position - targetPosition;
                        avoidDirection.Normalize();
                        unit.transform.position += avoidDirection * followSpeed * Time.deltaTime;
                    }
                    else
                    {
                        unit.transform.position = Vector3.MoveTowards(unit.transform.position, targetPosition, followSpeed * Time.deltaTime);
                    }
                }
            }
        }
    }
}
