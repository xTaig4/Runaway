using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallexEffect : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    [SerializeField] float parallaxMultiplier = 0.2f;
    private Vector3 startPosition;


    //[SerializeField] float parallaxEffectMultiplier1 = 0.4f;
    //[SerializeField] float parallaxEffectMultiplier2 = 0.6f;
    //[SerializeField] float parallaxEffectMultiplier3 = 0.8f;
    //[SerializeField] float parallaxEffectMultiplier4 = 1f;


    //List<GameObject> backgrounds;

    void Start()
    {
        startPosition = transform.position;

        //backgrounds = new List<GameObject>();
        //backgrounds.AddRange(GameObject.FindGameObjectsWithTag("Background"));
    }

    // Update is called once per frame
    void Update()
    {


        float xMovement = Time.time * scrollSpeed * parallaxMultiplier;
        //float yMovement = Time.time * scrollSpeed * parallaxMultiplier.y;

        transform.position = new Vector3(startPosition.x - xMovement, startPosition.y, startPosition.z);

    }
}
