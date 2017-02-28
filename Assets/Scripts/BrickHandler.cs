using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHandler : MonoBehaviour {

    public GameObject brick;

    public int rows;
    public int cols;

    public Vector3 offset;
    public Vector3 globalOffset;

    public Color[] colors;

    public Material mat;

	// Use this for initialization
	void Start () {
        Vector3 scale = brick.transform.localScale;

        for(int y = 0; y < rows; y++){
            for(int x = 0;x < cols; x++){
                Vector3 pos = new Vector3(x * scale.x + offset.x * x, y * scale.y + offset.y * y,0);
                GameObject g = Instantiate(brick, globalOffset + pos, Quaternion.identity) as GameObject;

                mat.color = colors[Random.Range(0,colors.Length)];
                g.GetComponent<MeshRenderer>().material = new Material(mat);

                g.transform.SetParent(transform, true);


            }


        }
		
	}
	
}
