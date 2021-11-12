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

    public void Shoot(Vector3 dir)
    {
        direction = dir;

        Destroy(gameObject, 2f);
    }

    private void Start()
    {
        direction = new Vector3(0, 0, 1f);
        firstPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed);
        curPos = transform.position;
        if (Vector3.Distance(firstPos, curPos) > range)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(direction);
    }

    void OnTriggerEnter(Collider other)
    {
        "Trigger".Log();
        if(other.tag == "NPC")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * power, ForceMode.Impulse);
        }
        
    }
}
