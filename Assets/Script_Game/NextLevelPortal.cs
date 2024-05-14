using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelPortal : MonoBehaviour
{
    public Material material;
    public GameObject playerObject;
    private pMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = playerObject.GetComponent<pMove>();
    }
    void Update()
    {
        if (playerMove != null && playerMove.score == playerMove.totalPoints)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = material;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<pMove>().score == other.GetComponent<pMove>().totalPoints)
            {
                GetComponent<AudioSource>().Play();
                FindObjectOfType<GameManager>().CompleteLevel(other.GetComponent<pMove>().time);
            }
        }
    }
}
