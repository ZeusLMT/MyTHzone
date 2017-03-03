using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVanish : MonoBehaviour {
    public GameObject Object;
    private float delayTime;
    private float Timer = 0f;
    public float delayMax;
    public float delayMin;
    // Use this for initialization
    void Start () {
        delayTime = Random.Range(delayMin, delayMax);
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
