using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Awake() {
        StartCoroutine(DestruccionAutomatica());
    }

    private IEnumerator DestruccionAutomatica() {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
