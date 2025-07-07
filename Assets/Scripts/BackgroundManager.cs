using UnityEngine;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{
    List<GameObject> backgrounds;
    private float backgroundWidth = 0f;
    [SerializeField] private float passMargin = 2f; // How far past the camera before moving

    void Start()
    {
        backgrounds = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                backgrounds.Add(child.gameObject);
            }
        }

        // Assume all backgrounds are the same width
        if (backgrounds.Count > 0)
        {
            SpriteRenderer sr = backgrounds[0].GetComponent<SpriteRenderer>();
            if (sr != null)
                backgroundWidth = sr.bounds.size.x;
        }
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Count; i++)
        {
            GameObject bg = backgrounds[i];
            Vector3 position = bg.transform.position;
            float leftEdge = position.x + (backgroundWidth / 2);

            float cameraLeft = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;

            // Only move if the right edge of the background is past the left edge of the camera by passMargin
            if (leftEdge < cameraLeft - passMargin)
            {
                // Find the rightmost background
                float maxX = float.MinValue;
                foreach (GameObject other in backgrounds)
                {
                    if (other == bg) continue;
                    float otherRight = other.transform.position.x + (backgroundWidth / 2);
                    if (otherRight > maxX)
                        maxX = otherRight;
                }

                // Move this background to the right of the rightmost background
                bg.transform.position = new Vector3(maxX, position.y, position.z);
            }
        }
    }
}
