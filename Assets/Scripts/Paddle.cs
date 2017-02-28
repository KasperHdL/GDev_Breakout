using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float maxX;

    public float vel;
    public float speed;

    public float scalarX;
    public float scalarY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");


        Vector3 v = transform.position;
        v.x +=  h * speed;
        if(Mathf.Abs(transform.position.x) > maxX)
            v.x = Mathf.Sign(transform.position.x) * maxX;

        transform.position = v;

        transform.localScale = new Vector3(2 + scalarX * Mathf.Abs(h), .5f - scalarY * Mathf.Abs(h), 1);

		
	}
}
