using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopUpsFacturaTutorial : MonoBehaviour
{
    private static Font buttonFont;
    public GameObject[] popUps;

    private void Awake()
    {
        buttonFont = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
    }

    public static GameObject CreateButton(GameObject parent, string buttonName, string buttonText, Vector2 size, Color textColor, int fontSize = 35)
    {
        GameObject buttonObject = new GameObject(buttonName);
        buttonObject.transform.SetParent(parent.transform, false);

        Button button = buttonObject.AddComponent<Button>();
        RectTransform rectTransform = buttonObject.AddComponent<RectTransform>();
        rectTransform.sizeDelta = size;

        GameObject textObject = new GameObject("ButtonText");
        textObject.transform.SetParent(buttonObject.transform, false);

        Text text = textObject.AddComponent<Text>();
        text.text = buttonText;
        text.font = buttonFont;
        text.fontSize = fontSize;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = textColor;
        text.fontStyle = FontStyle.Bold;

        return buttonObject;
    }


    private IEnumerator HandlePopUp(GameObject popUp)
    {
        popUp.SetActive(true);

        GameObject okButtonObject = PopUpsFacturaTutorial.CreateButton(
            popUp, "OKButton", ">OK<", new Vector2(160, 50), new Color(22f / 255f, 237f / 255f, 72f / 255f)
        );

        Button okButton = okButtonObject.GetComponent<Button>();
        okButton.onClick.AddListener(() => Destroy(okButtonObject));

        yield return new WaitWhile(() => okButtonObject != null);

        popUp.SetActive(false);
    }

    public IEnumerator ShowPopUps()
    {
        foreach ( GameObject popUp in popUps )
        {
            yield return StartCoroutine(HandlePopUp(popUp));
        }
        PlayerPrefs.SetInt("TutorialCompleto", 1);
    }

    public void HidePopUps()
    {
        // Ocultar todos los pop-ups
        foreach (var popup in popUps)
        {
            popup.SetActive(false);
        }
    }
}

