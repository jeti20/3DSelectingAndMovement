using UnityEngine;

public class Unit : MonoBehaviour
{
    //Adding and removing units with this script from unitList

    void Start()
    {
        UnitSelections.Instance.unitList.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }
}
