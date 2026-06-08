using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class Enemy : MonoBehaviour
{
    public Vector3 Direction;
    private Vector3 m_StartPos;
    //Yの位置初期化用
    private const float posy = 1;
    //ステータス
    public int enemyhp;
    //点滅用
    public GameObject DamageEffectObj;
    private bool isvisible = true;
    public bool invincible = false;
    //他のスクリプト呼び出し
    public GameObject EnemyObj;
    public Player player;
    Effect ef = new Effect(); //ダメージを受けた時に点滅する
    EnemyAttack eattack = new EnemyAttack();
    public HPBar hpb;
    public WarpSwitch[] wp;

    enum EStatus //初期ステータス
    {
        HP = 50,
        Power = 10,
    }

    void Start()
    {
        m_StartPos = transform.position; //最初の位置
        enemyhp = (int)EStatus.HP; //ステータスの初期化
        Direction = Vector3.zero; //回転の初期化
        transform.eulerAngles = Direction;

    }

    void Update()
    {
        //ダメージ受けた時に点滅エフェクト
        (isvisible, invincible) = ef.DamageEffect(isvisible, enemyhp);
        EnemyObj.SetActive(isvisible);
        DamageEffectObj.SetActive(!isvisible);

        //HPが0になると消える
        if (enemyhp <= 0)
        {
            Destroy(gameObject);
        }
        //ワープ
        foreach (var ws in wp)
        {
            if(ws.WarpFlag == true)
            {
                transform.eulerAngles = Vector3.zero;
                transform.position = new Vector3(m_StartPos.x, posy, m_StartPos.z);
            }
        }
        if (player.abyssflag == true)
        {
            Debug.Log("敵の位置を初期化した");
            transform.eulerAngles = Vector3.zero;
            transform.position = new Vector3(m_StartPos.x, posy, m_StartPos.z);
        }
    }
}
