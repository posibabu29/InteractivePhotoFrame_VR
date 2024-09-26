using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject PhotoFrameObj, WarningPopUP;
    public List<Texture> textures = new List<Texture>();
    public Text pathToDisplay;

    private Material material;
    private Rigidbody rb;
    private Vector3 initPosition, initRotation;
    public float floatHeight = 2f;
    public float floatForce = 1f;
    private bool floatEnabled;
    private int CurrentImage = 0;
    private void Start()
    {
        rb = PhotoFrameObj.GetComponent<Rigidbody>();
        material = PhotoFrameObj.GetComponent<Renderer>().material;
        WarningPopUP.SetActive(false);

        initPosition = PhotoFrameObj.transform.position;
        initRotation = PhotoFrameObj.transform.eulerAngles;

        LoadTextures();
    }

    private void LoadTextures()
    {
        pathToDisplay.text = "Path for images : "+Application.persistentDataPath.ToString();

        string[] files = Directory.GetFiles(Application.persistentDataPath,"*.png");

        foreach (string file in files)
            Debug.Log(Path.GetFileName(file));

        foreach (string fileName in files)
        {
            Debug.Log("Name =" + fileName);
            StartCoroutine(LoadFile(Path.Combine(Application.persistentDataPath, Path.GetFileName(fileName))));
        }

        if (files.Length == 0)
        {
            WarningPopUP.SetActive(true);
            return;
        }
    }

    private IEnumerator LoadFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath)) 
            yield break;

        if (System.IO.File.Exists(filePath))
        {            
            byte[] bytes = File.ReadAllBytes(filePath);
            Texture2D loadedTexture = new Texture2D(1024, 1024, TextureFormat.RGB24, false);
            loadedTexture.filterMode = FilterMode.Trilinear;
            loadedTexture.LoadImage(bytes);
            textures.Add(loadedTexture);            
        }
        material.SetTexture("_BaseMap", textures[0]); // Set the first texture
    }

    public void ChangeImage()
    {
        if (textures.Count == 0) return; // Avoid errors if no textures are loaded

        CurrentImage = (CurrentImage + 1) % textures.Count;
        material.SetTexture("_BaseMap", textures[CurrentImage]);
    }

    public void FloatFunction()
    {
        floatEnabled = !floatEnabled;
        rb.isKinematic = !floatEnabled; // Toggle kinematic state
        rb.useGravity = !floatEnabled; // Ensure gravity is disabled

        if (!floatEnabled)
        {
            rb.velocity = Vector3.zero;
            PhotoFrameObj.transform.position = initPosition;
            PhotoFrameObj.transform.eulerAngles = initRotation;
        }
    }

    private void FixedUpdate()
    {
        if (floatEnabled)
        {
            Vector3 force = Vector3.up * floatForce;
            rb.AddForce(force, ForceMode.Acceleration);

            // Limit the height to float
            if (PhotoFrameObj.transform.position.y < initPosition.y + floatHeight)
            {
                rb.MovePosition(rb.position + Vector3.up * floatForce * Time.fixedDeltaTime);
            }
        }
    }
}
