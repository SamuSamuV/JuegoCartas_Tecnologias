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
    public List<GameObject> cartasPrefab; // Asigna el prefab de la carta desde el Inspector

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
        List<GameObject> prefabsDuplicados = new List<GameObject>();
        foreach (var prefab in cartasPrefab)
        {
            prefabsDuplicados.Add(prefab);
            prefabsDuplicados.Add(prefab); // Duplicar el prefab
        }

        // Instanciar y posicionar las cartas
        List<Transform> tempPositions = new List<Transform>(emptyPositions);
        for (int i = 0; i < emptyPositions.Count; i++)
        {
            int randomIndex = Random.Range(0, tempPositions.Count);
            Transform emptyPosition = tempPositions[randomIndex];

            int randomPrefabIndex = Random.Range(0, prefabsDuplicados.Count);
            GameObject nuevaCarta = Instantiate(prefabsDuplicados[randomPrefabIndex], emptyPosition.position, Quaternion.identity);

            // Añadir la carta instanciada a la lista de cartas
            cards.Add(nuevaCarta);

            tempPositions.RemoveAt(randomIndex);
            prefabsDuplicados.RemoveAt(randomPrefabIndex);
        }

        CambiarTemporizador(true);

        if (currentScene.name == "JuegoEasy")
        {
            Data.instance.easyModeWasPlayed = true;
        }

        else if (currentScene.name == "JuegoDifficult")
        {
            Data.instance.difficultModeWasPlayed = true;
        }

        if (currentScene.name == "JuegoEasy")
        {
            cards.Sort((card1, card2) =>
            {
                // Extraer los nombres de las cartas para determinar su tipo
                string nombreCarta1 = card1.name;
                string nombreCarta2 = card2.name;

                // Definir el orden deseado para luego poder bloquear las cartas correctamente
                if (nombreCarta1.Contains("Corazon") && nombreCarta2.Contains("Corazon"))
                    return 0;
                else if (nombreCarta1.Contains("Corazon"))
                    return -1;
                else if (nombreCarta2.Contains("Corazon"))
                    return 1;
                else if (nombreCarta1.Contains("Pica") && nombreCarta2.Contains("Pica"))
                    return 0;
                else if (nombreCarta1.Contains("Pica"))
                    return -1;
                else if (nombreCarta2.Contains("Pica"))
                    return 1;
                else if (nombreCarta1.Contains("Diamante") && nombreCarta2.Contains("Diamante"))
                    return 0;
                else if (nombreCarta1.Contains("Diamante"))
                    return -1;
                else if (nombreCarta2.Contains("Diamante"))
                    return 1;
                else if (nombreCarta1.Contains("Trebol") && nombreCarta2.Contains("Trebol"))
                    return 0;
                else if (nombreCarta1.Contains("Trebol"))
                    return -1;
                else if (nombreCarta2.Contains("Trebol"))
                    return 1;
                else
                    return 0; // En caso de que los nombres no coincidan con ninguno de los criterios anteriores
            });
        }

        else if (currentScene.name == "JuegoDifficult")
        {
            cards.Sort((card1, card2) =>
            {
                // Extraer los nombres de las cartas para determinar su tipo
                string nombreCarta1 = card1.name;
                string nombreCarta2 = card2.name;

                // Definir el orden deseado
                if (nombreCarta1.Contains("CorazonNegro") && nombreCarta2.Contains("CorazonNegro"))
                    return 0;
                else if (nombreCarta1.Contains("CorazonNegro"))
                    return -1;
                else if (nombreCarta2.Contains("CorazonNegro"))
                    return 1;
                else if (nombreCarta1.Contains("TrebolRojo") && nombreCarta2.Contains("TrebolRojo"))
                    return 0;
                else if (nombreCarta1.Contains("TrebolRojo"))
                    return -1;
                else if (nombreCarta2.Contains("TrebolRojo"))
                    return 1;
                else if (nombreCarta1.Contains("PicaRoja") && nombreCarta2.Contains("PicaRoja"))
                    return 0;
                else if (nombreCarta1.Contains("PicaRoja"))
                    return -1;
                else if (nombreCarta2.Contains("PicaRoja"))
                    return 1;
                else if (nombreCarta1.Contains("DiamanteNegro") && nombreCarta2.Contains("DiamanteNegro"))
                    return 0;
                else if (nombreCarta1.Contains("DiamanteNegro"))
                    return -1;
                else if (nombreCarta2.Contains("DiamanteNegro"))
                    return 1;
                else if (nombreCarta1.Contains("Corazon") && nombreCarta2.Contains("Corazon"))
                    return 0;
                else if (nombreCarta1.Contains("Corazon"))
                    return -1;
                else if (nombreCarta2.Contains("Corazon"))
                    return 1;
                else if (nombreCarta1.Contains("Pica") && nombreCarta2.Contains("Pica"))
                    return 0;
                else if (nombreCarta1.Contains("Pica"))
                    return -1;
                else if (nombreCarta2.Contains("Pica"))
                    return 1;
                else if (nombreCarta1.Contains("Diamante") && nombreCarta2.Contains("Diamante"))
                    return 0;
                else if (nombreCarta1.Contains("Diamante"))
                    return -1;
                else if (nombreCarta2.Contains("Diamante"))
                    return 1;
                else if (nombreCarta1.Contains("Trebol") && nombreCarta2.Contains("Trebol"))
                    return 0;
                else if (nombreCarta1.Contains("Trebol"))
                    return -1;
                else if (nombreCarta2.Contains("Trebol"))
                    return 1;
                else
                    return 0; // En caso de que los nombres no coincidan con ninguno de los criterios anteriores
            });

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

            if (tiempoActualTotal < Data.instance.tiempoActualTotalRecordEasy && currentScene.name == "JuegoEasy")
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
        if (currentScene.name == "JuegoEasy")
        {
            if (cardSelected1.name == "CorazonHide" && cardSelected2.name == "CorazonHide")
            {
                cards[0].GetComponent<Card>().blockCardDone = true;
                cards[1].GetComponent<Card>().blockCardDone = true;
            }

            else if (cardSelected1.name == "PicaHide" && cardSelected2.name == "PicaHide")
            {
                cards[2].GetComponent<Card>().blockCardDone = true;
                cards[3].GetComponent<Card>().blockCardDone = true;
            }

            else if (cardSelected1.name == "DiamanteHide" && cardSelected2.name == "DiamanteHide")
            {
                cards[4].GetComponent<Card>().blockCardDone = true;
                cards[5].GetComponent<Card>().blockCardDone = true;
            }

            else if (cardSelected1.name == "TrebolHide" && cardSelected2.name == "TrebolHide")
            {
                cards[6].GetComponent<Card>().blockCardDone = true;
                cards[7].GetComponent<Card>().blockCardDone = true;
            }
        }

        else if (currentScene.name == "JuegoDifficult")
        {
            if (cardSelected1.name == "CorazonNegroHide" && cardSelected2.name == "CorazonNegroHide")
            {
                cards[0].GetComponent<Card>().blockCardDone = true;
                cards[1].GetComponent<Card>().blockCardDone = true;
            }

            else if (cardSelected1.name == "TrebolRojoHide" && cardSelected2.name == "TrebolRojoHide")
            {
                cards[2].GetComponent<Card>().blockCardDone = true;
                cards[3].GetComponent<Card>().blockCardDone = true;
            }

            else if (cardSelected1.name == "PicaRojaHide" && cardSelected2.name == "PicaRojaHide")
            {
                cards[4].GetComponent<Card>().blockCardDone = true;
                cards[5].GetComponent<Card>().blockCardDone = true;
            }

            else if (cardSelected1.name == "DiamanteNegroHide" && cardSelected2.name == "DiamanteNegroHide")
            {
                cards[6].GetComponent<Card>().blockCardDone = true;
                cards[7].GetComponent<Card>().blockCardDone = true;
            }

            else if (cardSelected1.name == "CorazonHide" && cardSelected2.name == "CorazonHide")
            {
                cards[8].GetComponent<Card>().blockCardDone = true;
                cards[9].GetComponent<Card>().blockCardDone = true;
            }

            else if (cardSelected1.name == "PicaHide" && cardSelected2.name == "PicaHide")
            {
                cards[10].GetComponent<Card>().blockCardDone = true;
                cards[11].GetComponent<Card>().blockCardDone = true;
            }

            else if (cardSelected1.name == "DiamanteHide" && cardSelected2.name == "DiamanteHide")
            {
                cards[12].GetComponent<Card>().blockCardDone = true;
                cards[13].GetComponent<Card>().blockCardDone = true;
            }

            else if (cardSelected1.name == "TrebolHide" && cardSelected2.name == "TrebolHide")
            {
                cards[14].GetComponent<Card>().blockCardDone = true;
                cards[15].GetComponent<Card>().blockCardDone = true;
            }
        }
    }
}