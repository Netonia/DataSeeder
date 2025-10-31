using Blazored.LocalStorage;
using DataSeeder.Models;

namespace DataSeeder.Services;

public class StorageService
{
    private readonly ILocalStorageService _localStorage;
    private const string ModelsKey = "dataseeder_models";
    private const string LastModelKey = "dataseeder_last_model";
    
    public StorageService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }
    
    public async Task<List<DataModel>> GetAllModelsAsync()
    {
        var models = await _localStorage.GetItemAsync<List<DataModel>>(ModelsKey);
        return models ?? new List<DataModel>();
    }
    
    public async Task<DataModel?> GetModelAsync(string id)
    {
        var models = await GetAllModelsAsync();
        return models.FirstOrDefault(m => m.Id == id);
    }
    
    public async Task SaveModelAsync(DataModel model)
    {
        model.UpdatedAt = DateTime.UtcNow;
        
        var models = await GetAllModelsAsync();
        var existingIndex = models.FindIndex(m => m.Id == model.Id);
        
        if (existingIndex >= 0)
        {
            models[existingIndex] = model;
        }
        else
        {
            models.Add(model);
        }
        
        await _localStorage.SetItemAsync(ModelsKey, models);
        await _localStorage.SetItemAsync(LastModelKey, model.Id);
    }
    
    public async Task DeleteModelAsync(string id)
    {
        var models = await GetAllModelsAsync();
        models.RemoveAll(m => m.Id == id);
        await _localStorage.SetItemAsync(ModelsKey, models);
        
        var lastId = await _localStorage.GetItemAsync<string>(LastModelKey);
        if (lastId == id)
        {
            await _localStorage.RemoveItemAsync(LastModelKey);
        }
    }
    
    public async Task<string?> GetLastModelIdAsync()
    {
        return await _localStorage.GetItemAsync<string>(LastModelKey);
    }
}
