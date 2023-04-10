using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShieldImageResultScript : MonoBehaviour
{
    [SerializeField] private Image shieldImageResult;
    private float timerCoroutine = 0.5f;

    public void StartCoroutineShieldImage() => StartCoroutine(CoroutineShieldImage());

    private IEnumerator CoroutineShieldImage()
    {
        shieldImageResult.gameObject.SetActive(true);
        yield return new WaitForSeconds(timerCoroutine);
        shieldImageResult.gameObject.SetActive(false);
    }
}
