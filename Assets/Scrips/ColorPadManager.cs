using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ColorPadManager : MonoBehaviour
{
    public static ColorPadManager instance;
    [SerializeField]
    int totalCorrectPlacementsNeed; 
    [SerializeField]
    int currentCorrectPlacements; 
    [SerializeField]
    int placements = 0; 

    public List<GameObject> pads;
    public List<GameObject> boxes;
    public List<Color> possibleColors;


    public Text canvasText;

    public UnityEvent completeEvent; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    
    void Start()
    {
        totalCorrectPlacementsNeed = pads.Count; 
        currentCorrectPlacements = 0; 

        RandomizeColourList(); 
        AssignColoursToListObjects(pads); 
        RandomizeColourList(); 
        AssignColoursToListObjects(boxes); 
        ShuffleBoxOrder(); 
    }

    
    void Update()
    {

    }

    
    void RandomizeColourList()
    {
        List<Color> tempList = new List<Color>();

        for (int i = 0; i < possibleColors.Count; i++)
        {
            tempList.Add(possibleColors[i]);
        }


        for (int i = 0; i < possibleColors.Count; i++)
        {
            Color tempColor = possibleColors[i];
            int randomIndex = UnityEngine.Random.Range(i, possibleColors.Count);
            possibleColors[i] = possibleColors[randomIndex];
            possibleColors[randomIndex] = tempColor;
        }
    }

    
    /// <param name="objects"></param>
    void AssignColoursToListObjects(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].GetComponent<Renderer>().material.color = possibleColors[i];
        }
    }

    public void IncreasePlacement()
    {
        placements++;

        if (placements == totalCorrectPlacementsNeed) 
        {
            canvasText.text = currentCorrectPlacements.ToString();
        }
    }

    
    public void DecreasePlacement()
    {
        placements--;
    }

   
    public void IncreaseCorrectPlacements()
    {
        currentCorrectPlacements++;

        if (currentCorrectPlacements == totalCorrectPlacementsNeed)
        {
            Debug.Log("ALL BOXES PLACED CORRECTLY");
            completeEvent.Invoke();
        }
    }

    
    public void DecreaseCorrectPlacements()
    {
        currentCorrectPlacements--;
    }

    
    void ShuffleBoxOrder()
    {
        int number = 0;
        for (int i = 0; i < boxes.Count; i++)
        {

            GameObject temp = boxes[i];
            int randomIndex = UnityEngine.Random.Range(i, boxes.Count);
            boxes[i] = boxes[randomIndex];
            boxes[randomIndex] = temp;

            boxes[i].GetComponent<Pickupable>().boxId = number;
            pads[i].GetComponent<Pad>().padId = number;
            number++;

        }
    }

}