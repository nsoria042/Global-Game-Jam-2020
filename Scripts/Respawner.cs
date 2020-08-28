using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public GameObject enemies;
    private GameObject[] respawn_points;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        respawn_points = GameObject.FindGameObjectsWithTag("Spawner");
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
        if (Time.time - timer > 3f)
        {
            Debug.Log("Respawn!");
            Instantiate(enemies, respawn_points[Random.Range(0, respawn_points.Length - 1)].transform.position, gameObject.transform.rotation);
            timer = Time.time;
        }
    }
}
