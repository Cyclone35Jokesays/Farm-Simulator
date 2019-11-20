using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StateStuff;

public class Target : MonoBehaviour
{
    public bool switchState = false;
    public float gameTimer;
    public int seconds = 0;

    public StateMachine<Target> stateMachine { get; set; }

    public void Start()
    {
        stateMachine = new StateMachine<Target>(this);
        stateMachine.ChangeState(FirstState.Instance);
        gameTimer = Time.time;    
    }

    public void Update()
    {
        if (Time.time > gameTimer + 1)
        {
            gameTimer = Time.time;
            seconds++;
            Debug.Log(seconds);
        }

        if (seconds == 5)
        {
            seconds = 0;
            switchState = !switchState;
        }

        stateMachine.Update();
    }
}

/* public Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }*/
