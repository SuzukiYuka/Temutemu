using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    public Text Score;
    private int score = 0;

    public Text Combo;
    private float timer = 0f;
    public float comboTimer = 5f;
    public int comboCnt = 0;

    // Use this for initialization
    void Start() {
        Score.text = "Score\t: " + score.ToString();
        Combo.text = "Combo\t: " + comboCnt.ToString();
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;

        if (timer > comboTimer) {
            timer = 0;
            comboCnt = 0;
            Combo.text = "Combo\t: " + comboCnt.ToString();
        }
    }
}
