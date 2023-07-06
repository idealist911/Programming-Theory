using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public readonly static HashSet<Enemy> Pool = new HashSet<Enemy>();
    private float health;
    private float maxHealth = 100;
    private HealthController healthController;

    private void OnEnable()
    {
        Enemy.Pool.Add(this);
        health = maxHealth;
        healthController = GetComponent<HealthController>();
        healthController.SetMaxHealth(maxHealth);
        healthController.SetHealth(maxHealth);
    }

    private void OnDisable()
    {
        Enemy.Pool.Remove(this);
    }

    /* Find closest enemy within range */ // ABSTRACTION
    public static Enemy FindClosestEnemy(Vector3 pos, float range) /* input player's position */
    {
        Enemy closestTarget = null;                    /* a record of closest target so far */
        float closestDistanceSqr = Mathf.Infinity;     /* a record of distance to closest target so far */
        var e = Enemy.Pool.GetEnumerator();
        while (e.MoveNext())
        {
            Vector3 vectorToTarget = e.Current.transform.position - pos;
            float dSqrToTarget = vectorToTarget.sqrMagnitude;   /* use distance squared instead of Vector3.Distance()... */
            if (dSqrToTarget < range)
            {
                if (dSqrToTarget < closestDistanceSqr)              /* ...because the latter will do square root, which we don't actually need */
                {
                    closestDistanceSqr = dSqrToTarget;
                    closestTarget = e.Current;
                }
            }
            
        }
        return closestTarget;
    }
    public void UpdateHealth(float value)
    {
        health += value;
        healthController.slider.value += value;

        if (health < 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy dead!");
        }
    }

}
