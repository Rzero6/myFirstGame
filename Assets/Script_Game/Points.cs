using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<pMove>().score++;
            other.GetComponent<pMove>().updateUI();
            Destroy(gameObject);
        }
    }


}
