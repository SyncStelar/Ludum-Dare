using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public static int numEnemiesToSpawn = 0;
    public static int numEnemiesLeft = 0;

    public float hp = 100;

    [SerializeField] private float hpLowPercent = 25;
    [SerializeField] private float dmg;
    [SerializeField] private float minFireRate;
    [SerializeField] private float maxFireRate;
    [SerializeField] private int randomGruntMax = 100000;

    [SerializeField] private Material hpLowMat;

    [SerializeField] private GameObject fireballPrefab;

    [SerializeField] private int deathAnimID;
    [SerializeField] private int fireAnimID;
    [SerializeField] private int onHitAnimID;
    [SerializeField] private int spawnAnimID;

    [SerializeField] private Animation onDeathAnim;
    [SerializeField] private Animation onFireAnim;
    [SerializeField] private Animation onHitAnim;
    [SerializeField] private Animation onSpawnAnim;

    [SerializeField] private AudioClip onDeathSound;
    [SerializeField] private AudioClip onFireSound;
    [SerializeField] private AudioClip onHitSound;
    [SerializeField] private AudioClip onSpawnSound;

    [SerializeField] private AudioClip gruntSound;

    private bool hpLowBool = false;

    private AudioSource aus;
    private Animator anim;

    private void Awake() {
        aus = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

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

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "EnemyBullet") {
            hp -= 10; //TOBECHANGED---------------------------------------------------

            if (onHitSound != null && hp > 0) {
                aus.PlayOneShot(onHitSound);
            }

            if (hp > 0 && onHitAnimID >= 0) {
                anim.SetBool(onHitAnimID, true);
            }
        }
    }

    private void EndAnimations() {

        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        //Check if his onHit anim ended
        if (info.IsName(onHitAnim.name) && onHitAnimID >= 0) {
            if (info.normalizedTime >= -1) {
                anim.SetBool(onHitAnimID, false);
            }
        } else if (anim.GetBool(onHitAnimID) && onHitAnimID >= 0){
            anim.SetBool(onHitAnimID, false);
        }

        if (info.IsName(onSpawnAnim.name)) {

        }
    }

    private void Firing() {
        aus.PlayOneShot(onFireSound);
        anim.SetBool(fireAnimID, true);
        Instantiate(fireballPrefab);
        timeFire = 0;
    }

    private void HpLowCheck() {
        if (!hpLowBool && (hp < (hp / hpLowPercent * 100))) {
            Renderer rend = GetComponent<Renderer>();
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

        if (deathAnimID >= 0) {
            anim.SetBool(deathAnimID, true);
        }

        numEnemiesLeft--;
        Destroy(gameObject);
    }
}
