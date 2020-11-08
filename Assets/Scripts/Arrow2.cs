﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow2 : MonoBehaviour
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
        Transform myTransform = plane.transform;

        // ローカル座標を基準に、回転を取得
        Vector3 localAngle = myTransform.localEulerAngles;
        float local_angle_x = localAngle.x; // ローカル座標を基準にした、x軸を軸にした回転角度
        float local_angle_y = localAngle.y; // ローカル座標を基準にした、y軸を軸にした回転角度
        float local_angle_z = localAngle.z; // ローカル座標を基準にした、z軸を軸にした回転角度
        
        //角度のsinとcosを取得
        float sin = Mathf.Sin(local_angle_z);
        float cos = Mathf.Cos(local_angle_z);
        float tan = Mathf.Tan(local_angle_z);

        //角度を正に合わせる
        if (local_angle_x > 180)
        {
            local_angle_x = local_angle_x - 360;
        }
        float k = local_angle_x;

        if ((local_angle_x > -14 && local_angle_x < 20)) //迎角が−14~20
        {
            this.transform.localScale = new Vector3(0.01f ,0.01f ,sin * 0.1f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude * 30 * (0.09f * local_angle_x + 0.35f));
        }

        if (local_angle_x >= 20) //迎角が20以上
        {
            this.transform.localScale = new Vector3(0.01f ,0.01f ,sin * 0.1f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude * 30 * (-0.08f * local_angle_x + 0.1f));
        }

        if (local_angle_x <= -10) //迎角が-10以下
        {
            this.transform.localScale = new Vector3(0.01f ,0.01f ,sin * 0.1f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude * 30 * (-0.08f * local_angle_x - 1.7f));
        }
    }
}
