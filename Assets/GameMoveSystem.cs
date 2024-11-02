using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;

namespace lesson1Middle.Assets
{
    public class GameMoveSystem: ComponentSystem
    {
        private EntityQuery _query;
        private Vector3 p;


        protected override void OnCreate()
        {
            _query = GetEntityQuery(ComponentType.ReadOnly<Game>());
        }
        protected override void OnUpdate()
        {
            Entities.With(_query).ForEach((Entity entity, Transform transform, Game game) =>
            {
                var p = transform.position;
                p.y += game.moveSpeed/1000;
                transform.position = p;

            });
        }
    }
}