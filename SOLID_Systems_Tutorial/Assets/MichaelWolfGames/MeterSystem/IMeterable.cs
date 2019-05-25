#define MWG_METERS
using System;

namespace MichaelWolfGames.MeterSystem
{
    public interface IMeterable
    {
        //float MinValue { get; }
        float CurrentValue { get; }
        float MaxValue { get; }
        float PercentValue { get; }
        Action<float> OnUpdateValue { get; set; }

    }
}