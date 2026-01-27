using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transicion : MonoBehaviour
{
    [SerializeField] GameObject panel;
    Animator animator;

    void Awake()
    {
        animator = panel.GetComponent<Animator>();
    }

    public void FadeOut() {
        panel.SetActive(true);
        animator.SetTrigger("fadeOut");
    }

    public void FadeIn() {
        panel.SetActive(true);
        animator.SetTrigger("fadeIn");
    }

    public void DesactivarPanel() {
        panel.SetActive(false);
    }
}
