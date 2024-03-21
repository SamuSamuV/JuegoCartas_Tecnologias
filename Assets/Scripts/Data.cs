using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data instance;

    [SerializeField] public int playsContTotalRecord;
    [SerializeField] public float tiempoActualTotalRecord = 9999;

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
