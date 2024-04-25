using UnityEngine;

public class PlatformSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _platform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ball_lp")
        {
            _platform.GetComponent<Animator>().SetInteger("MakeThePlatformMove", 1);
        }
    }
}