namespace RpgSagaLib.Data
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using RpgSagaLib.Consts;

    public class PlayerDto
    {
        public PlayerDto(PlayerClasses playerClass, string name, int maxHP, int strenght)
        {
            this.PlayerClass = playerClass;
            this.Name = name;
            this.MaxHp = maxHP;
            this.Strenght = strenght;
        }

        [JsonProperty(PropertyName = "class")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PlayerClasses PlayerClass { get; set; }

        [JsonProperty(PropertyName = "maxHp")]
        public int MaxHp { get; set; }

        [JsonProperty(PropertyName = "strenght")]
        public int Strenght { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
