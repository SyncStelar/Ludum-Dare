using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public static int numEnemiesToSpawn = 0;
    public static int numEnemiesLeft = 0;

    public float hp = 100;

    [SerializeField] private float hpDefault = 100;
    [SerializeField] private float hpLowPercent = 25;
    [SerializeField] private float minFireRate;
    [SerializeField] private float maxFireRate;

    [SerializeField] private Transform bulletSpawnPos;

    [SerializeField] private Material hpLowMat;

    [SerializeField] private GameObject fireballPrefab;

    [SerializeField] private AnimationClip onDeathAnim;
    [SerializeField] private AnimationClip onFireAnim;
    [SerializeField] private AnimationClip onHitAnim;
    [SerializeField] private AnimationClip onSpawnAnim;

    [SerializeField] private AudioClip onDeathSound;
    [SerializeField] private AudioClip onFireSound;
    [SerializeField] private AudioClip onHitSound;
    [SerializeField] private AudioClip onSpawnSound;

    [SerializeField] private AudioClip gruntSound;

    public void TakeDamage (float dmg) {
        hp -= dmg;

        if (onHitSound != null && hp > 0) {
            aus.PlayOneShot(onHitSound);
        }

        if (hp > 0) {
            anim.SetBool("onHit", true);
        }
    }

    private bool hpLowBool = false;

    private AudioSource aus;
    private Animator anim;

    private void Awake() {
        aus = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();

        numEnemiesToSpawn--;
        numEnemiesLeft++;
    }

    private void Start() {
        if (!aus.isPlaying && onSpawnSound != null) {
            aus.PlayOneShot(onSpawnSound);
        }
    }

    private float timeGrunt = 0;
    private float timeFire = 0;

    private void Update() {
        timeGrunt += Time.deltaTime;
        timeFire += Time.deltaTime;

        HpLowCheck();

        if (hp <= 0) {
            DestroyEnemy();
        }

        //random grunt sounds
        if (!aus.isPlaying && timeGrunt >= Random.Range(10f, 20f)) {
            aus.PlayOneShot(gruntSound);
            timeGrunt = 0;
        }

        if (!aus.isPlaying && timeFire >= Random.Range(minFireRate, maxFireRate)) {
            Firing();
        }

        EndAnimations();
    }

    private void EndAnimations() {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        if (info.normalizedTime >= -1) {
            //onHit
            if (info.IsName(onHitAnim.name)) {
                anim.SetBool("onHit", false);
            }

            //onFire
            if (info.IsName(onFireAnim.name)) {
                anim.SetBool("onFire", false);
            }

            //onSpawn
            if (info.IsName(onSpawnAnim.name)) {
                anim.SetBool("onSpawn", false);
            }

            //onDeath
            if (info.IsName(onDeathAnim.name)) {
                Destroy(gameObject);
            }
        }

    }

    private void Firing() {
        aus.PlayOneShot(onFireSound);
        anim.SetBool("onFire", true);
        var fireball = Instantiate(fireballPrefab, bulletSpawnPos.position, bulletSpawnPos.rotation);
        Destroy(fireball, 5f);
        timeFire = 0;
    }

    private void HpLowCheck() {
        if (!hpLowBool && (hp <= ((hpDefault * hpLowPercent) / 100))) {
            Renderer rend = GetComponentInChildren<Renderer>();
            if (rend != null) {
                rend.material = hpLowMat;
            }

            hpLowBool = true;
        }
    }

    private void DestroyEnemy() {
        if (onDeathSound != null) {
            aus.PlayOneShot(onDeathSound);
        }

        anim.SetBool("onDeath", true);
    }

    private void OnDestroy() {
        numEnemiesLeft--;
    }
}
