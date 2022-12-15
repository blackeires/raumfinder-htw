using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    private GameObject playerObj;
    [SerializeField] 
    private float _movementSpeed = 3;
    public Vector3 playerPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerObj.transform.position, _movementSpeed * Time.deltaTime);
    }
}
