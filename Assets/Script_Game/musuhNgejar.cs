using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class musuhNgejar : MonoBehaviour
{
    public Transform player;
    public float lookRadius = 10f;
    private Boolean foundPlayer = false;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= lookRadius) { foundPlayer = true; }
        if (foundPlayer)
        {
            agent.SetDestination(player.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<pMove>().HP--;
            collision.gameObject.GetComponent<pMove>().updateUI();
            GetComponent<Rigidbody>().AddForce((transform.position - collision.transform.position).normalized * 20f, ForceMode.Impulse);
            collision.transform.GetComponent<Rigidbody>().AddForce((collision.transform.position - transform.position).normalized * 20f, ForceMode.Impulse);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
