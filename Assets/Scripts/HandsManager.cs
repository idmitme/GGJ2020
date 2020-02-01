﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsManager : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;

    private Transform handsTransform;
    private Transform lefHandTransform;
    private Transform rightHandTransform;

    private bool leftHandLocked = false;
    private bool rightHandLocked = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        handsTransform = this.transform;
        lefHandTransform = leftHand.transform;
        rightHandTransform = rightHand.transform;

    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !leftHandLocked) {
          //  Debug.Log("Left Hand Locked");
            leftHandLocked = true;
            lefHandTransform.position = new Vector3(lefHandTransform.position.x, lefHandTransform.position.y, lefHandTransform.position.z + 1.8f);
            leftHand.transform.parent = null;
        }

        if (Input.GetMouseButtonUp(0) && leftHandLocked)
        {
           // Debug.Log("Left Hand Released");
            leftHandLocked = false;
            lefHandTransform.position = new Vector3(lefHandTransform.position.x, lefHandTransform.position.y, lefHandTransform.position.z - 1.8f);
            leftHand.transform.parent = handsTransform;
        }

        if (Input.GetMouseButton(1) && !rightHandLocked) {
            //Debug.Log("Right Hand Locked");
            rightHandLocked = true;
            rightHandTransform.position = new Vector3(rightHandTransform.position.x, rightHandTransform.position.y, rightHandTransform.position.z + 1.8f);
            rightHand.transform.parent = null;
        }

        if (Input.GetMouseButtonUp(1) && rightHandLocked)
        {
            //Debug.Log("Right Hand Released");
            rightHandLocked = false;
            rightHandTransform.position = new Vector3(rightHandTransform.position.x, rightHandTransform.position.y, rightHandTransform.position.z - 1.8f);
            rightHand.transform.parent = handsTransform;
        }

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3));
        handsTransform.position = worldPosition;
    }

}
    