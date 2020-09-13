using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple : MonoBehaviour
{
    public float rCubeCounter;
    public GameObject randomCube;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("this is where the scene get initialised"); // 
    }

    // Update is called once per frame
    void Update()
    {
       rCubeCounter += 0.1f;
        // Debug.Log("Count= " + frameCounter++ ); // 
        randomCube.transform.position = new Vector3(Mathf.Sin(rCubeCounter), Mathf.Cos(rCubeCounter), 0);
    }
}
