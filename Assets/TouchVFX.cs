using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TouchVFX : MonoBehaviour
{
    public GameObject imagePrefab;
    private Camera _camera;
    [SerializeField] Canvas canvas;
    private bool _isSearchingForCamera = true;

    private IEnumerator Start()
    {
        Debug.Log("Searching for camera");
        while (_isSearchingForCamera)
        {
            _camera = FindObjectsOfType<Camera>().FirstOrDefault(cam => cam.gameObject.name == "UICamera");
            if (_camera != null)
            {
                _isSearchingForCamera = false;
                SetCanvas();
            }
            Debug.Log("Camera ...");
            yield return null;
        }
        Debug.Log("Camera found");
    }

    private void SetCanvas()
    {
        canvas.worldCamera = _camera;
        canvas.planeDistance = 101;
        canvas.sortingOrder = 1000;
    }

    private void Update()   
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = _camera.ScreenToWorldPoint(touch.position);
                touchPosition.z = -1;
                GameObject spawnedImage = Instantiate(imagePrefab, touchPosition, Quaternion.identity);
                spawnedImage.transform.SetParent(canvas.transform, true);
                spawnedImage.GetComponent<ParticleSystem>();
                
                Destroy(spawnedImage,1);
            }
        }
    }
}