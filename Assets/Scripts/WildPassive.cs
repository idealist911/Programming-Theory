using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPassive : Wild
{
    bool attacked = false;

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

    protected override void Attack(GameObject player)
    {
        Debug.Log("Enemy attacking!");
        player.GetComponent<PlayerController>().UpdateHealth(-5);
    }
}
