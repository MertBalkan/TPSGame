using UnityEngine;

namespace TPSGame.Abstracts.Inputs
{
    public interface IInputReader
    {
        Vector3 Direction { get; }
        Vector2 Rotation { get; }
        bool IsAttackButtonPressed { get; }
        bool IsInventoryButtonPressed { get; }
    }
}