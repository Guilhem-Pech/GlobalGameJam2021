using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Ship
{
    public class CanonHandler : EquipmentHandler
    {
        [HideInInspector] public Canon canon; // The canon ScriptableObject

        private float counter = 0; // cooldown
        [SerializeField] private FModEvent fireEvent;
        [SerializeField] private List<Transform> spawnPoints;

        public override Equipment Equipment { get => canon; set => canon = (Canon)value; }

        public override void DoAction()
        {
            if(counter < 1/canon.fireRate) return; // cant fire if cooldown
            foreach (Transform spawnPoint in spawnPoints)
            {
                if(!spawnPoint.CompareTag("SpawnPoint")) continue;
                GameObject ball = Instantiate(canon.canonBallPrefab, spawnPoint.transform.position, canon.canonBallPrefab.transform.rotation);
                ball.transform.localScale *= canon.ballScale;
                CanonBall canonBall = ball.GetComponent<CanonBall>();
                canonBall.direction = spawnPoint.up;
                canonBall.speed = canon.velocity;
                canonBall.range = canon.range;
            }            
            counter = 0;
            transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.5f);
            fireEvent.Play();
        }

        public void Update() {
            counter += Time.deltaTime;
        }

        public void Start()
        {
            fireEvent.AttatchToGameobject(this.gameObject);
        }

        public void OnDestroy()
        {
            fireEvent.Release();
        }

        public void OnDisable()
        {
            fireEvent.Release();
        }

        private void OnDrawGizmosSelected() {
            if (spawnPoints == null) return;
            Gizmos.color = Color.red;
            foreach (Transform spawnPoint in spawnPoints)
            {
                Gizmos.DrawLine(spawnPoint.position, spawnPoint.position + spawnPoint.up);
            }
        }
    }
}