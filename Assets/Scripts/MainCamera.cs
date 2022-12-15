using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Quaternion playerRotation = new Quaternion();
    
    public Transform target;
    [SerializeField]
    private Vector3 offsetVector = new Vector3(0, 1, -2);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 back = target.transform.forward;
        back.y = -1f; // this determines how high. Increase for higher view angle.
        transform.position = target.transform.position - back * 8f;
        transform.forward = target.transform.position - transform.position;
    }
}
