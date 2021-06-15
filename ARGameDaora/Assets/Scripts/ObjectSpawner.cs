using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn, canvasGame,canvasJerso;
    private PlacementIndicator placementIndicator;
    private GameplayManager gameManager;
    private ARRaycastManager rayManager;
    public ARPlaneManager planeManager;
    bool canPlace=true;

    private void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        gameManager = FindObjectOfType<GameplayManager>();
        rayManager = FindObjectOfType<ARRaycastManager>();
    }

    private void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        if (canPlace==true)
        {
            if (Input.touchCount == 1)
            {
                if (rayManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
                {
                    // Raycast hits are sorted by distance, so the first one
                    // will be the closest hit.
                    var hitPose = hits[0].pose;
                    GameObject obj = Instantiate(objectToSpawn, hitPose.position, hitPose.rotation);
                    obj.AddComponent<ARAnchor>();
                    placementIndicator.hidePlacement();
                    canvasGame.SetActive(true);
                    canvasJerso.SetActive(true);

                }
            }
        }
        if (GameObject.FindGameObjectWithTag("Game"))
        {
            canPlace = false;
        }

    }
}
