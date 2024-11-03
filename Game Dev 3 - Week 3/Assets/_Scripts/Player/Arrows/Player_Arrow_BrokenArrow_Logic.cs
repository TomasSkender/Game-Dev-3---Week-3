using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

namespace GameDevWithMarco.Player
{
    public class Player_Arrow_BrokenArrow_Logic : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;

        [SerializeField] float arrowShakeTime;
        [SerializeField] float arrowShakeStrength;
        [SerializeField] float arrowFadeTime;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine(ShakeTheArrowCreation());
        
        }

        IEnumerator ShakeTheArrowCreation()
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.transform.DOShakeScale(arrowShakeTime, arrowShakeStrength);
                yield return new WaitForSeconds(arrowShakeTime);
                StartCoroutine(FadeThenDestroyLogic());
            }
        }

        IEnumerator FadeThenDestroyLogic()
        {
            spriteRenderer.DOFade(0,arrowFadeTime);
            yield return new WaitForSeconds(arrowFadeTime);
            Destroy(gameObject);
        }
    }
}
