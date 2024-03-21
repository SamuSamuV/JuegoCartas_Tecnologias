using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EstadisticasManager : MonoBehaviour
{
    public Scene currentScene;

    [SerializeField] public TextMeshProUGUI tempoTotalRecordEasy;
    [SerializeField] public TextMeshProUGUI nJugadasTotalRecordEasy;

    [SerializeField] public TextMeshProUGUI tempoTotalRecordDifficult;
    [SerializeField] public TextMeshProUGUI nJugadasTotalRecordDifficult;

    void Start()
    {
        if(Data.instance.easyModeWasPlayed)
        {
            tempoTotalRecordEasy.text = "Tiempo record: " + Data.instance.tiempoActualTotalRecordEasy.ToString("f2");
            nJugadasTotalRecordEasy.text = "Turnos record: " + Data.instance.playsContTotalRecordEasy.ToString();
        }

        else
        {
            tempoTotalRecordEasy.text = "Tiempo record: " + "N/A";
            nJugadasTotalRecordEasy.text = "Turnos record: " + "N/A";
        }

        if (Data.instance.difficultModeWasPlayed)
        {
            tempoTotalRecordDifficult.text = "Tiempo record: " + Data.instance.tiempoActualTotalRecordDifficult.ToString("f2");
            nJugadasTotalRecordDifficult.text = "Turnos record: " + Data.instance.playsContTotalRecordDifficult.ToString();
        }

        else
        {
            tempoTotalRecordDifficult.text = "Tiempo record: " + "N/A";
            nJugadasTotalRecordDifficult.text = "Turnos record: " + "N/A";

        }
    }

    void Update()
    {
        
    }
}
