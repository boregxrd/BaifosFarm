using UnityEngine;
using UnityEngine.UI;

public class IconPositionController : MonoBehaviour
{
    public BarraLeche barraLeche;
    public BarraAlimento barraAlimento;

    public Image iconoLeche; // Icon for milk bar
    public Image iconoAlimento; // Icon for food bar

    void Update()
    {
        if (barraLeche != null && iconoLeche != null)
            UpdateIconPosition(iconoLeche, barraLeche.ValorActual, barraLeche.ValorMaximo);

        if (barraAlimento != null && iconoAlimento != null)
            UpdateIconPosition(iconoAlimento, barraAlimento.ValorActual, barraAlimento.ValorMaximo);
    }

    private void UpdateIconPosition(Image icon, float valorActual, float valorMaximo)
    {
        float fillRatio = valorActual / valorMaximo;
        float iconPosX = -37.5f + (fillRatio * 75f); // Assuming a linear mapping from min to max position
        icon.rectTransform.anchoredPosition = new Vector2(iconPosX, icon.rectTransform.anchoredPosition.y);
    }
}
