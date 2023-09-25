using GameStore.Client.Models;
using System.Net.Http.Json;


namespace GameStore.Client;

public class GameClient
{

    private readonly HttpClient httpClient;

    public GameClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public async Task<Game[]?> GetGamesAsync(string? filter) => await httpClient.GetFromJsonAsync<Game[]>($"games?filter={filter}");

    public async Task AddGameAsync(Game game)
    {
        await httpClient.PostAsJsonAsync("games", game);
    }

    public async Task<Game> GetGameAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<Game>($"games/{id}") ?? throw new Exception("Could not find game");
    }

    public async Task UpdateGameAsync(Game updatedGame)
    {
        await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);
    }

    public async Task DeleteGameAsync(int id)
    {
        await httpClient.DeleteAsync($"games/{id}");
    }
}