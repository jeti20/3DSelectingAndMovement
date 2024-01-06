using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();

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

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        unitSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true); // ON marker if it is selected
        unitToAdd.GetComponent<UnitMovement>().enabled = true; //if unit selected enable movement
    }

    public void ShiftClickSelect(GameObject unitToAdd) 
    {
        if (!unitSelected.Contains(unitToAdd))
        {
            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true); // ON marker if it is selected
            unitToAdd.GetComponent<UnitMovement>().enabled = true; //if unit selected enable movement
        }
        else
        {
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false); //OFF marker if it isv not selected
            unitSelected.Remove(unitToAdd);
        }
    }

    public void DragSelect(GameObject unitToAdd)
    {
        if (!unitSelected.Contains(unitToAdd))
        {
            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true); // ON marker if it is selected
            unitToAdd.GetComponent<UnitMovement>().enabled = true; //if unit selected enable movement
        }
    }

    public void DeselectAll()
    {
        foreach (var unit in unitSelected) 
        {
            unit.GetComponent<UnitMovement>().enabled = false; //if unit selected diseable movement
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }

        unitSelected.Clear();
    }

    public void Deselect(GameObject unitToDeselect)
    {

    }
}
