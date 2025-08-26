using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform[] backgrounds; // Array of background transforms
    public float parallaxMultiplier = 0.5f;
    private Camera cam;
    private float lastCamX;
    private float[] backgroundsWidth;

    void Start()
    {
        cam = Camera.main;
        lastCamX = cam.transform.position.x;
        backgroundsWidth = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgroundsWidth[i] = backgrounds[i].GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    void Update()
    {

        float deltaMovement = cam.transform.position.x - lastCamX;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Parallax movement
            backgrounds[i].position = new Vector3(backgrounds[i].position.x - deltaMovement * parallaxMultiplier, backgrounds[i].position.y, backgrounds[i].position.z);
            lastCamX = cam.transform.position.x;
            // Infinite scrolling
            float leftEdge = backgrounds[i].position.x + (backgroundsWidth[i] * 2);
            if (cam.transform.position.x > leftEdge)
            {
                // Move to the rightmost position
                float rightmostX = backgrounds[GetRightmostIndex()].position.x + backgroundsWidth[GetRightmostIndex()];
                backgrounds[i].position = new Vector3(rightmostX, backgrounds[i].position.y, backgrounds[i].position.z);
            }
        }
    }

    int GetRightmostIndex()
    {
        int index = 0;
        float maxX = backgrounds[0].position.x;
        for (int i = 1; i < backgrounds.Length; i++)
        {
            if (backgrounds[i].position.x > maxX)
            {
                maxX = backgrounds[i].position.x;
                index = i;
            }
        }
        return index;
    }
}
