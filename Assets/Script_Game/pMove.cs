using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class pMove : MonoBehaviour
{

    public float speed;
    private Rigidbody rig;
    private bool airJumpAble = true;
    private bool isGrounded = false;
    public int score = 0;
    public int HP = 3;
    public float jumpForce;
    public Transform cam;
    public int totalPoints;

    public TMP_Text uiGame;
    private Boolean isBraking = false;
    public GameManager gameManager;
    public float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Time"))
        {
            time = PlayerPrefs.GetFloat("Time");
        }
        rig = GetComponent<Rigidbody>();
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
        totalPoints = points.Length;
        uiGame.text = "HP : " + HP + "\nPoint : " + score + "/" + totalPoints + "\nTime : " + time.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1) HP = 0;
        time += Time.deltaTime;
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");
        Vector3 moveDir = Quaternion.Euler(0, cam.eulerAngles.y, 0) * new Vector3(xDir, 0.0f, yDir).normalized;

        Moving(moveDir);
        Jump();
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
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        string formattedTime = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        if (HP <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
            speed = 0;
        }
        else
        {
            uiGame.text = "HP : " + HP + "\nPoint : " + score + "/" + totalPoints + "\nTime : " + formattedTime;
        }

    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && HP > 0)
        {
            Vector3 jump = new Vector3(0.0f, transform.position.y + jumpForce, 0.0f);
            if (isGrounded)
            {
                rig.AddForce(jump);
                GetComponent<AudioSource>().Play();
            }
            else if (airJumpAble)
            {
                airJumpAble = false;
                rig.AddForce(jump);
                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void Moving(Vector3 moveDir)
    {

        isBraking = Input.GetKey(KeyCode.Mouse1) && isGrounded;
        if (!isBraking)
            rig.AddForce(moveDir * speed);
        else rig.velocity = Vector3.zero;

    }

}
