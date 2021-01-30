using System;
using UnityEngine;
using DG.Tweening;

namespace Ship
{
    public class Canon : Equipment
    {
        [SerializeField] private int value = 0;
        public override int Value { get => value; protected set => this.value = value; }
        [SerializeField] private String _name;
        public String Name { get => _name; }
        
        [SerializeField] private GameObject canonBallPrefab;
        [SerializeField] private GameObject spawnPoint;
        [SerializeField] private float velocity;
        public float Velocity { get => velocity; }
        [SerializeField] private float fireRate = 0.5f;
        public float FireRate { get => fireRate; }
        public int Damage { get => canonBallPrefab.GetComponent<CanonBall>().Damage; }
        private float counter = 0;
        [SerializeField] private int range = 100;
        public int Range { get => range; }
        [SerializeField] private float ballScale = 1;
        public float BallScale { get => ballScale; }

        public override void DoAction()
        {
            if(counter < 1/fireRate) return;
            GameObject ball = Instantiate(canonBallPrefab, spawnPoint.transform.position, canonBallPrefab.transform.rotation);
            ball.transform.localScale *= ballScale;
            CanonBall canonBall = ball.GetComponent<CanonBall>();
            canonBall.direction = transform.up;
            canonBall.speed = velocity;
            canonBall.range = range;
            counter = 0;
            transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.5f);    
        }

        private void Update() {
            counter += Time.deltaTime;
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(spawnPoint.transform.position, spawnPoint.transform.position + transform.up);
        }
    }
}
