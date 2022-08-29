using System;
using System.Collections;
using System.Collections.Generic;
using GameObjects;
using UnityEngine;

public class PlatformPlacer : MonoBehaviour
{
    [SerializeField] private Platform platform;
    
    private Camera _mainCamera;
    private readonly Vector3 _offset = new Vector3(0, 0, 10);

    public void Start()
    {
        _mainCamera = Camera.main;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(
                platform,
                _mainCamera.ScreenToWorldPoint(Input.mousePosition) + _offset,
                Quaternion.Euler(0, 0, 0)
                );
        }
    }
}
