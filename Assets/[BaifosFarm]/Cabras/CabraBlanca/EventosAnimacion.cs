using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosAnimacion : MonoBehaviour
{
    public void GritoMuerte()
    {
        MuerteCabraBlanca script = GetComponentInParent<MuerteCabraBlanca>();
        if (script != null)
        {
            script.PlayGrito();
        }
        else
        {
            Debug.LogError("script null");
        }
    }

    public void Explosion()
    {
        MuerteCabraBlanca script = GetComponentInParent<MuerteCabraBlanca>();
        if (script != null)
        {
            script.PlayExplosion();
        }
        else
        {
            Debug.LogError("script null");
        }
    }
}
