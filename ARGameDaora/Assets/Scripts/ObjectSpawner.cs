using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;
    private GameplayManager gameManager;
    bool canPlace=true;

    private void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        gameManager = FindObjectOfType<GameplayManager>();

    }

    private void Update()
    {
        if (canPlace==true)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, Quaternion.identity);
                placementIndicator.hidePlacement();
            }
        }
        if (GameObject.FindGameObjectWithTag("Game"))
        {
            canPlace = false;
            placementIndicator.hidePlacement();
        }

    }
}
