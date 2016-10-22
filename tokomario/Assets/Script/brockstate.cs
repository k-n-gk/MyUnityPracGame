using UnityEngine;
using System.Collections;

public class brockstate : MonoBehaviour {
    SpriteRenderer Sp;
    public Sprite broken;
	// Use this for initialization
	void Start () {
        Sp = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Broken()
    {
        Sp.sprite = broken;
    }
}
