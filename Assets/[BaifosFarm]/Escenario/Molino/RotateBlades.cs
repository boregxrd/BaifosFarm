using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RotateBlades : MonoBehaviour
{
    public float speed = 100f; // 旋转速度，可以在Inspector中调整

    void Update()
    {
        // 每帧旋转风车叶片
        transform.Rotate(0, speed * Time.deltaTime, 0); // 调整方向和轴根据实际模型调整
    }
}

