using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public int minTime = 1;
    public int maxTime = 5;
    public int timeToSpawn = 0;
    public float timer = 0;
    public GameObject obstaculo = null;
    
    
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = Random.Range(minTime,maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeToSpawn)
        {
            Instantiate(obstaculo, transform);
            timer = 0;
            timeToSpawn = Random.Range(minTime,maxTime);
            timeToSpawn = Random.Range(minTime,maxTime);
        }
    }
}
