using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 target;
    // Start is called before the first frame update

    public Rigidbody ball;
    public static Vector2 m_moveLimit = new Vector2(4.15f, 3.0f);
    [SerializeField] private float rotate_power;            //回転加速力
    [SerializeField] private float rotate_speed_max;        //回転最大速度
    [SerializeField] private float rotate_speed_init;       //回転初速
    [SerializeField] private float rotate_speed_down_rate;  //回転減速係数
    [SerializeField] private float rotate_speed_up_rate;    //回転加速係数

    [SerializeField] private float rot_border_DtoU = 90; //第一～第二象限
    [SerializeField] private float rot_border_UtoU = 180; //第二～第三象限
    [SerializeField] private float rot_border_UtoD = 270; //第三～第四象限
    [SerializeField] private int rotatingSE_num;
    private bool charged;
    private int point_playSE;      //まわすSEを鳴らしたいところ
    private int point_rot_now;     //ハンマーの位置
    private bool checkSE;

    private float rotate_speed;
    public float oldspeed_level;

    public float startTime;
    bool Swich = false;
    void Start()
    {
        rotate_speed = rotate_speed_init;
        charged = false;
        point_playSE = 0;
        checkSE = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!Swich)
        {



            //var h = Input.GetAxis("Horizontal");
            //var v = Input.GetAxis("Vertical");

            //var velocity = new Vector3(h, v) * m_speed;
            //transform.localPosition += velocity;

            //transform.localPosition = ClampPosition(transform.localPosition);

            //// プレイヤーのスクリーン座標を計算する
            //var screenPos = Camera.main.WorldToScreenPoint(transform.position);

            //// プレイヤーから見たマウスカーソルの方向を計算する
            //var direction = Input.mousePosition - screenPos;

            //// マウスカーソルが存在する方向の角度を取得する
            //var angle = GetAngle(Vector3.zero, direction);

            //// プレイヤーがマウスカーソルの方向を見るようにする
            //var angles = transform.localEulerAngles;
            //angles.z = angle - 90;
            //transform.localEulerAngles = angles;

            if (Input.GetMouseButton(0))
            {
                //最大速度ではないとき
                if (!charged)
                {
                    //常に一定量加速
                    rotate_speed += rotate_power;

                    //第一象限で減速
                    if (transform.eulerAngles.z <= rot_border_DtoU)
                    {
                        rotate_speed *= rotate_speed_down_rate;
                        if(point_playSE == 0)
                        {
                            point_playSE = 1;
                        }
                        point_rot_now = 1;
                    }
                    //第二象限で弱く加速
                    else if (transform.eulerAngles.z <= rot_border_UtoU)
                    {
                        rotate_speed += rotate_power / 4.0f;
                        if (point_playSE == 0)
                        {
                            point_playSE = 2;
                        }
                        point_rot_now = 2;
                    }
                    //第三象限で大きく加速
                    else if(transform.eulerAngles.z <= rot_border_UtoD)
                    {
                        rotate_speed *= rotate_speed_up_rate;
                        if (point_playSE == 0)
                        {
                            point_playSE = 3;
                        }
                        point_rot_now = 3;
                    }
                    //第四象限で減速
                    else
                    {
                        rotate_speed *= rotate_speed_down_rate;
                        if (point_playSE == 0)
                        {
                            point_playSE = 4;
                        }
                        point_rot_now = 4;
                    }

                    //最大速度なら速度一定に
                    if (rotate_speed >= rotate_speed_max)
                    {
                        rotate_speed = rotate_speed_max;
                        charged = true;
                        Debug.Log("Full_Charged");
                    }

                   
                }
                else    //最大速度なら速度一定
                {
                    rotate_speed = rotate_speed_max;

                    if (transform.eulerAngles.z <= rot_border_DtoU) {
                        point_rot_now = 1;
                    }
                    else if (transform.eulerAngles.z <= rot_border_UtoU) {
                        point_rot_now = 2;
                    }
                    else if (transform.eulerAngles.z <= rot_border_UtoD) {
                        point_rot_now = 3;
                    }
                    else {
                        point_rot_now = 4;
                    }
                }

                CheckPlaySEPoint();
                // startTime = Time.time;

                transform.Rotate(new Vector3(0, 0, rotate_speed));

                //Time.timeScale = 0.5f;

                ball.mass = 0.0f;
            }
            if (Input.GetMouseButtonUp(0))
            {
                //Time.timeScale = 1.0f;
                //startTime = 0.0f;
                Swich = true;

                ball.mass = 1.0f;

                charged = false;

                point_playSE = 0;

                checkSE = true;
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                RotateInit();
            }

        }

        /*
    if (Input.GetKeyDown("1"))
    {
        speed_level = 2.0f;
        oldspeed_level = speed_level;
    }
    if (Input.GetKeyDown("2"))
    {
        speed_level = 3.0f;
        oldspeed_level = speed_level;
    }
        */
    }

    private void CheckPlaySEPoint()
    {
        if(point_playSE == point_rot_now)
        {
            if (!checkSE)
            {
                checkSE = true;
                SoundManager.instance.PlaySE(0);
            }
        }
        else
        {
            checkSE = false;
        }
        
    }

    public void RotateInit()
    {
        Swich = false;

        rotate_speed = rotate_speed_init;
    }
}