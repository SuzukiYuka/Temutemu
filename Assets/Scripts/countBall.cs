using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countBall : MonoBehaviour {
    public Texture[] textures;

    public GameObject particle;
    public int ballID;
    public int countID;
    public static bool connect;
    public static int countStartID;
    public GameObject startObj;
    public static bool particleState = false;

	// Use this for initialization
	void Start () {
        startObj = GameObject.Find("BallManager");
	}
	
	// Update is called once per frame
	void Update () {
        int randomCount = Random.Range(0, 2);
        if (transform.position.y >= 10) {
            if (randomCount == 0) {
                this.tag = "yellow";
            } else if (randomCount == 1) {
                this.tag = "blue";
            }

            GetComponent<Renderer>().material.mainTexture = textures[randomCount];
            countID = randomCount;
            gameObject.transform.parent = null;
		}
	}

    private void OnMouseDown() {

        particleState = false;
        countStartID = countID;
        startObj.transform.position = new Vector3(0, 0, 0);
        gameObject.transform.parent = startObj.gameObject.transform;
        connect = true;
        particle.GetComponent<ParticleSystem>().Play();
    }
}
