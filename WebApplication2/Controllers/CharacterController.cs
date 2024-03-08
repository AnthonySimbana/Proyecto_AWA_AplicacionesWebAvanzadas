using MicroServiceCharacter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using MicroServiceCharacter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MicroServiceCharacter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CharacterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetAllCharacters()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BDD_AWA")))
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM TBL_CHARACTER";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        var characters = new List<Character>();

                        while (await reader.ReadAsync())
                        {
                            var character = new Character
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Race = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Class = reader.IsDBNull(3) ? null : reader.GetString(3),
                                ActiveSpecName = reader.IsDBNull(4) ? null : reader.GetString(4),
                                ActiveSpecRole = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Gender = reader.IsDBNull(6) ? null : reader.GetString(6),
                                Faction = reader.IsDBNull(7) ? null : reader.GetString(7),
                                AchievementPoints = reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                                HonorableKills = reader.IsDBNull(9) ? 0 : reader.GetInt32(9),
                                ThumbnailUrl = reader.IsDBNull(10) ? null : reader.GetString(10),
                                Region = reader.GetString(11),
                                Realm = reader.GetString(12),
                                LastCrawledAt = reader.IsDBNull(13) ? (DateTime?)null : reader.GetDateTime(13),
                                ProfileUrl = reader.IsDBNull(14) ? null : reader.GetString(14),
                                ProfileBanner = reader.IsDBNull(15) ? null : reader.GetString(15)
                            };

                            characters.Add(character);
                        }

                        return Ok(characters);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }



        [HttpPost]
        public async Task<ActionResult<int>> AddCharacter(Character character)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BDD_AWA")))
                {
                    await connection.OpenAsync();

                    string query = @"
                INSERT INTO TBL_CHARACTER (name, race, class, active_spec_name, active_spec_role, gender, faction, achievement_points, honorable_kills, thumbnail_url, region, realm, last_crawled_at, profile_url, profile_banner)
                VALUES (@Name, @Race, @Class, @ActiveSpecName, @ActiveSpecRole, @Gender, @Faction, @AchievementPoints, @HonorableKills, @ThumbnailUrl, @Region, @Realm, @LastCrawledAt, @ProfileUrl, @ProfileBanner);
                SELECT SCOPE_IDENTITY();
            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", character.Name);
                        command.Parameters.AddWithValue("@Race", character.Race);
                        command.Parameters.AddWithValue("@Class", character.Class);
                        command.Parameters.AddWithValue("@ActiveSpecName", character.ActiveSpecName);
                        command.Parameters.AddWithValue("@ActiveSpecRole", character.ActiveSpecRole);
                        command.Parameters.AddWithValue("@Gender", character.Gender);
                        command.Parameters.AddWithValue("@Faction", character.Faction);
                        command.Parameters.AddWithValue("@AchievementPoints", character.AchievementPoints);
                        command.Parameters.AddWithValue("@HonorableKills", character.HonorableKills);
                        command.Parameters.AddWithValue("@ThumbnailUrl", character.ThumbnailUrl);
                        command.Parameters.AddWithValue("@Region", character.Region);
                        command.Parameters.AddWithValue("@Realm", character.Realm);
                        command.Parameters.AddWithValue("@LastCrawledAt", character.LastCrawledAt ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ProfileUrl", character.ProfileUrl);
                        command.Parameters.AddWithValue("@ProfileBanner", character.ProfileBanner);

                        int newCharacterId = Convert.ToInt32(await command.ExecuteScalarAsync());

                        return Ok(newCharacterId);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateCharacter(int id, Character updatedCharacter)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BDD_AWA")))
                {
                    await connection.OpenAsync();

                    string query = @"
                UPDATE TBL_CHARACTER
                SET name = @Name, race = @Race, class = @Class, active_spec_name = @ActiveSpecName,
                    active_spec_role = @ActiveSpecRole, gender = @Gender, faction = @Faction,
                    achievement_points = @AchievementPoints, honorable_kills = @HonorableKills,
                    thumbnail_url = @ThumbnailUrl, region = @Region, realm = @Realm,
                    last_crawled_at = @LastCrawledAt, profile_url = @ProfileUrl, profile_banner = @ProfileBanner
                WHERE id_character = @Id;
            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Name", updatedCharacter.Name);
                        command.Parameters.AddWithValue("@Race", updatedCharacter.Race);
                        command.Parameters.AddWithValue("@Class", updatedCharacter.Class);
                        command.Parameters.AddWithValue("@ActiveSpecName", updatedCharacter.ActiveSpecName);
                        command.Parameters.AddWithValue("@ActiveSpecRole", updatedCharacter.ActiveSpecRole);
                        command.Parameters.AddWithValue("@Gender", updatedCharacter.Gender);
                        command.Parameters.AddWithValue("@Faction", updatedCharacter.Faction);
                        command.Parameters.AddWithValue("@AchievementPoints", updatedCharacter.AchievementPoints);
                        command.Parameters.AddWithValue("@HonorableKills", updatedCharacter.HonorableKills);
                        command.Parameters.AddWithValue("@ThumbnailUrl", updatedCharacter.ThumbnailUrl);
                        command.Parameters.AddWithValue("@Region", updatedCharacter.Region);
                        command.Parameters.AddWithValue("@Realm", updatedCharacter.Realm);
                        command.Parameters.AddWithValue("@LastCrawledAt", updatedCharacter.LastCrawledAt ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ProfileUrl", updatedCharacter.ProfileUrl);
                        command.Parameters.AddWithValue("@ProfileBanner", updatedCharacter.ProfileBanner);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok(rowsAffected);
                        }
                        else
                        {
                            return NotFound($"Personaje con ID {id} no encontrado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteCharacter(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BDD_AWA")))
                {
                    await connection.OpenAsync();

                    string query = "DELETE FROM TBL_CHARACTER WHERE id_character = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok(rowsAffected);
                        }
                        else
                        {
                            return NotFound($"Personaje con ID {id} no encontrado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("BDD_AWA"));
        }
        // Puedes implementar métodos adicionales para la creación, actualización, eliminación, etc.
    }
}
