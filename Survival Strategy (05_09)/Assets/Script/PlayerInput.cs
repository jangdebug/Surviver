using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float m_fSpeed = 40.0f;
    [SerializeField] NavMeshAgent agent;

    Rigidbody rigid;
    Vector3 m_vecTarget;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        m_vecTarget = transform.position;
        agent.speed = m_fSpeed;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        //if (Input.GetMouseButtonDown(1) && agent.enabled)
        if (Input.GetMouseButtonDown(1))
            {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                Debug.Log(hit.point);
                m_vecTarget = hit.point;
                agent.SetDestination(hit.point);
            }
        }
    }
}
