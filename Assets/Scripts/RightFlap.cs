using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFlap : MonoBehaviour
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
    

    Rigidbody rRF;
    Rigidbody rplane;

    // Start is called before the first frame update
    void Start()
    {
        rRF = this.GetComponent<Rigidbody>();
        rplane = GameObject.Find("Fighter").GetComponent<Rigidbody>();
        rRF.constraints = RigidbodyConstraints.FreezePositionX| RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        Debug.Log(vx+"/"+vz);
    }

    // Update is called once per frame
    void Update()
    {
        angle = Input.GetAxisRaw("Horizontal") * rotatespeed * 1;
        vz = Input.GetAxisRaw("Vertical") * movespeed;
    }

    void FixedUpdate()
    {
       // transformを取得
        Transform myTransform = this.transform;
 
        // ローカル座標を基準に、回転を取得
        Vector3 localAngle = myTransform.localEulerAngles;
        float local_angle_x = localAngle.x; // ローカル座標を基準にした、x軸を軸にした回転角度
        float local_angle_y = localAngle.y; // ローカル座標を基準にした、y軸を軸にした回転角度
        float local_angle_z = localAngle.z; // ローカル座標を基準にした、z軸を軸にした回転角度

        // if (local_angle_x >180)
        // {
        //     local_angle_x = local_angle_x - 360;
        // }

        // // 速度ベクトルを表示
        // Debug.Log ("速度ベクトル: " + rplane.velocity);
        // 速度を表示
        // Debug.Log ("速度: " + rplane.velocity.magnitude);
        
        
        if (angle != 0)//回転する
        {
            this.transform.Rotate(new Vector3(0, 0, angle / -100));
        }

        

        
        if(Input.GetMouseButton(4))
            {
                this.transform.Rotate(new Vector3(-0.3f, angle / 100, 0));
            }

        if(Input.GetMouseButton(3))
            {
                this.transform.Rotate(new Vector3(0.3f, angle / 100, 0));
            }
    
        

        if (rplane.velocity.magnitude > 150)
        {
            if ((local_angle_x > -20 && local_angle_x < 10))
            {
                GameObject.Find("Fighter").transform.Translate(new Vector3(0, 0, -0.0000008f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * 0.07f * local_angle_x));
                
            }

            if (local_angle_x >= 10 || local_angle_x <= -20)
            {
                GameObject.Find("Fighter").transform.Translate(new Vector3(0, 0, -0.00000005f * 0.5f * 1.293f * rplane.velocity.magnitude * rplane.velocity.magnitude　* 30 * -0.08f * local_angle_x));
            }
            
            
            

            if (rplane.velocity.magnitude > 400)
            {
                // 速度を一定にする
                rplane.velocity = new Vector3(0,0,400);
            }
        }   
            
            
    }
}
