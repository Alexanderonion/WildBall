using UnityEngine;
using System.Collections;

public class InfoTable : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ball_lp")
        {
            _infoPanel.SetActive(true);
        }
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        yield return new WaitForSeconds(4);
        _infoPanel.SetActive(false);
    }
}