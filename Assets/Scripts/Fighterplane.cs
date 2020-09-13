using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighterplane : MonoBehaviour
{
    public KeyCode frontKey;
    public KeyCode backKey;
    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public GameObject ElevatorLeft;
    public GameObject ElevatorRight;
    public GameObject Fuselage;
    public GameObject LeftBackWing;
    public GameObject RightBackWing;
    public GameObject LeftBaseWing;
    public GameObject RightBaseWing;
    public GameObject LeftRudder;
    public GameObject RightRudder;
    public GameObject LeftWing;
    public GameObject RightWing;
    public GameObject LeftFlap;
    public GameObject RightFlap;
    
    [SerializeField] private GameObject parentObject;

    public float movespeed = 2;//スピード:Inspectorで指定
    public float rotatespeed = 90;//回転スピード:Inspectorで指定
    private bool isGrounded = true;
    float vx = 0;
    float vz = 0;
    float angle = 0;
    

    Rigidbody rplane;  

    

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = this.GetComponent<Rigidbody> ();  // rigidbodyを取得
        rplane = this.GetComponent<Rigidbody>();
        rplane.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        Debug.Log(vx+"/"+vz);
        var childTransform = GameObject.Find("RootObject").GetComponentsInChildren<Transform>();

        // foreach (Transform childTransform in this.gameObject.transform)
        // {
        //     Debug.Log(childTransform.gameObject.name); // 子オブジェクト名を出力
        //     foreach (Transform grandChildTransform in childTransform)
        //     {
        //         Debug.Log(grandChildTransform.gameObject.name); // 孫オブジェクト名を出力
        //     }
        // }
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

        float k = local_angle_x;

        // // 速度ベクトルを表示
        // Debug.Log ("速度ベクトル: " + rplane.velocity);
        // 速度を表示
        // Debug.Log (0.01f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (0.0000000019457f * (Mathf.Pow(k,5)) + (-0.0000000655034f) * (Mathf.Pow(k,4)) + 0.0000012856573f * (Mathf.Pow(k,3)) + 0.000556808666f * (Mathf.Pow(k,2)) + (-0.00223880625f) * k + 0.000285567727f));
        //  Debug.Log(k);

        if (angle != 0)//回転する
        {
            this.transform.Rotate(new Vector3(0, 0, angle / -100));
        }

        if (Input.GetKey(frontKey))//移動する
        {
            if (rplane.velocity.magnitude < 400)
            {
                
                Vector3 force = new Vector3 (0.0f, 0.0f, vz / -50);    // 力を設定
                rplane.AddForce (force, ForceMode.Force);            // 力を加える
            }
        }

        if (Input.GetKey(backKey))//移動する
        {
            
            Vector3 force = new Vector3 (0.0f, 0.0f, vz / -150);    // 力を設定
            rplane.AddForce (force);            // 力を加える
        }
        
        // rplane.AddForce(new Vector3(0, 0 , 0.0001f* 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (0.0000000019457f * (Mathf.Pow(k,5)) + (-0.0000000655034f) * (Mathf.Pow(k,4)) + 0.0000012856573f * (Mathf.Pow(k,3)) + 0.000556808666f * (Mathf.Pow(k,2)) + (-0.00223880625f) * k + 0.000285567727f)));

        

        if (rplane.velocity.magnitude > 150)
        {
            if ((local_angle_x > -14 && local_angle_x < 20))
            {
                // this.transform.Translate(new Vector3(0, 0.0000008f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (0.09f * local_angle_x + 0.35f), 0));
                rplane.AddForce(new Vector3(0, 0.00003f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (0.09f * local_angle_x + 0.35f), 0.01f* 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (0.0000000019457f * (Mathf.Pow(k,5)) + (-0.0000000655034f) * (Mathf.Pow(k,4)) + 0.0000012856573f * (Mathf.Pow(k,3)) + 0.000556808666f * (Mathf.Pow(k,2)) + (-0.00223880625f) * k + 0.000285567727f)));
            }

            if (local_angle_x >= 20)
            {
                // this.transform.Translate(new Vector3(0, 0.000000008f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (-0.08f * local_angle_x + 0.1f), 0));
                rplane.AddForce(new Vector3(0, 0.00003f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (-0.08f * local_angle_x + 0.1f), 0.01f* 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (0.0000000019457f * (Mathf.Pow(k,5)) + (-0.0000000655034f) * (Mathf.Pow(k,4)) + 0.0000012856573f * (Mathf.Pow(k,3)) + 0.000556808666f * (Mathf.Pow(k,2)) + (-0.00223880625f) * k + 0.000285567727f)));
            }
            
            if (local_angle_x <= -10)
            {
                // this.transform.Translate(new Vector3(0, 0.000000008f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (-0.08f * local_angle_x - 1.7f), 0));
                rplane.AddForce(new Vector3(0, 0.00003f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (-0.08f * local_angle_x - 1.7f), 0.01f* 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (0.0000000019457f * (Mathf.Pow(k,5)) + (-0.0000000655034f) * (Mathf.Pow(k,4)) + 0.0000012856573f * (Mathf.Pow(k,3)) + 0.000556808666f * (Mathf.Pow(k,2)) + (-0.00223880625f) * k + 0.000285567727f)));
            }
            
            

            
            
            
            
        }


        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "ground")
            {
                isGrounded = true;
            }
        }
 
        void OnCollisionExit(Collision collision)
        {
            if(collision.gameObject.name == "ground")
            {
                isGrounded = false;
            }
            Debug.Log("aaaa");
        }

        if (isGrounded == true && rplane.velocity.magnitude > 150)
        {
            if(Input.GetMouseButton(4))
            // if (Input.GetKey(upKey))
            {
                this.transform.Rotate(new Vector3(0.3f, angle / 100, 0));
                // RightFlap.transform.Rotate(new Vector3(0.3f, angle / 100, 0));
              
            }

            if(Input.GetMouseButton(3))
            // if (Input.GetKey(downKey))
            {
                this.transform.Rotate(new Vector3(-0.3f, angle / 100, 0));
                // RightFlap.transform.Rotate(new Vector3(0.3f, angle / -100, 0));
            }
        }

        if(isGrounded == false)
        {
            if(Input.GetMouseButton(4))
            // if (Input.GetKey(upKey))
            {
                this.transform.Rotate(new Vector3(0.3f, angle / 100, 0));
                // RightFlap.transform.Rotate(new Vector3(0.3f, angle / 100, 0));
              
            }

            if(Input.GetMouseButton(3))
            // if (Input.GetKey(downKey))
            {
                this.transform.Rotate(new Vector3(-0.3f, angle / 100, 0));
                // RightFlap.transform.Rotate(new Vector3(0.3f, angle / -100, 0));
            }
        }

        
            
    }
}


// 揚力係数の計算間違ってる！直線の式を求める（傾きと切片）



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

//     {
//                 // this.transform.Translate(new Vector3(0, 0.000000008f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (-0.08f * local_angle_x - 1.7f), 0));
//                 rplane.AddForce(new Vector3(0, 0.000008f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * (0.0000000019456812f * (Mathf.Pow(k,5)) + (-0.0000000655034287f) * (Mathf.Pow(k,4)) + 0.000001285657266f * (Mathf.Pow(k,3)) + 0.000556808666f * (Mathf.Pow(k,2)) + (-0.00223880625f) * k + 0.000285567727f), 0));
//             }
//   DL  [ 0.0000000019457 -0.0000000655034  0.0000012856573  0.000556808666 -0.00223880625  -0.00223880625 0.000285567727]
//   CL  [ 0.0000000354338393  0.000000509190499 -0.000153162784  0.000168228489  0.108152531  0.334100114]