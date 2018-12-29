using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// destory the gameobject based on time
/// </summary>
public class DestoryOnTime : MonoBehaviour {

    public float destoryTime = 2.0f;
	// Use this for initialization

	void Start () {
        Invoke("Dead", destoryTime);
	}
	
	// Update is called once per frame
	private void Dead ()
    {
        Destroy(gameObject);
	}
}
