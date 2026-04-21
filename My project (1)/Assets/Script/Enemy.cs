using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum EStatus //初期ステータス
    {
        HP = 20,
        Power = 10,
    }
    public int HP, Power; //ステータス
    void Start()
    {
        HP = (int)EStatus.HP; Power = (int)EStatus.Power;
    }

    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
