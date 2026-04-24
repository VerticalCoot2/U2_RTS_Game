using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Unit
{
    Transform unit;
    private NavMeshAgent ai;
    private Animator anim;

    void SetEnemy()
    {
        name = "Enemy";
        health = 200;
        damage = 100;
        speed = 3.5f;
    }
    
    void Start()
    {
        SetEnemy();
        ai = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MySelectable.allMySelectables.Count > 0)
        {
            if(unit != null && Vector3.Distance(transform.position, unit.position) < 15)
            {
                transform.LookAt(unit);
                if (Vector3.Distance(transform.position, unit.position) > 1.5f) transform.position += transform.forward * speed * Time.deltaTime;
                anim.SetFloat("Running", speed);
            }
            else
            {
                unit = MySelectable.allMySelectables[Random.Range(0, MySelectable.allMySelectables.Count)].transform;
            }
        }
        if (unit == null) anim.SetFloat("Running", 0);
    }
}
