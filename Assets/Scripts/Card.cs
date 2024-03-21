using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] public GameObject gm;
    [SerializeField] public GameObject cartaHija;
    [SerializeField] public GameObject carta2Provisional;

    [SerializeField] public bool blockCardDone = false;

    void Start()
    {
        blockCardDone = false;

        gm = GameObject.FindGameObjectWithTag("gm");
        cartaHija = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (cartaHija.activeSelf && !gm.GetComponent<GameManager>().bloquearCartas && !blockCardDone)
        {
            cartaHija.GetComponent<VoltAnim>().setAnim();

            gm.GetComponent<GameManager>().contadorJugada++;

            if (gm.GetComponent<GameManager>().contadorJugada == 1)
            {
                gm.GetComponent<GameManager>().cardSelected1 = cartaHija;
            }

            else if (gm.GetComponent<GameManager>().contadorJugada == 2)
            {
                gm.GetComponent<GameManager>().cardSelected2 = cartaHija; 

                if (gm.GetComponent<GameManager>().cardSelected1 == gm.GetComponent<GameManager>().cardSelected2)
                {
                    gm.GetComponent<GameManager>().contadorJugada--; // Restar 1 al contador de jugadas
                    gm.GetComponent<GameManager>().cardSelected2 = null;
                }

                else
                {
                    if (gm.GetComponent<GameManager>().cardSelected1.name == gm.GetComponent<GameManager>().cardSelected2.name)
                    {
                        Debug.Log("Coinciden");
                        gm.GetComponent<GameManager>().BlockCard();
                        gm.GetComponent<GameManager>().cardSelected1 = null;
                        gm.GetComponent<GameManager>().cardSelected2 = null;
                        gm.GetComponent<GameManager>().contadorJugada = 0;
                        gm.GetComponent<GameManager>().playsCont++;
                        gm.GetComponent<GameManager>().contCardsRevel++;

                        if (gm.GetComponent<GameManager>().contCardsRevel >= gm.GetComponent<GameManager>().cards.Count / 2)
                        {
                            gm.GetComponent<GameManager>().DesactivarTemporizador();
                            StartCoroutine(WaitForWin());
                        }

                        
                    }

                    else
                    {
                        Debug.Log("No coinciden");
                        StartCoroutine(ShowFirstCardAgain());

                        gm.GetComponent<GameManager>().playsCont++;
                    }
                }
            }
        }
    }

    IEnumerator ShowFirstCardAgain()
    {
        gm.GetComponent<GameManager>().bloquearCartas = true;
        yield return new WaitForSeconds(1f); // Espera 1 segundo antes de volver a mostrar la primera carta

        cartaHija.GetComponent<VoltAnim>().backAnim(); // Oculta la primera carta seleccionada
        gm.GetComponent<GameManager>().cardSelected1.GetComponent<VoltAnim>().backAnim();

        gm.GetComponent<GameManager>().cardSelected1 = null;
        gm.GetComponent<GameManager>().cardSelected2 = null;
        gm.GetComponent<GameManager>().contadorJugada = 0;

        gm.GetComponent<GameManager>().bloquearCartas = false;
    }

    IEnumerator WaitForWin() //Para evitar que nada mas clickar en la última carta salte el VictoryPanel
    {
        yield return new WaitForSeconds(3f);

        gm.GetComponent<GameManager>().FindOutWin();
    }
}