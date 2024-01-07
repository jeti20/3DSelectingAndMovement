using UnityEngine;
using UnityEngine.AI;

public class RandomStats : MonoBehaviour
{
    public float speed;
    public float agility;
    public float endurance;
    public float stopDistance = 2.0f;

    private void Start()
    {
        speed = Random.Range(1f, 3f);
        agility = Random.Range(1f, 3f);
        endurance = Random.Range(1f, 3f);
    }

    private void Update()
    {
        if (UnitSelections.Instance.unitSelected.Count > 0)
        {
            GameObject selectedUnit = UnitSelections.Instance.unitSelected[0];
            float distance = Vector3.Distance(transform.position, selectedUnit.transform.position);

            // Adjust the speed based on the speed variable
            float currentSpeed = speed * Time.deltaTime;

            if (distance > stopDistance)
            {
                // Set up the target position from the target
                Vector3 targetPosition = selectedUnit.transform.position + (selectedUnit.transform.forward * stopDistance);

                // Move to the target unit (unitSelected)
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed);
                //added this because before when player changed the selected unit, the unit that become not selected was not following the new selected obj, some blue arrow showed oposite direction, some kind of force
                if (this != selectedUnit)
                {
                    NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
                    navMeshAgent.ResetPath();
                }
            }
        }
    }
}
