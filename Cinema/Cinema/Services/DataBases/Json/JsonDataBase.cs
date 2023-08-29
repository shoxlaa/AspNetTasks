using CinemaApp.Models;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Collections.Generic;

namespace CinemaApp.Services.DataBases.Json
{
    public class JsonDataBase : IDataBase
    {
        private readonly JsonDbContext<IModel> _cinemaDb;
        private readonly JsonDbContext<IModel> _sessionDb;

        public JsonDataBase()
        {
            _cinemaDb = new JsonDbContext<IModel>("films.json");
            _sessionDb = new JsonDbContext<IModel>("session.json");

            _cinemaDb.collection = _cinemaDb.dStore.GetCollection<IModel>();
            _sessionDb.collection = _sessionDb.dStore.GetCollection<IModel>();

        }
        public async Task<bool> Add(IModel model)
        {
            if (model is Cinema)
            {
                await _cinemaDb.collection.InsertOneAsync(model);
            }

            if (model is Session)
            {
                await _sessionDb.collection.InsertOneAsync(model);
                return true;
            }

            return false;
        }

        public List<IModel> Get()
        {
            List<IModel> list = _cinemaDb.collection.AsQueryable().ToList();

            return  list ;
        }

        public async Task<bool> Remove(IModel model)
        {
            if (model is Cinema)
            {
                await _cinemaDb.collection.DeleteOneAsync(model);
            }

            if (model is Session)
            {
                await _sessionDb.collection.DeleteOneAsync(model);
                return true;
            }

            return false;
        }

        public async Task<bool> Update(IModel model)
        {
            if (model is Cinema)
            {
                await _cinemaDb.collection.UpdateOneAsync(model.Id, model);
                return true;
            }

            if (model is Session)
            {
                await _sessionDb.collection.UpdateOneAsync(model.Id, model);
                return true;
            }

            return false;
        }



    }

}
