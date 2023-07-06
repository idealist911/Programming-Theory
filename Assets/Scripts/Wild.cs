using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Wild : MonoBehaviour
{
    protected Rigidbody rb;
    protected GameObject player;
    protected float radarRange = 5f;
    public float speed = 3;
    protected float rangeX = 12.6f;
    protected float rangeZ = 7.3f;
    protected float waitTime = 1.0f;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Respond to player's position: whether running away or running towards
    protected virtual void PlayerInRange(GameObject player)
    {

    }

    protected abstract void Attack(GameObject player);

    protected IEnumerator AttackCoroutine(GameObject player)
    {
        yield return new WaitForSeconds(waitTime);
        Attack(player);
    }

    protected void OutOfBounds()
    {
        // Prevent out of bounds
        if (transform.position.x < -rangeX)
            transform.position = new Vector3(-rangeX, transform.position.y, transform.position.z);
        if (transform.position.x > rangeX)
            transform.position = new Vector3(rangeX, transform.position.y, transform.position.z);
        if (transform.position.z < -rangeZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, -rangeZ);
        if (transform.position.z > rangeZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, rangeZ);
    }
}
