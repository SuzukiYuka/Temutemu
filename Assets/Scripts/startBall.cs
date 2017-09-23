using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBall : MonoBehaviour {
    bool startFlg;
    public GameObject clone;
    // Use this for initialization
    void Start() {
        startFlg = true;
    }

    // Update is called once per frame
    void Update() {
        if (startFlg) {
            for (int i = 0; i < 100; i++) {
                Instantiate(clone.gameObject, new Vector3(Random.Range(-2f, 2f), Random.Range(30f, 50f), 0), Quaternion.identity);
                clone.gameObject.GetComponent<countBall>().ballID = i;
            }
            startFlg = false;
        }
    }
}
