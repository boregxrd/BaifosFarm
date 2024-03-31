using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GoatMilkProduction : MonoBehaviour
{
    public Slider foodSlider; // 外部导入的食物条 Barra de comida importada externamente
    public Slider milkSlider; // 奶量条   Barra de leche
    public float milkIncreaseSpeed = 0.5f; // 奶量增长速度  Velocidad de aumento de la leche
    public float milkFullThreshold = 100f; // 奶量达到100%的阈值  Umbral del 100% de la leche
    public bool isProducingMilk = false; // 山羊是否正在产奶  Indica si la cabra está produciendo leche

    void Update()
    {
        // Comprueba si el Slider de comida y el Slider de leche no son nulos
        // 检查食物条和奶量条是否为空
        if (foodSlider != null && milkSlider != null)
        {
            // Si el slider de comida es mayor que el 25%, empieza a producir leche
            // 如果食物条大于25%，开始产奶
            if (foodSlider.value > 25f)
            {
                // Incrementa el valor del slider de leche según la velocidad definida
                // 根据定义的速度增加奶量条的值
                milkSlider.value += milkIncreaseSpeed * Time.deltaTime;

                // Cuando el valor del slider de leche alcanza el 100%, establece la variable de estado como verdadera
                // 当奶量条达到100%，将状态变量设置为true
                if (milkSlider.value >= milkFullThreshold)
                {
                    isProducingMilk = true;
                }
            }
            else
            {
                // Si el slider de comida es menor que el 25%, detiene la producción de leche
                // 如果食物条不足25%，停止产奶
                milkSlider.value = 0f;
                isProducingMilk = false;
            }
        }
        else
        {
            // Advierte si los sliders no han sido asignados en el Inspector
            // 如果食物条和奶量条未在检查器中分配，发出警告
            Debug.LogWarning("Please assign foodSlider and milkSlider in the Inspector!");
        }
    }
}

