using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Player;
    [SerializeField] private Flashlight flashlight;

    public Transform[] patrolPoints;
    private Transform currentPatrol;

    [NonSerialized]
    public float distanceToPlayer;

    public float followDistance = 10f;
    public float attackDistance = 1f;

    public float speed;
    public float slowedSpeed = 0.1f;
    public float defaultSpeed = 3.5f;
    public bool slowed = false;

    public float rotationSpeed = 5f;

    public bool debug = true;

    public string playerObjectName = "Player";

    private Coroutine rotateCoroutine;



    void Start()
    {
        currentPatrol = patrolPoints[UnityEngine.Random.Range(0, patrolPoints.Length)];

        Player = GameObject.Find(playerObjectName).transform;

        agent.speed = defaultSpeed;

    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (slowed)
        {
            agent.speed = slowedSpeed;
        }
        else
        {
            agent.speed = defaultSpeed;
        }

        if (!flashlight.flashlightActive)
        {
            slowed = false;
            agent.speed = defaultSpeed;
        }
    }

    public void Patrol()
    {

        if (debug == true)
        {
            Material mat = GetComponent<Renderer>().material;
            mat.color = Color.red;
        }

        //rotate towards the target
        //transform.LookAt(currentPatrol.position);
        RotateTowards(currentPatrol);

        agent.SetDestination(currentPatrol.position);

        if (Vector3.Distance(transform.position, currentPatrol.position) < 2.5f)
        {
            currentPatrol = patrolPoints[UnityEngine.Random.Range(0, patrolPoints.Length)];
        }

        if (distanceToPlayer < followDistance)
        {
            // trigger event for the state machine to change to chase
            CustomEvent.Trigger(gameObject, "Follow");

        }

    }

    public void FollowPlayer()
    {

        if (debug == true)
        {
            Material mat = GetComponent<Renderer>().material;
            mat.color = Color.green;
        }

        // rotate towards the player
        //transform.LookAt(Player.position);
         RotateTowards(Player);
       
        agent.SetDestination(Player.position);
        distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer > followDistance)
        {
            CustomEvent.Trigger(gameObject, "Patrol");
        }

        if (distanceToPlayer < attackDistance)
        {
            CustomEvent.Trigger(gameObject, "Attack");
        }
    }


    public void AttackPlayer()
    {

        agent.SetDestination(transform.position);

        if (debug == true)
        {
            Material mat = GetComponent<Renderer>().material;
            mat.color = Color.magenta;
        }

        if (distanceToPlayer > attackDistance + 0.1)
        {
            CustomEvent.Trigger(gameObject, "Follow");

            if (debug == true)
            {
                Material mat = GetComponent<Renderer>().material;
                mat.color = Color.red;
            }
        }

    }


    public void RotateTowards(Transform target)
    {
        // If there's already a rotation happening, stop it
        if (rotateCoroutine != null)
        {
            StopCoroutine(rotateCoroutine);
        }

        // Start the new rotation coroutine
        rotateCoroutine = StartCoroutine(RotateTowardsTargetCoroutine(target));
    }
    private IEnumerator RotateTowardsTargetCoroutine(Transform target)
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            yield return null;
        }

        transform.LookAt(target.position);
    }

    public void SlowDown()
    {
        slowed = true;
    }

    public void DeSLow()
    {
        slowed = false;
    }

}
