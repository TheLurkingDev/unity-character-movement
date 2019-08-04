using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Persistence;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private Transform _transform;

        private void Start()
        {
            _transform = GetComponent<Transform>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {

            }
            if (Input.GetKeyDown(KeyCode.L))
            {

            }
        }
    }
}
