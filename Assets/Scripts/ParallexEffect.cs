using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallexEffect : MonoBehaviour
{

    [SerializeField] private float scrollSpeed = 1f;

    [SerializeField] float parallaxMultiplier = 0.3f;

    public float[] parallaxMultipliers = new float[5];

    public bool moveBackgrounds = true;

    private GameObject parent;
    private List<GameObject> backgrounds;
    private List<Vector2> backgroundPositions;
    private Vector2[] startPositions = new Vector2[5];
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        parent = this.gameObject;
        backgrounds = GetAllChildren(parent);
        backgroundPositions = new List<Vector2>();

        for (int i = 0; i < backgrounds.Count; i++)
        {
            backgroundPositions.Add(backgrounds[i].transform.position);
            if (moveBackgrounds)
            {
                startPositions[i] = backgrounds[i].transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Time.time * scrollSpeed;
        
        foreach (GameObject background in backgrounds)
        {
            Vector2 backgroundPosition = background.transform.position;
            int index = backgrounds.IndexOf(background);
            if (index < parallaxMultipliers.Length)
            {
                float multiplier = parallaxMultipliers[index];
                backgroundPosition.x = startPositions[index].x - xMovement * multiplier;
                background.transform.position = backgroundPosition;
            }
        }
    }

    public List<GameObject> GetAllChildren(GameObject parent)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            children.Add(child.gameObject);
        }
        return children;
    }
}
