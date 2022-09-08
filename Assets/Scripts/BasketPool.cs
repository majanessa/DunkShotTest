using System.Collections.Generic;
using DunkShot.Controllers;
using UnityEngine;

namespace DunkShot
{
    public class BasketPool : MonoBehaviour {

        public static BasketPool Instace { get; private set; }

        public List<GameObject> pooledObjects;
        public GameObject objectToPool;
        public int amountToPool;

        private void Awake() 
        {
            Instace = this;
        }

        private void Start()
        {
            pooledObjects = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = Instantiate(objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
            GetPooledObject().SetActive(true);
        }

        public GameObject GetPooledObject()
        {
            foreach (var t in pooledObjects)
            {
                if (!t.activeInHierarchy)
                {
                    float xPos = Random.Range(1f, 2f);
                    t.transform.position = new Vector2(xPos, transform.position.y + 2f);
                    t.transform.rotation = Quaternion.Euler(0, 0, 30f);
                    t.GetComponent<BasketController>().ChangeColorRingRed();
                    return t;
                }
            }

            return null;
        }
    }
}
