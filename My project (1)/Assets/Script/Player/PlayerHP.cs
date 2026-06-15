using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public Player player;
    public HPBar hpb;
    private const int abyssdamage = 10;  //奈落に落ちた時のダメージ

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ThrustAttack")) //ThrustAttackTagに衝突時
        {
            player.hp -= ThrustEnemy.power; //敵のダメージを受けた
            Debug.Log("１０ダメージ受けた");
            hpb.HPbar(player.hp);

        }
        if (other.CompareTag("Abyss"))
        {
            player.abyssflag = true;
            if (player.hp != 0) //プレイヤーが生きている時
            {
                player.hp -= abyssdamage; //奈落ダメージ
                Debug.Log("１０ダメージ受けた");
                hpb.HPbar(player.hp);//HPバーにダメージを反映

            }
        }

    }
}
