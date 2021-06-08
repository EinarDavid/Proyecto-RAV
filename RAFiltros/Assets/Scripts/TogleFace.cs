using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using System;
using UnityEngine.EventSystems;

public class TogleFace : MonoBehaviour
{
    public ARFaceManager arFaceManager;

    public GameObject[] faces;

    public Button[] botones;

    private float timer;

    [SerializeField]
    private float frequency = 1.0f;

    [SerializeField]
    private float maxUntilSpawn = 1.0f;

    private int index = -1;

    void Start()
    {
        arFaceManager = gameObject.AddComponent<ARFaceManager>();   
        //arFaceManager.facePrefab = faces[index];
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].onClick.AddListener(CambiarCara);
        }
    }
    void Update()
    {

    }
    void CambiarCara()
    {
        index++;
        if(index>=botones.Length)
        {
            index=0;
        }
        //index = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name);
        //arFaceManager.facePrefab = new GameObject();
        arFaceManager.facePrefab = faces[index];
        Debug.Log(index);
    }
}