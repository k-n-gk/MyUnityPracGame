using UnityEngine;
using System.Collections;

public class headattack : MonoBehaviour {
    public brockstate st;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == ("CoinBlock"))
        {
            st.Broken();
        }
    }
}
