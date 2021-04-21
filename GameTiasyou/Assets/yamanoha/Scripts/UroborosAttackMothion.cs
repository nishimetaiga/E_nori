﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UroborosAttackMothion : MonoBehaviour
{
    private GameObject attackCourtain;
    private bool attackFlg; // ウロボロスが攻撃中か判断する　true:攻撃中  false:否

    // Start is called before the first frame update
    void Start()
    {
        attackCourtain = GameObject.Find("LaunchPort");
        attackFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackFlg == false)
        {
            //var timent = 0;
            var attackPaternChoice = 0.7f; /*Random.value;*/
            Debug.Log(attackPaternChoice);
            if (attackPaternChoice < 0.25)
            {
                attackCourtain.GetComponent<Bullet1>().AttackStart();
                //attackCourtain.GetComponent<Bullet4>().AttackStart();
            }
            else if (attackPaternChoice < 0.5)
                attackCourtain.GetComponent<Bullet2>().AttackStart();
            else if (attackPaternChoice < 0.75)
                attackCourtain.GetComponent<Bullet3>().AttackStart();
            else
                attackCourtain.GetComponent<Bullet4>().AttackStart();

            attackFlg = true;
            //StartCoroutine(AttackFinishReceiver());// クールタイムとして使用
        }
    }

    /// <summary>
    /// 攻撃が終了する際に呼び出される関数
    /// </summary>
    public IEnumerator AttackFinishReceiver()
    {
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        attackFlg = false;
    }
}
