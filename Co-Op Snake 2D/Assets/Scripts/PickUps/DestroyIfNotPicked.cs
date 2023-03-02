using System.Collections;
using UnityEngine;

public class DestroyIfNotPicked : MonoBehaviour
{
    [SerializeField]
    private float waitSeconds = 3f;
    private void Awake()
    {
        StartCoroutine(NotPicked());
    }
    IEnumerator NotPicked()
    {
        yield return new WaitForSeconds(waitSeconds) ;
        SoundManager.Instance.PlaySfxSound(SoundType.FoodNotPicked);
        Destroy(gameObject);
    }
}
