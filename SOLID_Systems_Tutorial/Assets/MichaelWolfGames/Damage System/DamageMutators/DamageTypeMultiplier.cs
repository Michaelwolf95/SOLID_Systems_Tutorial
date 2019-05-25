namespace MichaelWolfGames.DamageSystem
{
    /// <summary>
    /// Mutator that multiplies the damage recieved based on the damage type.
    /// 
    /// Michael Wolf
    /// February, 2018
    /// </summary>
    public class DamageTypeMultiplier : DamageEventMutatorBase
    {
        public DamageTypeValueStruct[] TypeValues;

        public override void MutateDamageEvent(object sender, ref Damage.DamageEventArgs args)
        {
            foreach (var tm in TypeValues)
            {
                if (args.DamageType == tm.DamageType)
                {
                    args.DamageValue *= tm.Value;
                }
            }
        }
    }

    /// <summary>
    /// Struct for defining types and associated values.
    /// </summary>
    [System.Serializable]
    public struct DamageTypeValueStruct
    {
        public Damage.DamageType DamageType;
        public float Value;
        public DamageTypeValueStruct(Damage.DamageType type, float value = 1f)
        {
            DamageType = type;
            Value = value;
        }
    }
}