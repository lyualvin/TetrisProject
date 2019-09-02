using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    private Camera mainCamera;
    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = Camera.main;
    }
    //放大
    public void ZoomIn()
    {
        mainCamera.DOOrthoSize(13.5f, 0.5f);
    }
    //缩小
    public void ZoomOut()
    {
        mainCamera.DOOrthoSize(21f, 0.5f);
    }
 
}
