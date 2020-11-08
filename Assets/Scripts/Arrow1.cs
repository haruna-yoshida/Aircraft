using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow1 : MonoBehaviour
{
    // 大きさをInspector上で自由に設定できるようにする
    public Vector3 scale;
    public GameObject plane;
    Rigidbody rplane;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponentInParent<Rigidbody>(); // rigidbodyを取得
        rplane = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // transformを取得
        Transform myTransform = this.transform;

        // ローカル座標を基準に、回転を取得
        Vector3 localAngle = myTransform.localEulerAngles;
        float local_angle_x = localAngle.x; // ローカル座標を基準にした、x軸を軸にした回転角度
        float local_angle_y = localAngle.y; // ローカル座標を基準にした、y軸を軸にした回転角度
        float local_angle_z = localAngle.z; // ローカル座標を基準にした、z軸を軸にした回転角度

        //角度を正に合わせる
        if (local_angle_x > 180)
        {
            local_angle_x = local_angle_x - 360;
        }
        float k = local_angle_x;


        this.transform.localScale = new Vector3(0.01f ,0.01f ,-0.000033f * (rplane.velocity.magnitude - 0.0001f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude * 30 * (0.0000000019457f * (Mathf.Pow(k, 5)) + (-0.0000000655034f) * (Mathf.Pow(k, 4)) + 0.0000012856573f * (Mathf.Pow(k, 3)) + 0.000556808666f * (Mathf.Pow(k, 2)) + (-0.00223880625f) * k + 0.000285567727f)));
    }
}
