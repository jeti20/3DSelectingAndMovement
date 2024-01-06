using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRandomStats : MonoBehaviour
{
    public float speed;
    public float agility;
    public float endurance;

    private void Start()
    {
        // Implementacja generowania losowych wartoœci
        speed = Random.Range(0.1f, 1f);
        agility = Random.Range(1f, 3f);
        endurance = Random.Range(1f, 3f);
    }


    
    public float minDistance = 2f;
    void Update()
    {
        if (UnitSelections.Instance.unitList.Count > 0 && UnitSelections.Instance.unitSelected.Count > 0)
        {
            foreach (var unit in UnitSelections.Instance.unitList)
            {
                if (!UnitSelections.Instance.unitSelected.Contains(unit))
                {
                    Vector3 targetPosition = UnitSelections.Instance.unitSelected[0].transform.position;
                    Vector3 direction = targetPosition - unit.transform.position;

                    if (direction.magnitude < minDistance)
                    {
                        Vector3 avoidDirection = unit.transform.position - targetPosition;
                        avoidDirection.Normalize();
                        unit.transform.position += avoidDirection * speed * Time.deltaTime;
                    }
                    else
                    {
                        unit.transform.position = Vector3.MoveTowards(unit.transform.position, targetPosition, speed * Time.deltaTime);
                    }
                }
            }
        }
    }
    /*public float minDistance = 2f;
    void Update()
    {
        if (UnitSelections.Instance.unitList.Count > 0 && UnitSelections.Instance.unitSelected.Count > 0)
        {
            // Zak³adaj¹c, ¿e jednostki w unitList powinny œledziæ jednostki w unitSelected
            foreach (var unit in UnitSelections.Instance.unitList)
            {
                // Aktualizuj pozycjê jednostek w unitList, aby œledzi³y jednostki w unitSelected
                Vector3 targetPosition = UnitSelections.Instance.unitSelected[0].transform.position;
                Vector3 direction = targetPosition - unit.transform.position;

                // Je¿eli jednostka jest za blisko, zatrzymaj j¹ na minimalnej odleg³oœci
                if (direction.magnitude < minDistance)
                {
                    direction.Normalize();
                    unit.transform.position = targetPosition - direction * minDistance;
                }
                else
                {
                    unit.transform.position = Vector3.MoveTowards(unit.transform.position, targetPosition, speed * Time.deltaTime);
                }
            }
        }
    }*/
}
