using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private int _lives = 3; 
    private int score = 0;
    public string scoreText = "";
    public GameObject camera;
    [SerializeField] 
    private float _movementSpeed = 1;
    
    public Vector3 rotationsAchse = new Vector3(0f,1f,0f);
    
    private float angle = 0;

    private MainCamera mc;


    // Start is called before the first frame update
    void Start()
    {
        mc = camera.GetComponent<MainCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = new Vector3(Mathf.Sin(angle), 0,Mathf.Cos(angle));
        playerMovement();
        rotate();
    }

    void playerMovement()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(0f, 0f, moveVertical);
        transform.Translate(direction * _movementSpeed * Time.deltaTime);
    }

    /**
     * Rotates the player object around its own y-axis
     */
    void rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle -= 0.01f;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            angle += 0.01f;
        }
        Vector3 targetDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        Quaternion rot = Quaternion.LookRotation(targetDirection, Vector3.up);
        mc.playerRotation = transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 3f * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Collectable")) {
            other.gameObject.SetActive(false);
            score++;
            scoreText = "Score: " + score;
            Debug.Log(scoreText);
        } else if (other.gameObject.CompareTag("Monster"))
        {
            if (_lives == 1)
            {
                gameObject.SetActive(false);
            }
            _lives--;
        }
    }
}
