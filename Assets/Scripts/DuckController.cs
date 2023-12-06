using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DuckController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float velocity = 0.0005f;
    float velocityX;
    float velocityY;

    SpriteRenderer spriteRenderer;
    Random _rand = new Random();

    // This function is called just one time by Unity the moment the component loads
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CalculateVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        float width = GetComponent<Renderer>().bounds.extents.x;
        float height = GetComponent<Renderer>().bounds.extents.y;
        float minScreenX = Camera.main.ViewportToWorldPoint (Vector2.zero).x;
        float maxScreenX = Camera.main.ViewportToWorldPoint(Vector2.one).x;
        float minScreenY = Camera.main.ViewportToWorldPoint (Vector2.zero).y;
        float maxScreenY = Camera.main.ViewportToWorldPoint(Vector2.one).y;

        Vector2 position = transform.position;

        position.x = position.x + (velocityX);
        position.y = position.y + (velocityY);

        if (position.x + width > maxScreenX || 
            position.x - width < minScreenX || 
            position.y + height > maxScreenY ||
             position.y - height < minScreenY
        )
        {
            CalculateVelocity();
        } 
        else {
            transform.position = position;
        }
    }

    void CalculateVelocity()
    {
        float velocityAngle = (float)_rand.Next(360);

        velocityX = velocity * Mathf.Cos(velocityAngle);
        velocityY = velocity * Mathf.Sin(velocityAngle);

        if (velocityX < 0) 
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
