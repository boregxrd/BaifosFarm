using UnityEngine;

public class FijarBarras : MonoBehaviour
{
    [SerializeField] RectTransform imageTransform;

    void Update()
    {
        if (imageTransform != null && Camera.main != null)
        {
           Quaternion cameraRotation = Camera.main.transform.rotation;
           imageTransform.rotation = Quaternion.Euler(new Vector3(cameraRotation.eulerAngles.x, cameraRotation.eulerAngles.y, 0f));
        }
        else
        {
            Debug.LogWarning("No se encontró la referencia al Image o a la cámara principal.");
        }
    }
}

