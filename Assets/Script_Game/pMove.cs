using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pMove : MonoBehaviour
{

    public float speed;
    private Rigidbody rig;
    private bool airJumpAble = true;
    private bool isGrounded = false;
    public int score = 0;
    public int scoreReq = 5;
    public int HP = 3;
    public float jumpForce;
    public Transform cam;
    public int totalPoints;

    public TMP_Text uiGame;
    public float time = 0f;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
        totalPoints = points.Length;
        uiGame.text = "HP : " + HP + "\nPoint : " + score + "/" + totalPoints + "\nTime : " + time.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        Vector3 moveDir = Quaternion.Euler(0, cam.eulerAngles.y, 0) * new Vector3(xDir, 0.0f, yDir).normalized;

        //transform.position += moveDir * speed;
        rig.AddForce(moveDir * (speed * 2));

        if (Input.GetButtonDown("Jump") && HP > 0)
        {
            Vector3 jump = new Vector3(0.0f, transform.position.y + jumpForce, 0.0f);
            if (isGrounded)
            {
                rig.AddForce(jump);
            }
            else if (airJumpAble)
            {
                airJumpAble = false;
                rig.AddForce(jump);
            }
        }
        updateUI();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            airJumpAble = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void updateUI()
    {

        if (score == totalPoints)
        {
            FindObjectOfType<GameManager>().CompleteLevel();
        }
        if (HP <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
            uiGame.text = "HP : " + HP + "\nPoint : " + score + "\nTime : " + time.ToString("F2") + "\nGame Over";
            speed = 0;
        }
        else
        {
            uiGame.text = "HP : " + HP + "\nPoint : " + score + "/" + totalPoints + "\nTime : " + time.ToString("F2");
        }

    }
}
