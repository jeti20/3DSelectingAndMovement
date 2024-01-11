using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    #region SINGLETON
    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }


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
        unitToAdd.GetComponent<UnitMovementOnClick>().enabled = true; //if unit selected enable movement
    }

    public void Deselect()
    {
        foreach (var unit in unitSelected)
        {
            unit.GetComponent<UnitMovementOnClick>().enabled = false; //if unit not selected diseable movement
            unit.transform.GetChild(0).gameObject.SetActive(false); // OFF marker if it is selected
        }
        unitSelected.Clear();
    }
}
