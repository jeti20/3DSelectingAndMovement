using UnityEngine;
using UnityEngine.AI;

public class UnitMovementOnClick : MonoBehaviour
{
    Camera myCam;
    NavMeshAgent myAgent;
    public LayerMask groud;

    private void Start()
    {
        myCam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        MovementOnClick();
    }

    private void MovementOnClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groud))
            {
                // reference to speed from RandomStats
                RandomStats randomStats = GetComponent<RandomStats>();
                if (randomStats != null)
                {
                    myAgent.speed = randomStats.speed;
                }

                //set destination after click
                myAgent.SetDestination(hit.point);
            }
        }
    }
}
