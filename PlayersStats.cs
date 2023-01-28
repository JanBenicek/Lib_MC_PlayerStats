using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Lib_MCPlayerStats
{
    public class PlayersStats
    {



        /// <summary>
        /// Load player Stats from file
        /// </summary>
        /// <param name="file">File path</param>
        /// <returns></returns>
        public static Task<Player_Stats> LoadPlayerAsync(string file)
        {
            Player_Stats player = new();

            if (!File.Exists(file))
            {
                player.Username = "File not Exist";
                return Task.FromResult(player);     //If Deserialized object is null return empty stats object with ErrorMessage in Username
            }

            Stats_Internal? loaded = JsonConvert.DeserializeObject<Stats_Internal>(File.ReadAllText(file)); //Desearialize Stats file to internal object

            if (loaded == null)
            {
                player.Username = "Deserialized object is null";
                return Task.FromResult(player);     //If Deserialized object is null return empty stats object with ErrorMessage in Username
            }

            player.Username = GetNameByUUID(file.Split(@"/").Last().Replace("-", "").Replace(".json", ""));

            //Move data from loaded stats to object with username
            player.picked_up = loaded.stats.picked_up;
            player.mined = loaded.stats.mined;
            player.crafted = loaded.stats.crafted;
            player.broken = loaded.stats.broken;
            player.killed = loaded.stats.killed;
            player.dropped = loaded.stats.dropped;
            player.custom = loaded.stats.custom;
            player.used = loaded.stats.used;
            player.killed_by = loaded.stats.killed_by;

            return Task.FromResult(player); //Return object with player Stats
        }

        /// <summary>
        /// Load all player stats from files in folder
        /// </summary>
        /// <param name="folder">Folder path</param>
        /// <returns></returns>
        public static async Task<List<Player_Stats>> LoadPlayersAsync(string folder)
        {
            List<Player_Stats> stats = new();

            foreach (string file in Directory.GetFiles(folder))
            {
                if (file.EndsWith(".json"))
                {
                    stats.Add(await LoadPlayerAsync(file));
                }
            }

            return stats;
        }


        /// <summary>
        /// Get Username from UUID by Mojang Api
        /// </summary>
        /// <param name="UUID"></param>
        /// <returns></returns>
        private static string GetNameByUUID(string UUID)
        {
            HttpClient client = new();
            MojangApi? data = null;

            HttpResponseMessage response = client.GetAsync($"https://sessionserver.mojang.com/session/minecraft/profile/{UUID}").Result;
            
            if (response.IsSuccessStatusCode)
            {
                                                                    #pragma warning disable CS8604
                data = JsonConvert.DeserializeObject<MojangApi>(response.Content.ToString());
                                                                    #pragma warning restore CS8604
            }

            if (data == null)
                return UUID;

                #pragma warning disable CS8603
            return data.name;
                #pragma warning restore CS8603


        }



    }
}