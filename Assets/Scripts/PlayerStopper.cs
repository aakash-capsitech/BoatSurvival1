using System.Collections;
using UnityEngine;

public class PlayerStopper : MonoBehaviour
{
    [Header("References")]
    public GameObject starEffect;

    private Animator starAnimator;

    private LifeManager lifeManager;

    public AudioSource audioS;

    void Start()
    {
        if (starEffect != null)
        {
            starAnimator = starEffect.GetComponent<Animator>();
            starEffect.SetActive(false);
        }

        lifeManager = FindFirstObjectByType<LifeManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            if (starEffect != null && starAnimator != null)
            {
                Vector2 contactPoint = collision.contacts[0].point;
                starEffect.transform.position = contactPoint;

                starEffect.SetActive(true);
                starAnimator.Play("StarAnimation", -1, 0f);

                StartCoroutine(DisableEffectAfter(1f));
            }
            lifeManager.TakeDamage();
            audioS.Play();
        }

    }

    private IEnumerator DisableEffectAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        starEffect.SetActive(false);
    }
}
