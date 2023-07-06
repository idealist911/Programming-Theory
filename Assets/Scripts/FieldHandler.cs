using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldHandler : MonoBehaviour
{
    Collider collider;
    GameObject player;
    float chance = 0.2f;
    float rand;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if (collider.bounds.Contains(player.transform.position) && (rand = Random.Range(0.0f, 1.0f)) < chance)
        //{
        //    // enter battle
        //    Debug.Log("Entering battle");
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && (rand = Random.Range(0.0f, 1.0f)) < chance)
        {
            // enter battle
            Debug.Log("Entering battle");
            UnityEngine.SceneManagement.SceneManager.LoadScene(GameManager.scenes["Safari"]);
        }
    }
}
