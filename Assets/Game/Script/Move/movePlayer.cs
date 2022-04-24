using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace iland.move
{
    public class movePlayer : MonoBehaviour
    {



        [Header("AI")]
        public Pathfinding.AIDestinationSetter AIDestinationSetter;
        public Pathfinding.AIPath aIPath;
        public Animator animator;

        public Transform Target;
        public Camera Camera;

        public Tilemap map;
        private Vector3 mousePosition;
        void Start()
        {
            transform.localScale = new Vector3(0.35f, 0.35f, 1);
        }

        
        void Update()
        {
            mouseClick();
            AiPathModifire();
        }


        public void AiPathModifire()
        {
            animator.SetFloat("speed", aIPath.velocity.magnitude);
            if (aIPath.desiredVelocity.x >= 0.01f)
                transform.localScale = new Vector3(0.35f, 0.35f, 1);
            if (aIPath.desiredVelocity.x <= -0.01f)
                transform.localScale = new Vector3(-0.35f, 0.35f, 1);

            /*if (aIPath.desiredVelocity.x >= 0.01f)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            if (aIPath.desiredVelocity.x <= -0.01f)
                transform.rotation = Quaternion.Euler(0, 180, 0);*/
        }
        public void mouseClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;

                Vector3Int gridPosition = map.WorldToCell(mousePosition);
                if (map.HasTile(gridPosition))
                    Target.position = mousePosition;
            }            
        }
    }
}

