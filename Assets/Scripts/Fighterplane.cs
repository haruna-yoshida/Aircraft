using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighterplane : MonoBehaviour
{
    public KeyCode frontKey;
    public KeyCode backKey;
    public KeyCode rightKey;
    public KeyCode leftKey;
    

    public float movespeed = 2;//スピード:Inspectorで指定
    public float rotatespeed = 90;//回転スピード:Inspectorで指定
    float vx = 0;
    float vz = 0;
    float angle = 0;
    

    Rigidbody rplane;  

    

    // Start is called before the first frame update
    void Start()
    {
        rplane = this.GetComponent<Rigidbody>();
        rplane.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        Debug.Log(vx+"/"+vz);
    }

    // Update is called once per frame
    void Update()
    {
        angle = Input.GetAxisRaw("Horizontal") * rotatespeed * 1;
        vz = Input.GetAxisRaw("Vertical") * movespeed;
    }


    private void FixedUpdate()
    {
        // transformを取得
        Transform myTransform = this.transform;
 
        // ローカル座標を基準に、回転を取得
        Vector3 localAngle = myTransform.localEulerAngles;
        float local_angle_x = localAngle.x; // ローカル座標を基準にした、x軸を軸にした回転角度
        float local_angle_y = localAngle.y; // ローカル座標を基準にした、y軸を軸にした回転角度
        float local_angle_z = localAngle.z; // ローカル座標を基準にした、z軸を軸にした回転角度

        if (local_angle_x >180)
        {
            local_angle_x = local_angle_x - 360;
        }

        // // 速度ベクトルを表示
        // Debug.Log ("速度ベクトル: " + rplane.velocity);
        // 速度を表示
        Debug.Log ("速度: " + rplane.velocity.magnitude);
        
        
        if (angle != 0)//回転する
        {
            this.transform.Rotate(new Vector3(0, 0, angle / -100));
        }

        if (Input.GetKey(frontKey))//移動する
        {
            Rigidbody rb = this.GetComponent<Rigidbody> ();  // rigidbodyを取得
            Vector3 force = new Vector3 (0.0f, 0.0f, vz / 50);    // 力を設定
            rb.AddForce (force, ForceMode.Force);            // 力を加える
        }

        if (Input.GetKey(backKey))//移動する
        {
            Rigidbody rb = this.GetComponent<Rigidbody> ();  // rigidbodyを取得
            Vector3 force = new Vector3 (0.0f, 0.0f, vz / 5000);    // 力を設定
            rb.AddForce (force);            // 力を加える
        }
        
    
        

        if (rplane.velocity.magnitude > 150)
        {
            if ((local_angle_x > -20 && local_angle_x < 10))
            {
                this.transform.Translate(new Vector3(0, -0.0000008f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * 0.07f * local_angle_x, 0));
                
            }

            if (local_angle_x >= 10 || local_angle_x <= -20)
            {
                this.transform.Translate(new Vector3(0, -0.00000005f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * -0.08f * local_angle_x, 0));
            }
            
            
            if(Input.GetMouseButton(4))
            {
                this.transform.Rotate(new Vector3(-0.3f, angle / 100, 0));
            }

            if(Input.GetMouseButton(3))
            {
                this.transform.Rotate(new Vector3(0.3f, angle / 100, 0));
            }

            if (rplane.velocity.magnitude > 400)
            {
                // 速度を一定にする
                rplane.velocity = new Vector3(0,0,400);
            }
            
            
            
        }
            
    }
}




// 今後の方針(5/30)
    // ①gizumoを両翼に設定→RFとLFのスクリプトを作成(6/1)
    // ②それぞれ揚力をつける　
    //     揚力公式：L=1/2*p*V^2*S*CL (L:揚力〈N〉p:空気密度〈1.293〉V:流体速度=飛行速度〈m/s〉S:主翼面積〈m^2〉CL:揚力係数）
    //     揚力係数：ネットのグラフ参考、途中まで比例

    //     2-1.仰角を測定(6/1)
    //     2-2.流体速度を測定
    //     2-3.揚力係数の式
    //     2-4.公式代入

    // ※おそらくcollisionが重複してバグっているネットの記事を参考に重複しない位置をためす
    
    // ③両翼フラップのアニメーション