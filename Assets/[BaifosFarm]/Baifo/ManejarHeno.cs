using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejarHeno : MonoBehaviour
{
    private Jugador jugador;
    private GameObject heno;

    // Para el tutorial
    public bool alimentacionRealizada = false;

    Animator animatorHeno;
    [SerializeField] GameObject montonHeno;
    [SerializeField] GameObject montonHenoEspecial;

    [SerializeField] ParticleSystem particulasHeno;


    private void Start()
    {
        if (PlayerPrefs.GetInt("HenoMejorado", 0) == 0)
        {
            animatorHeno = montonHeno.GetComponentInChildren<Animator>();
        }
        else
        {
            animatorHeno = montonHenoEspecial.GetComponentInChildren<Animator>();
        }
        jugador = GetComponent<Jugador>();
    }

    public void CogerHeno(GameObject prefabheno, Transform mano)
    {
        // Para el tutorial
        alimentacionRealizada = false;

        jugador.HenoRecogido = true;
        heno = Instantiate(prefabheno);

        heno.transform.position = mano.position;
        heno.transform.SetParent(mano);

        fxMontonHeno();
    }

    public void DejarHeno()
    {
        Destroy(heno);
        jugador.HenoRecogido = false;

        // Para el tutorial
        alimentacionRealizada = true;
    }

    private void fxMontonHeno()
    {
        animatorHeno.SetTrigger("coger");
        particulasHeno.Play();
    }
}
