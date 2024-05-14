using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<pMove>().score++;
            other.GetComponent<pMove>().HP++;
            other.GetComponent<pMove>().updateUI();

            other.transform.GetChild(0).GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }


}
