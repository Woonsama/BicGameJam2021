using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force1 : MonoBehaviour
{
    private Vector3 firstPos;
    private Vector3 curPos;

    public Vector3 direction;
    public float range = 10f;
    public float power = 10000f;
    public float speed = 0.1f;

    private void Start()
    {
        firstPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;
        curPos = transform.position;
        if (Vector3.Distance(firstPos, curPos) > range)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        "Trigger".Log();
        if(other.tag == "NPC")
        {
            direction = other.transform.position - transform.position + transform.forward;
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction*power, ForceMode.Impulse);
            Destroy(this.gameObject);
        }
    }
}
