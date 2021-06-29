using TPSGame.Abstracts.Movements;
using TPSGame.Concretes.Animations;
using TPSGame.Concretes.Controllers;
using UnityEngine;
using UnityEngine.AI;

namespace TPSGame.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        IMover Mover { get; }
        InventoryController Inventory { get; }
        CharacterAnimation CharacterAnimation { get; }
        NavMeshAgent NavMeshAgent { get; }
        Transform Target { get; set; }
    }
}
