using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShower : MonoBehaviour
{
    public List<Shower> prefabs;
    private Dictionary<string, Shower> instances;
    private Dictionary<string, WaitForSeconds> delays;
    public MonsterManager monsterManager;
    private void Start()
    {
        instances = new Dictionary<string, Shower>(prefabs.Count);
        delays = new Dictionary<string, WaitForSeconds>(prefabs.Count);

        for(int i=0; i<prefabs.Count; i++)
        {
            Shower instance = Lean.Pool.LeanPool.Spawn(prefabs[i], transform);
            instances.Add(prefabs[i].sName, instance);
            delays.Add(prefabs[i].sName, new WaitForSeconds(prefabs[i].seconds));
        }
    }

    public void UseAbility(GameObject target, string sName)
    {
        if (!instances.ContainsKey(sName))
        {
            Debug.LogWarning("샤워 인스턴스 딕셔너리에 " + sName + "을 가진 인스턴스가 없음");
        }
        else
        {
            StartCoroutine(StartAbility(target, instances[sName]));
        }
    }

    public IEnumerator StartAbility(GameObject target, Shower shower)
    {
        for (int i = 0; i < shower.iterate; i++)
        {
            yield return null;
            monsterManager.FindClosestMonster();
            target = monsterManager.GetClosestMonster();
            if (target != null && target.activeSelf)
            {
                // 운석 떨어지는 이펙트 시작
                ////////////////////////////////////////////////////////////////////
                // 운석 위치 각도 설정
                float x = target.transform.position.x + 3;
                float y = target.transform.position.y + 5;
                Quaternion rotation = Quaternion.identity;
                rotation.eulerAngles = new Vector3(0, 0, -120);
                // 운석 생성
                GameObject go = Lean.Pool.LeanPool.Spawn(shower.objectEffect);

                go.transform.position = new Vector2(x, y);
                go.transform.rotation = rotation;
                //////////////////////////////////////////////////////////////////////
                ///// 운석을 해당 타겟 위치에 떨어지도록 이동시킴
                while (Vector2.Distance(go.transform.position, target.transform.position) > 0.2f)
                {
                    go.transform.position = Vector2.MoveTowards(go.transform.position, target.transform.position, shower.landSpeed * Time.deltaTime);
                    yield return new WaitForEndOfFrame();
                }
                //Lean.Pool.LeanPool.Despawn(go);
                // 운석이 다 떨어졌을경우
                // 폭발 이펙트 생성
                GameObject expEffect = Lean.Pool.LeanPool.Spawn(shower.explodeEffect);
                expEffect.transform.position = target.transform.position;
                Lean.Pool.LeanPool.Despawn(expEffect, 1f);
                Lean.Pool.LeanPool.Despawn(go);
                // 주변 몬스터를 가져옴
                Collider2D[] monsters = Physics2D.OverlapCircleAll(target.transform.position, shower.range);
                Monster m = null;
                if (monsters != null)
                {
                    for (int j = 0; j < monsters.Length; j++)
                    {
                        m = monsters[j].GetComponent<Monster>();
                        if (m != null)
                        {
                            // TODO: 속성데미지로 바꾸기
                            m.TakeDamage(shower.damage);
                        }
                    }
                }
            }
            else
            {
                // 운석 떨어지는 이펙트 시작
                ////////////////////////////////////////////////////////////////////
                // 랜덤위치 설정
                Vector2 rnd = transform.position + Random.onUnitSphere * 3;
                // 운석 위치 설정
                Vector2 pos = new Vector2(rnd.x + 3, rnd.y + 5);
                Quaternion rotation = Quaternion.identity;
                rotation.eulerAngles = new Vector3(0, 0, -120);
                // 운석 생성
                GameObject go = Lean.Pool.LeanPool.Spawn(shower.objectEffect);
                go.transform.position = pos;
                go.transform.rotation = rotation;
                //////////////////////////////////////////////////////////////////////
                ///// 운석을 해당 타겟 위치에 떨어지도록 이동시킴
                while (Vector2.Distance(go.transform.position, rnd) > 0.2f)
                {
                    go.transform.position = Vector2.MoveTowards(go.transform.position, rnd, shower.landSpeed * Time.deltaTime);
                    yield return new WaitForEndOfFrame();
                }
                //Lean.Pool.LeanPool.Despawn(go);
                // 운석이 다 떨어졌을경우
                // 폭발 이펙트 생성
                GameObject expEffect = Lean.Pool.LeanPool.Spawn(shower.explodeEffect);
                expEffect.transform.position = rnd;
                Lean.Pool.LeanPool.Despawn(expEffect, 1f);
                Lean.Pool.LeanPool.Despawn(go);
                //Random  지역에 떨굼
                continue;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void EndAbility(Shower shower)
    {
        Lean.Pool.LeanPool.Despawn(shower);
    }

}
