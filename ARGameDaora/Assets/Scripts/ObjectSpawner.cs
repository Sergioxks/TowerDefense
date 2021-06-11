using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn, canvasGame,canvasJerso;
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
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space))
            {
                GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, Quaternion.identity);
                placementIndicator.hidePlacement();
                canvasGame.SetActive(true);
                canvasJerso.SetActive(true);
            }
        }
        if (GameObject.FindGameObjectWithTag("Game"))
        {
            canPlace = false;
        }

    }
}
