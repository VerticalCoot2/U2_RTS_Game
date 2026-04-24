using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UnitController : Unit
{
    public static float delay = 0.5f;
    private NavMeshAgent agent;
    private Animator anim;
    private RaycastHit hit;
    private MySelectable ms;

    void SetAlly()
    {
        name = "Ally";
        health = 500;
        damage = 100;
    }
    void Start()
    {
        SetAlly();

        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ms = GetComponent<MySelectable>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        if (ms.selected)
        {
            anim.SetFloat("Running", agent.remainingDistance);

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    agent.destination = hit.point;
                }
            }
        }
        else
        {
            anim.SetFloat("Running", 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            agent.destination = other.gameObject.transform.position;
            anim.SetBool("Attack", true);
            StartCoroutine(Attack(other));
        }
    }

    IEnumerator Attack(Collider col)
    {
        EnemyController ec = col.GetComponent<EnemyController>();
        while(col != null && ec.health > 0)
        {
            transform.LookAt(col.transform);
            ec.health -= damage;
            yield return new WaitForSeconds(delay * 3f);
        }

        anim.SetBool("Attack", false);
        if (col != null)
        {
            Destroy(col.gameObject, delay);
        }

    }
}
