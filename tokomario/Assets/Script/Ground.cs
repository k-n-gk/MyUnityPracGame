using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
    public int Action;
    // Use this for initialization
    void Start () {
        Action = 2;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == ("Player"))
            Action = 2;
            
    }
}
