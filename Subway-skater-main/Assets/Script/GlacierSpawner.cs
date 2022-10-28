using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlacierSpawner : MonoBehaviour
{

    private const float Distance_Despawn = 10.0f;
    public float scrollSpeed = -2;

    public float totalLength;
    public bool IsScrolling { get; set; }

    private float scrolllocation;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        IsScrolling = true;
    }

    private void Update()
    {
        if (!IsScrolling)
            return;
        scrolllocation += scrollSpeed * Time.deltaTime;

        Vector3 newLocation = (playerTransform.position.z + scrolllocation) * Vector3.forward;
        transform.position = newLocation;

        if(transform.GetChild(0).transform.position.z < playerTransform.position.z-Distance_Despawn)
        {
            transform.GetChild(0).localPosition += Vector3.forward * totalLength;
            transform.GetChild(0).SetSiblingIndex(transform.childCount);
            transform.GetChild(0).localPosition += Vector3.forward * totalLength;
            transform.GetChild(0).SetSiblingIndex(transform.childCount);
        }
    }
}
