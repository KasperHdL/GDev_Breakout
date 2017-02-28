using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public GameObject prefab;
    public int piecesX;
    public int piecesY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void breakBrick(Vector3 direction){

        Vector2 scale = new Vector2(transform.localScale.x / piecesX, transform.localScale.y / piecesY);
        for(int y = 0; y < piecesY; y ++){
            for(int x = 0; x < piecesX; x ++){
                Vector3 pos = new Vector3(x *  scale.x - scale.x/2, y* scale.y - scale.y/2, 0);
                GameObject g = Instantiate(prefab, transform.position + pos, Quaternion.identity) as GameObject;
                g.GetComponent<BrickPiece>().direction = direction;
                g.GetComponent<BrickPiece>().color = GetComponent<MeshRenderer>().material.color;

            }

        }
        Destroy(gameObject);


    }
}
