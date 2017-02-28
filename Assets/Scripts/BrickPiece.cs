using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPiece : MonoBehaviour {

    public float randomVector;
    public Color color;

    public Vector3 direction;
    public float speed;

    private float start;
    private float end;
    public float deathTime;
    public float randomness;

    public float fadeoutTime;
    MeshRenderer rend;
    Material mat;
	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
        mat = new Material(rend.material);
        mat.color = color;
        rend.material = mat;;
        start = Time.time;
        end = start + deathTime + randomness * Random.value;

        direction += Random.onUnitSphere * randomVector;
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += direction * speed;

        if(end < Time.time){
            StartCoroutine(fadeout(fadeoutTime));

        }
		
	}
    IEnumerator fadeout(float length){
        float start = Time.time;
        float end = start + length;

        float t = 0;
        while(end < Time.time){
            t = (Time.time - start) / length;

            Color c = mat.color;
            c.a = Mathf.Lerp(1f,0f,t);
            mat.color = c;
            rend.material = mat;

            yield return null;

        }
        Destroy(gameObject);

    }
}
