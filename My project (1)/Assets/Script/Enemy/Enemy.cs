using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
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
    public int money;
    //点滅用
    public GameObject DamageEffectObj;
    private bool isvisible = true;
    public bool invincible = false;
    //死亡用
    public GameObject DethEffect;
    public bool enemyDeth;
    //他のスクリプト呼び出し
    public GameObject EnemyObj;
    public Player player;
    Effect ef = new Effect(); //ダメージを受けた時に点滅する
    //public HPBar hpb;
    public WarpSwitch[] wp;
    bool f;

    enum EStatus //初期ステータス
    {
        HP = 50,
        Power = 10,
    }

    IEnumerator DethCoroutine()
    {
        yield return new WaitForSeconds(2); //　１０秒まつ
        Destroy(gameObject);
    }

    void Start()
    {
        m_StartPos = transform.position; //最初の位置
        //enemyhp = (int)EStatus.HP; //ステータスの初期化
        Direction = Vector3.zero; //回転の初期化
        transform.eulerAngles = Direction;
        enemyDeth = false;
        f = false;
    }

    void Update()
    {
        var current = Keyboard.current;  //現在のキーボード情報
        if (current == null) return;     //キーボード接続チェック

        var fKey = current.fKey; //Wキーの入力状態取得
        if (fKey.isPressed && !f)
        {
            f = true;
            enemyhp -= 10;
        }
        else if(!fKey.isPressed)
        {
            f = false;

        }
        //ダメージ受けた時に点滅エフェクト
        (isvisible, invincible) = ef.DamageEffect(isvisible, enemyhp);
        EnemyObj.SetActive(isvisible);
        DamageEffectObj.SetActive(!isvisible);

        //HPが0になると消える
        if (enemyhp <= 0)
        {
            enemyDeth = true;
            DethEffect.SetActive(true);
            EnemyObj.SetActive(false);
            StartCoroutine(DethCoroutine());
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
