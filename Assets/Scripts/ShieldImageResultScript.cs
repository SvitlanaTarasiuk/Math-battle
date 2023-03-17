using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShieldImageResultScript : MonoBehaviour
{
    public Image shieldImageResult;

    public void StartCoroutineShieldImage()
    {
        StartCoroutine(CoroutineShieldImage());
    }
    private IEnumerator CoroutineShieldImage()
    {
        Debug.Log("Coroutine Start");
        shieldImageResult.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        shieldImageResult.gameObject.SetActive(false);
        Debug.Log("Coroutine End");
    }
}
