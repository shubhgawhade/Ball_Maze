using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private bool gyroEnabled;
    
    private Gyroscope gyro;
    private float speed = 1.5f;

    public static Action RulesEnable;
    public static Action RulesDisable;
    public static Action SaveScore;
    public static Action GameOver;

    // Start is called before the first frame update
    void Start()
    {
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (horizontalInput != 0 || verticalInput != 0)
            {
                Vector3 move = new Vector3(horizontalInput, verticalInput, 0);
                move.Normalize();

                transform.position += move * speed * Time.deltaTime;
            }
        }
        else
        {
            float horizontalInput = Input.acceleration.x;
            float verticalInput = Input.acceleration.y;

            if (horizontalInput != 0 || verticalInput != 0)
            {
                Vector3 move = new Vector3(horizontalInput, verticalInput, 0);
                move.Normalize();

                transform.position += move * speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.zero;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enter")
        {
            //print("Start");
            if (RulesEnable != null)
            {
                RulesEnable();
            }
        }

        if (other.gameObject.tag == "Exit")
        {
            if (GameOver != null)
            {
                if (SaveScore != null)
                {
                    SaveScore();
                }
                GameOver();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enter")
        {
            //print("Started");
            if(RulesDisable != null)
            {
                RulesDisable();
            }
        }
    }
}
