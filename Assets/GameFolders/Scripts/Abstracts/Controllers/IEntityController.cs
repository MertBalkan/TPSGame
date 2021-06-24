using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSGame.Abstracts.Controllers
{
    public interface IEntityController
    {
        Transform transform { get; }
    }
}