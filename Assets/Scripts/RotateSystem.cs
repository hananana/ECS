using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Collections;
using UnityEngine.Jobs;

public class RotateSystem : JobComponentSystem
{ 
    [Unity.Burst.BurstCompileAttribute]
    struct RotateJob : IJobParallelFor
    {
        public ComponentDataArray<Rotation> rotations;
        public ComponentDataArray<RotationSpeed> rotationSpeeds;

        public void Execute(int index)
        {
            var rot = new Rotation();
            rot.Value = this.rotations[index].Value * Quaternion.Euler(1f * this.rotationSpeeds[index].speed, 0f, 0f);
            this.rotations[index] = rot;
        }
    }

    ComponentGroup componentGroup;

    protected override void OnCreateManager()
    {
        this.componentGroup = this.GetComponentGroup(typeof(Rotation), typeof(RotationSpeed));
    }

    protected override JobHandle OnUpdate(JobHandle jobHandle)
    {
        var job = new RotateJob();
        job.rotations = componentGroup.GetComponentDataArray<Rotation>();
        job.rotationSpeeds = componentGroup.GetComponentDataArray<RotationSpeed>();
        return job.Schedule(this.componentGroup.CalculateLength(), 32, jobHandle);
    }
}
