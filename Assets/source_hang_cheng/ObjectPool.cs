using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;  // hold all the instantiated bullets
    public GameObject objectToPool; // the basic bullet
    public int amountToPool;  // how many bullet do you want to create in the pool


    private void Awake()
    {
        SharedInstance = this;  // initialize this SharedInstance var
    }


    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i]; 
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
