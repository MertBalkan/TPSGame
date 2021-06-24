using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Controllers;
using TPSGame.Abstracts.Movements;
using UnityEngine;
using UnityEngine.AI;

namespace TPSGame.Concretes.Movements
{
    public class MoveWithNavMesh : IMover
    {
        private NavMeshAgent _navMeshAgent;

        public MoveWithNavMesh(IEntityController entityController)
        {
            _navMeshAgent = entityController.transform.GetComponent<NavMeshAgent>();
        }

        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            _navMeshAgent.SetDestination(direction);
        }
    }
}