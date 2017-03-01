using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVanish : MonoBehaviour {
    public GameObject Object;
    private float delayTime;
    [SerializeField]
    private float Timer = 0f;
	// Use this for initialization
	void Start () {
        delayTime = Random.Range(23, 28);
        Timer = 0f;
	}

    void Update()
    {
        if (Object == null) return;
        else
        {
            Timer += Time.deltaTime;
            if (Timer >= delayTime)
            {
                DestroyObject(Object);
            }
        }
    }
}
