using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mouselook : MonoBehaviour
{   
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    GameManager gamemanager;
    public int CheckLives;
    public int CheckScore;
    public int CheckFinish;


    public void SlowClicked()
        {
            mouseSensitivity = 50f;
        }
        public void MediumClicked()
        {
            mouseSensitivity = 100f;
        }
        public void FastClicked()
        {
            mouseSensitivity = 200f;
        }
        public void FastestClicked()
        {
            mouseSensitivity = 400f;
        }
     
    // Start is called before the first frame update
    void Start()
    {   
        mouseSensitivity = 100f;
    }

    // Update is called once per frame
    void Update() 
    {       
        gamemanager = GameObject.FindGameObjectWithTag("GameManagerTag").GetComponent<GameManager>();

        CheckLives = gamemanager._lives;
        CheckScore = gamemanager._score;
        CheckFinish = gamemanager.Finish;

        if((CheckLives>0 && CheckScore != 84500) && CheckFinish == 0)
        {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        }

        

    }
}
