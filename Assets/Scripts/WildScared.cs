using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildScared : Wild
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBounds();

        if (Vector3.Distance(player.transform.position, transform.position) < radarRange)
            PlayerInRange(player);
    }

    protected override void PlayerInRange(GameObject player)
    {
        // Always avoiding the player
        Vector3 direction = -(player.transform.position - transform.position).normalized;
        //rb.AddForce(direction * speed * 10, ForceMode.Force);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    protected override void Attack(GameObject player)
    {

    }
}
