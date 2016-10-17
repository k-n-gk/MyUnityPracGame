using UnityEngine;
using System.Collections;

public class EnemyScript : Token {

	// Use this for initialization
	void Start () {
        SetSize(SpriteWidth / 2, SpriteHeight / 2);

        float dir = Random.Range(0, 359);

        float spd = 2;

        SetVelocity(dir, spd);
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 min = GetWorldMin();

        Vector2 max = GetWorldMax();

        if(X < min.x || max.x < X)
        {
            VX *= -1;
            ClampScreen();
        }
        if (Y < min.y || max.y < Y)
        {
            VY *= -1;
            ClampScreen();
        }
        
    }
    public void OnMouseDown()
    {
        DestroyObj();
    }
}
