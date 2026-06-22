using UnityEngine;
using UnityEngine.InputSystem;

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
    bool f; //デバッグ用

    enum EStatus //初期ステータス
    {
        HP = 50,
        Power = 10,
    }

    void Start()
    {
        m_StartPos = transform.position; //最初の位置
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
            Destroy(gameObject, 2f);
        }
        //プレイヤーが奈落かワープをした時
        if (Player.pos_reset_flag == true)
        {
            Debug.Log("敵の位置を初期化した");
            transform.eulerAngles = Vector3.zero;
            transform.position = new Vector3(m_StartPos.x, posy, m_StartPos.z);

        }
    }
}
