using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data instance;

    [SerializeField] public int playsContTotalRecordEasy;
    [SerializeField] public float tiempoActualTotalRecordEasy = 9999;

    [SerializeField] public int playsContTotalRecordDifficult;
    [SerializeField] public float tiempoActualTotalRecordDifficult = 9999;

    [SerializeField] public bool easyModeWasPlayed = false;
    [SerializeField] public bool difficultModeWasPlayed = false;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);

        else instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}