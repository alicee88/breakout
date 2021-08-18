using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float screenHeight;
    float screenWidth;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Camera.main.orthographicSize * 2.0f;
        screenWidth = screenHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {

        // Get mouse position relative to screen size and aspect ratio
        float mousePosX = (Input.mousePosition.x / Screen.width) * screenWidth;
        transform.position = new Vector2(mousePosX, transform.position.y);

    }
}
