using UnityEngine;

[CreateAssetMenu(fileName = "StatusData", menuName = "Scriptable Objects/StatusData")]
public class StatusData : ScriptableObject
{
    public struct Status
    {
        int hp;
        int power;
        int LightPower;  //ãUŒ‚
        int StrongPower; //‹­UŒ‚
        int Defense;
    }

}
