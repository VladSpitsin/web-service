using WebService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Repositories
{
    public class CharacterRepo : IRepository<Character>
    {
        readonly SqlConnection connection = new(@"server=localhost\SQLEXPRESS; Database=Characters; Trusted_Connection=True;");

        public async Task<string> Delete(int id)
        {
            StringBuilder sb = new($"Delete from Characters.dbo.Heroes where Heroes.ID = {id}");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = sb.ToString();
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return "OK";
        }

        public async Task<string> Post(Character character)
        {
            if (true)
            {
                StringBuilder sb = new($"insert into Characters.dbo.Heroes values ('{character.ID}', '{character.Name}', '{character.NickName}', '{character.Planet}')");
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sb.ToString();
                await command.ExecuteNonQueryAsync();
                connection.Close();
                return "OK";
            }
            else
            {
                return "Error!";
            }
        }

        public async Task<string> Put(Character character)
        {
            if (true)
            {
                StringBuilder sb = new($"Update Characters.dbo.Heroes set [Name] = '{character.Name}', [NickName] = '{character.NickName}', [Planet] = {character.Planet} where Heroes.ID = {character.ID}");
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sb.ToString();
                await command.ExecuteNonQueryAsync();
                connection.Close();
                return "OK";
            }
            else
            {
                return "Error!";
            }
        }

        public async Task<IEnumerable<Character>> Get()
        {
            StringBuilder sb = new("select * from Characters.dbo.Heroes");
            using SqlDataAdapter da = new(sb.ToString(), connection);

            connection.Open();
            DataTable dt = new();
            var command = connection.CreateCommand();
            command.CommandText = sb.ToString();
            var reader = await command.ExecuteReaderAsync();
            dt.Load(reader);
            connection.Close();

            List<Character> characters = new();
            if (dt.Rows.Count > 0)
            {
                characters = dt.Rows.Cast<DataRow>()
                    .Select(x => new Character()
                    {
                        ID = x.Field<Int32>("ID"),
                        Name = x.Field<string>("Name"),
                        NickName = x.Field<string>("NickName"),
                        Planet = x.Field<string>("Planet"),
                    }).ToList();
                return characters;
            }
            else
            {
                return characters;
            }
        }

        public async Task<Character> GetOne(int id)
        {
            StringBuilder sb = new($"select * from Characters.dbo.Heroes where Heroes.ID = {id}");
            SqlDataAdapter da = new(sb.ToString(), connection);
            DataTable dt = new();

            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = sb.ToString();
            var reader = await command.ExecuteReaderAsync();
            dt.Load(reader);
            connection.Close();

            List<Character> characters = new();

            if (dt.Rows.Count > 0)
            {
                characters = dt.Rows
                    .Cast<DataRow>()
                    .Select(x => new Character()
                    {
                        ID = x.Field<Int16>("ID"),
                        Name = x.Field<string>("Name"),
                        NickName = x.Field<string>("NickName"),
                        Planet = x.Field<string>("Planet"),
                    }).ToList();
                return characters[0];
            }
            else
            {
                return new Character();
            }
        }
    }
}
