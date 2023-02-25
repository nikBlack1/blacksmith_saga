using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] public Health playerHealth;
    [SerializeField] public Image totalhealthBar;
    [SerializeField] public Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
