using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingHookSpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject fishingLine;
    [SerializeField] private GameObject fakePlayer;
    [SerializeField] private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float num = Random.value;
        if(num < 0.0005)
        {
            GameObject creation = Instantiate(fishingLine, new Vector3(-8.5f + Random.Range(0, 7), 6, 0), new Quaternion());

        }else if (num < 0.001)
        {
            GameObject creation = Instantiate(fishingLine, new Vector3(8.5f - Random.Range(0, 7), 6, 0), new Quaternion());
            creation.GetComponent<FishingLineBehaviour>().right = false;

        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            GameObject fake = Instantiate(fakePlayer, new Vector3(mousePos.x, mousePos.y, 0), new Quaternion());
            fake.GetComponent<PlayerMovement>().FRICTION = 0f;
        }
    }
}
