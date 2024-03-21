using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EstadisticasManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI tempoTotalRecord;
    [SerializeField] public TextMeshProUGUI nJugadasTotalRecord;

    void Start()
    {
        tempoTotalRecord.text = "Tiempo record: " + Data.instance.tiempoActualTotalRecord.ToString("f2");
        nJugadasTotalRecord.text = "Turnos record: " + Data.instance.playsContTotalRecord.ToString();
    }

    void Update()
    {
        
    }
}
