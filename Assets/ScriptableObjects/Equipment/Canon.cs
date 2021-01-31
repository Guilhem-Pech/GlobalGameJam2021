using System;
using UnityEngine;
using DG.Tweening;
using ScriptableObjects;

namespace Ship
{
    public class Canon : Equipment
    {
        [SerializeField] private int value = 0;
        public override int Value { get => value; protected set => this.value = value; }
        [SerializeField] private String _name;
        public String Name { get => _name; }
        
        [SerializeField] private GameObject canonBallPrefab;
        [SerializeField] private GameObject[] spawnPoints;
        [SerializeField] private float velocity;
        public float Velocity { get => velocity; set => velocity = value; }
        [SerializeField] private float fireRate = 0.5f;
        public float FireRate { get => fireRate; set => fireRate = value; }
        public int Damage { get => canonBallPrefab.GetComponent<CanonBall>().Damage; set => canonBallPrefab.GetComponent<CanonBall>().Damage = value; }
        private float counter = 0;
        [SerializeField] private int range = 100;
        public int Range { get => range; set => range = value; }
        [SerializeField] private float ballScale = 1;
        public float BallScale { get => ballScale; set => ballScale = value; }
        public GameObject prefab;

        [SerializeField] FModEvent fireEvent;
        
        public override void DoAction()
        {
            if(counter < 1/fireRate) return;

            foreach (GameObject spawnPoint in spawnPoints)
            {
                GameObject ball = Instantiate(canonBallPrefab, spawnPoint.transform.position, canonBallPrefab.transform.rotation);
                ball.transform.localScale *= ballScale;
                CanonBall canonBall = ball.GetComponent<CanonBall>();
                canonBall.direction = spawnPoint.transform.up;
                canonBall.speed = velocity;
                canonBall.range = range;
            }
            
            counter = 0;
            transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.5f);
            fireEvent.Play();
        }

        private void Update() {
            counter += Time.deltaTime;
        }

        private void Start()
        {
            fireEvent.AttatchToGameobject(gameObject);
        }

        private void OnDestroy()
        {
            fireEvent.Release();
        }

        private void OnDisable()
        {
            fireEvent.Release();
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            foreach (GameObject spawnPoint in spawnPoints)
            {
                Gizmos.DrawLine(spawnPoint.transform.position, spawnPoint.transform.position + spawnPoint.transform.up);
            }
        }
    }
}
