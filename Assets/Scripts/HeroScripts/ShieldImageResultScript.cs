using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShieldImageResultScript : MonoBehaviour
{
    [SerializeField] private Image shieldImageResult;

    public void StartCoroutineShieldImage() => StartCoroutine(CoroutineShieldImage());

    private IEnumerator CoroutineShieldImage()
    {
        shieldImageResult.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        shieldImageResult.gameObject.SetActive(false);
    }
}
