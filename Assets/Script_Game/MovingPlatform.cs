using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 1.0f;
    public float distance = 3.0f;
    public Vector3 direction = Vector3.right;

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    void Start()
    {
        initialPosition = transform.position;
        SetTargetPosition();
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            SetTargetPosition();
        }
    }

    void SetTargetPosition()
    {
        targetPosition = initialPosition + direction.normalized * distance;
        direction = -direction;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }


}
