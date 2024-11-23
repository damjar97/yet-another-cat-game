using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawController : MonoBehaviour
{
    [SerializeField]
    private GameObject _paw;
    [SerializeField]
    private float _cooldown = 1.0f;
    [SerializeField]
    private AudioClip _attackClip;
    private bool _canAttack = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_canAttack)
            {
                PawAttack();
            }
        }

    }

    void PawAttack()
    {
        _canAttack = false;
        Animator animator = _paw.GetComponent<Animator>();
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(_attackClip);
        animator.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(_cooldown);
        _canAttack = true;
    }
}