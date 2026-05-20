using UnityEngine;

public class PlayerFunction : MonoBehaviour
{
    private const float rotespeed = 0.1f;
    private static float diff;
    public static Vector3 PlayerAngle(Vector3 protate, int angle) //ƒvƒŒƒCƒ„[‚ÌŒü‚«
    {
        //Å’Z‹——£‚ð‹‚ß‚é
        diff = Mathf.DeltaAngle(protate.y, angle);
        //Å’Z‹——£‚Å•ûŒü‚ð•Ï‚¦‚é
        if (diff > 0)
        {
            protate.y += rotespeed;
        }
        else if (diff < 0)
        {
            protate.y -= rotespeed;
        }
        
        return protate;
    }
}
