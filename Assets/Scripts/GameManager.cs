using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Scene currentScene;

    public List<Transform> emptyPositions;
    public List<GameObject> cards;

    [SerializeField] public GameObject cardSelected1;
    [SerializeField] public GameObject cardSelected2;
    [SerializeField] public GameObject victoryPanel;

    public int contadorJugada;
    public int playsCont;
    public int playsContTotal;

    [SerializeField] public TextMeshProUGUI tempo;
    [SerializeField] public TextMeshProUGUI nJugadas;
    [SerializeField] public TextMeshProUGUI tempoTotal;
    [SerializeField] public TextMeshProUGUI nJugadasTotal;

    [SerializeField] public int contCardsRevel;

    public float tiempoActual;
    public float tiempoActualTotal;
    public bool tiempoActivado = false;

    [SerializeField] public bool bloquearCartas;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        bloquearCartas = false;
        contCardsRevel = 0;
        List<Transform> tempPositions = new List<Transform>(emptyPositions);

        for (int i = 0; i < cards.Count; i++)
        {
            int randomIndex = Random.Range(0, tempPositions.Count);
            Transform emptyPosition = tempPositions[randomIndex];
            cards[i].transform.position = emptyPosition.position;
            tempPositions.RemoveAt(randomIndex);
        }

        CambiarTemporizador(true);

        if(currentScene.name == "JuegoEasy")
        {
            Data.instance.easyModeWasPlayed = true;
        }

        else if (currentScene.name == "JuegoDifficult")
        {
            Data.instance.difficultModeWasPlayed = true;
        }
    }

    void Update()
    {
        if (tiempoActivado)
        {
            tiempoActual += Time.deltaTime;
            tempo.text = "Tiempo: " + tiempoActual.ToString("f2");
            nJugadas.text = "Turnos: " + playsCont.ToString();
        }
    }

    public void CambiarTemporizador(bool estado)
    {
        tiempoActivado = estado;
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }

    public void FindOutWin()
    {
        if (contCardsRevel >= cards.Count / 2)
        {
            playsContTotal = playsCont;
            tiempoActualTotal = tiempoActual;
            tempoTotal.text = "Tiempo total: " + tiempoActualTotal.ToString("f2");
            nJugadasTotal.text = "Turnos totales: " + playsContTotal.ToString();
            victoryPanel.SetActive(true);

            if(tiempoActualTotal < Data.instance.tiempoActualTotalRecordEasy && currentScene.name == "JuegoEasy")
            {
                Data.instance.tiempoActualTotalRecordEasy = tiempoActualTotal;
                Data.instance.playsContTotalRecordEasy = playsContTotal;
            }

            else if (tiempoActualTotal < Data.instance.tiempoActualTotalRecordDifficult && currentScene.name == "JuegoDifficult")
            {
                Data.instance.tiempoActualTotalRecordDifficult = tiempoActualTotal;
                Data.instance.playsContTotalRecordDifficult = playsContTotal;
            }
        }
    }

    public void BlockCard()
    {
        if(cardSelected1.name == "CorazonHide" && cardSelected2.name == "CorazonHide")
        {
            cards[0].GetComponent<Card>().blockCardDone = true;
            cards[4].GetComponent<Card>().blockCardDone = true;
        }

        else if (cardSelected1.name == "PicaHide" && cardSelected2.name == "PicaHide")
        {
            cards[1].GetComponent<Card>().blockCardDone = true;
            cards[5].GetComponent<Card>().blockCardDone = true;
        }

        else if (cardSelected1.name == "DiamanteHide" && cardSelected2.name == "DiamanteHide")
        {
            cards[2].GetComponent<Card>().blockCardDone = true;
            cards[6].GetComponent<Card>().blockCardDone = true;
        }

        else if (cardSelected1.name == "TrebolHide" && cardSelected2.name == "TrebolHide")
        {
            cards[3].GetComponent<Card>().blockCardDone = true;
            cards[7].GetComponent<Card>().blockCardDone = true;
        }
    }
}