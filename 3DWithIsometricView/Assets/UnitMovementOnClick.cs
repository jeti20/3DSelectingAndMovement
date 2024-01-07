
using UnityEngine;
using UnityEngine.AI;

public class UnitMovementOnClick : MonoBehaviour
{
    Camera myCam;
    NavMeshAgent myAgent;
    public LayerMask groud;

    private void Start()
    {
        //mouse click movement
        myCam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groud))
            {
                myAgent.SetDestination(hit.point);
            }
        }
    }
}
