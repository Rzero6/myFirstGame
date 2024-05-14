using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 1.0f;
    public float distance = 3.0f;
    public Vector3 direction = Vector3.right;
    public Vector3 offset;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isOnTop = false;
    public GameObject player;

    void Start()
    {
        initialPosition = transform.position;
        SetTargetPosition();
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (isOnTop)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);
        }
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnTop = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnTop = false;
        }
    }


}
