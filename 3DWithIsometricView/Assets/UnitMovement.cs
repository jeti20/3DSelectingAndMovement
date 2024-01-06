using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    Camera myCam;
    NavMeshAgent myAgent;
    public LayerMask groud;

    public float speed;
    public float agility;
    public float endurance;


    private void Start()
    {
        //mouse click movement
        myCam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();

        // random stat
        speed = Random.Range(0.1f, 1f);
        agility = Random.Range(1f, 3f);
        endurance = Random.Range(1f, 3f);

        enabled = false;
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
