using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerState : MonoBehaviour {
    int CoinCount;

    public Text Cointext;
	// Use this for initialization
	void Start () {
        CoinCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Cointext.text = string.Format("x{0:00}", CoinCount);
	}
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == ("Coin"))
            CoinCount++;
    }
}
