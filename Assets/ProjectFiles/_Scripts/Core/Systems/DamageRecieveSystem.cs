using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;

namespace PinguinoKatano.Attacking
{
    public class DamageRecieveSystem : JobComponentSystem
    {
        private BuildPhysicsWorld buildPhysicsWorld;
        private StepPhysicsWorld stepPhysicsWorld;

        protected override void OnCreate()
        {
            buildPhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();
            stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
        }
        private struct DamageJob : ITriggerEventsJob
        {
            public ComponentDataFromEntity<HealthData> healthGroup;
            public ComponentDataFromEntity<AttackDamageData> attackDamageGroup;
            public float deltaTime;
            
            public void Execute(TriggerEvent triggerEvent)
            {
                if (attackDamageGroup.HasComponent(triggerEvent.Entities.EntityA))
                {
                    if (healthGroup.HasComponent(triggerEvent.Entities.EntityB))
                    {
                        HealthData health = healthGroup[triggerEvent.Entities.EntityB];
                        AttackDamageData attack = attackDamageGroup[triggerEvent.Entities.EntityA];
                        health.Value -= attack.Value * deltaTime;
                        healthGroup[triggerEvent.Entities.EntityB] = health;
                    }
                }

                if (attackDamageGroup.HasComponent(triggerEvent.Entities.EntityB))
                {
                    if (healthGroup.HasComponent(triggerEvent.Entities.EntityA))
                    {
                        HealthData health = healthGroup[triggerEvent.Entities.EntityA];
                        AttackDamageData attack = attackDamageGroup[triggerEvent.Entities.EntityB];
                        health.Value -= attack.Value * deltaTime;
                        healthGroup[triggerEvent.Entities.EntityA] = health;
                    }
                }
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var damageJob = new DamageJob
            {
                healthGroup = GetComponentDataFromEntity<HealthData>(),
                attackDamageGroup = GetComponentDataFromEntity<AttackDamageData>(),
                deltaTime = Time.DeltaTime
            };
            return damageJob.Schedule(stepPhysicsWorld.Simulation, ref buildPhysicsWorld.PhysicsWorld, inputDeps);
        }
    }
}
