using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using System;
using UnityEngine.EventSystems;
[RequireComponent(typeof(ARFaceManager))]

public class FaceController : MonoBehaviour
{
    [SerializeField]
    private Button faceTrackingToggle;

    [SerializeField]
    private Button btnAdelante; 

    [SerializeField]
    private Button btnAtras;

    private ARFaceManager arFaceManager;
    
    private bool faceTrackingOn = true;

    private int swapCounter = 0;

    [SerializeField]
    public FaceMaterial[] materials;

    void Awake() 
    {
        swapCounter = materials.Length - 1;
        arFaceManager = GetComponent<ARFaceManager>();
        
        faceTrackingToggle.onClick.AddListener(ToggleTrackingFaces);
        btnAdelante.onClick.AddListener(Adelante);
        btnAtras.onClick.AddListener(Atras);

        arFaceManager.facePrefab.GetComponent<MeshRenderer>().material = materials[0].Material;
    }


    void Adelante()  
    { 
        swapCounter = swapCounter == materials.Length - 1 ? 0 : swapCounter + 1;
        
        foreach(ARFace face in arFaceManager.trackables)
        {
            face.GetComponent<MeshRenderer>().material = materials[swapCounter].Material;
        }

        btnAdelante.GetComponentInChildren<Text>().text = $"({materials[swapCounter].Name})";
    }
        void Atras() 
    { 
        swapCounter = swapCounter < 0 ? materials.Length - 1 : swapCounter - 1;
        
        foreach(ARFace face in arFaceManager.trackables)
        {
            face.GetComponent<MeshRenderer>().material = materials[swapCounter].Material;
        }

        btnAtras.GetComponentInChildren<Text>().text = $"({materials[swapCounter].Name})";
        //btnAtras.GetComponentInChildren<Text>().text = $"Face Material ({materials[swapCounter].Name})";
    }

    void ToggleTrackingFaces() 
    { 
        faceTrackingOn = !faceTrackingOn;

        foreach(ARFace face in arFaceManager.trackables)
        {
            face.enabled = faceTrackingOn;
        }
        
        faceTrackingToggle.GetComponentInChildren<Text>().text = $"Face Tracking {(arFaceManager.enabled ? "Off" : "On" )}";
    }

}

[System.Serializable]
public class FaceMaterial
{
    public Material Material;

    public string Name;
}