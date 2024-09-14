using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincSpawner : MonoBehaviour
{
    [SerializeField] GameObject powerUp;
    // Update is called once per frame
    void Update()
    {
        float num = Random.value;
        if(num < 0.001)
        {
            Instantiate(powerUp, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-5, 5), 1), Quaternion.identity);
        }
    }
}
