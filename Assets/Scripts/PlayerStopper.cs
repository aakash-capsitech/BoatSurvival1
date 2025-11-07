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

    private void Update()
    {
        float posX = Mathf.Clamp(transform.position.x, -1.4f, 1.4f);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
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
            //lifeManager.TakeDamage();
            audioS.Play();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            if (starEffect != null && starAnimator != null)
            {
                //Vector2 contactPoint = collision.contacts[0].point;
                //starEffect.transform.position = collision.transform.position;
                float animeOffset = 0f;
                if(transform.position.x > 0f)
                {
                    animeOffset = 0.15f;
                }
                else
                {
                    animeOffset = -0.15f;
                }
                    starEffect.transform.position = new Vector3(transform.position.x + animeOffset, transform.position.y, transform.position.z);

                starEffect.SetActive(true);
                starAnimator.Play("StarAnimation", -1, 0f);

                StartCoroutine(DisableEffectAfter(1f));
            }
            //lifeManager.TakeDamage();
            audioS.Play();
        }
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            if (starEffect != null && starAnimator != null)
            {
                starEffect.transform.position = collision.transform.position;
                starEffect.SetActive(true);
                starAnimator.Play("StarAnimation", -1, 0f);
                StartCoroutine(DisableEffectAfter(1f));
            }
        }
    }


    private IEnumerator DisableEffectAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        starEffect.SetActive(false);
    }
}
