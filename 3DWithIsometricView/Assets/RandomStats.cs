using UnityEngine;
using UnityEngine.AI;

public class RandomStats : MonoBehaviour
{
    public float speed;
    public float agility;
    public float endurance;
    public float stopDistance = 2.0f;
    public float originalSpeed;
    public float originalEndurance;
    public float regenerationSpeed = 1.0f;
    private bool canMove = false; 

    private void Start()
    {
        speed = Random.Range(1f, 3f);
        agility = Random.Range(1f, 3f);
        endurance = Random.Range(1f, 2f);
        originalSpeed = speed;
        originalEndurance = endurance;
    }

    private void Update()
    {
        Following();
    }

    private void Following()
    {
        if (UnitSelections.Instance.unitSelected.Count > 0)
        {
            GameObject selectedUnit = UnitSelections.Instance.unitSelected[0];
            float distance = Vector3.Distance(transform.position, selectedUnit.transform.position);

            // Adjust the speed based on the speed variable
            float currentSpeed = speed * Time.deltaTime;

            if (endurance > 0 && canMove)
            {
                speed = originalSpeed;
                if (distance > stopDistance)
                {
                    // Set up the target position from the target
                    Vector3 targetPosition = selectedUnit.transform.position + (selectedUnit.transform.forward * stopDistance);

                    // Move to the target unit (unitSelected)
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed);
                    endurance = Mathf.Clamp(endurance - Time.deltaTime, 0, originalEndurance); // reducing endurane
                    // Added this because before when player changed the selected unit, the unit that became not selected was not following the new selected obj, some blue arrow showed the opposite direction, some kind of force
                    if (this != selectedUnit)
                    {
                        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
                        navMeshAgent.ResetPath();
                    }
                }
            }
            else
            {
                // if unit has max endurance can move
                speed = 0;
                if (endurance == originalEndurance)
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }

                endurance = Mathf.Clamp(endurance + Time.deltaTime * regenerationSpeed, 0, originalEndurance);
            }
        }
    }
}
