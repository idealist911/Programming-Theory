using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildAggro : Wild
{
    public bool attacking;
    private Coroutine attackCoroutine = null;
    private float attackRange = 0.5f;

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
        // Always seeking the player
        Vector3 vectorToPlayer = (player.transform.position - transform.position);
        float dSqrToPlayer = vectorToPlayer.sqrMagnitude;
        if (dSqrToPlayer > attackRange)
        {
            //if (attackCoroutine != null)
            //    StopCoroutine(attackCoroutine);

            transform.Translate(vectorToPlayer.normalized * speed * Time.deltaTime);
        }
        else
        {
            attackCoroutine = StartCoroutine(AttackCoroutine(player));
        }
        
    }

    protected override void Attack(GameObject player)
    {
        Debug.Log("Attack!");
        player.GetComponent<PlayerController>().UpdateHealth(-5);
    }
}
