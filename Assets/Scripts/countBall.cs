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

    //いらない 
    //public static bool particleState = false;

    // Use this for initialization
    void Start() {
        startObj = GameObject.Find("BallManager");
    }

    // Update is called once per frame
    void Update() {
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
            particle.GetComponent<ParticleSystem>().Stop();
        }

        if (transform.position.x >= 4) {
            transform.position = new Vector3(0.5f, 10f, 0);
        }
        if (transform.position.x <= 4) {
            transform.position = new Vector3(0.5f, 10f, 0);
        }
    }

    private void OnMouseDown() {

        countStartID = countID;
        startObj.transform.position = new Vector3(0, 0, 0);
        gameObject.transform.parent = startObj.gameObject.transform;
        connect = true;
        particle.GetComponent<ParticleSystem>().Play();
    }

    private void OnMouseOver() {
        if (connect && countStartID == countID) {
            gameObject.transform.parent = startObj.gameObject.transform; //親を最初にクリックしたつむにする 
            particle.GetComponent<ParticleSystem>().Play();
        } else if (countStartID != countID) {
            connect = false;
        }
    }

    private void OnMouseUp() {
        connect = false;
        if (startObj.gameObject.transform.childCount > 3) {
            startObj.transform.position = new Vector3(0, 20f, 0);
        } else {
            startObj.gameObject.transform.DetachChildren();
            particle.GetComponent<ParticleSystem>().Stop();
        }
    }
}
