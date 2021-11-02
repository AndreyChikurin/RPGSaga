namespace RpgSaga.Deserialize
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using RpgSaga.Data;

    public class DeserializePlayer
    {
        public List<PlayerDto> DeserializePlayerFromJson(List<string> errorMessages)
        {
            string directory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;

            string path = @$"{directory}/JsonForPlayer/Players.json";

            string data = File.ReadAllText(path);

            string errorMessage;

            List<PlayerDto> models = new List<PlayerDto>();
            try
            {
                models = JsonConvert.DeserializeObject<List<PlayerDto>>(data);
                if (models.Count < 2 || models.Count % 2 != 0)
                {
                    throw new Exception();
                }

                for (int i = 0; i < models.Count; i++)
                {
                    if (models[i].MaxHp < 1
                        || models[i].Strenght < 1
                        || string.IsNullOrWhiteSpace(models[i].Name))
                    {
                        throw new Exception();
                    }
                }
            }
            catch (JsonReaderException)
            {
                errorMessage = "Error reading Json";
                errorMessages.Add(errorMessage);
                return null;
            }
            catch (JsonSerializationException)
            {
                errorMessage = "Json is incorrect, check data";
                errorMessages.Add(errorMessage);
                return null;
            }
            catch (Exception)
            {
                errorMessage = "Data is incorrect format. Model count must be great or equal 2. Health and strenght must be > 0";
                errorMessages.Add(errorMessage);
                return null;
            }

            return models;
        }

        public string DeserializePlayerFromJsonTesting(string jsonToString)
        {
            string data = jsonToString;

            string errorMessage;

            string errorMessagesList = string.Empty;

            List<PlayerDto> models = new List<PlayerDto>();
            try
            {
                models = JsonConvert.DeserializeObject<List<PlayerDto>>(data);
                if (models.Count < 2 || models.Count % 2 != 0)
                {
                    throw new Exception();
                }

                for (int i = 0; i < models.Count; i++)
                {
                    if (models[i].MaxHp < 1
                        || models[i].Strenght < 1
                        || string.IsNullOrWhiteSpace(models[i].Name))
                    {
                        throw new Exception();
                    }
                }
            }
            catch (JsonReaderException)
            {
                errorMessage = "Error reading Json";
                errorMessagesList += errorMessage;
                return errorMessagesList;
            }
            catch (JsonSerializationException)
            {
                errorMessage = "Json is incorrect, check data";
                errorMessagesList += errorMessage;
                return errorMessagesList;
            }
            catch (Exception)
            {
                errorMessage = "Data is incorrect format. Model count must be great or equal 2. Health and strenght must be > 0";
                errorMessagesList += errorMessage;
                return errorMessagesList;
            }

            return errorMessagesList;
        }
    }
}
