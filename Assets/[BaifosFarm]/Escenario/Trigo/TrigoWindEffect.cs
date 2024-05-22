using System.Collections;
using UnityEngine;

public class TrigoWindEffect : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Introduce un retardo aleatorio entre 0 y 1 segundo
        float delay = Random.Range(0f, 1f);
        StartCoroutine(StartAnimationWithDelay(delay));
    }

    private IEnumerator StartAnimationWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.Play("TrigoWind", -1, 0f);
    }
}
