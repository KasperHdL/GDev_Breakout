using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 direction;
    public float speed;

    public float rot;
    public float rotSpeed;

    public Rigidbody body;
	// Use this for initialization
	void Start () {
        direction = new Vector3(1,1,0).normalized;
        body = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        rot = rotSpeed;
        transform.RotateAround(Vector3.forward, rot);
        body.MovePosition(transform.position + direction * speed);

	}

    void bounce(Vector3 normal){
        direction = Vector2.Reflect(direction, normal);

            rotSpeed *= -1;

    }

    void lose(){

    }

    void OnCollisionEnter(Collision coll){
        string tag = coll.gameObject.tag;

        switch(tag){
            case "Paddle":
                bounce(coll.contacts[0].normal);

                break;
            case "Wall":
                bounce(coll.contacts[0].normal);
                break;
            case "Brick":
                coll.gameObject.GetComponent<Brick>().breakBrick(direction);
                bounce(coll.contacts[0].normal);
                break;

            case "LossWall":
                bounce(coll.contacts[0].normal);
                lose();

                break;


        }

    }
}
