using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHelper : MonoBehaviour
{
    public float AppleSpawnTime = 3;
    public Transform PointSpawn;
    void Start()
    {
        InvokeRepeating("Timer", 3, AppleSpawnTime);
    }

    void Timer()
    {
        Debug.Log("Timer()");

        GetComponent<Animator>().SetTrigger("GetApple");
        GameObject apple = Instantiate(Resources.Load("Apple"), PointSpawn.position, Random.rotation) as GameObject;
        apple.GetComponent<Rigidbody>().AddForce(apple.transform.forward * 10);
        Destroy(apple, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
