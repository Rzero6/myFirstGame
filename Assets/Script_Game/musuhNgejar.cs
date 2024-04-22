using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class musuhNgejar : MonoBehaviour
{
    public Transform player;
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
        if (player.GetComponent<pMove>().HP > 0)
            agent.SetDestination(player.position);
        else
            agent.isStopped = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<pMove>().HP--;
            collision.gameObject.GetComponent<pMove>().updateUI();
        }
    }
}
