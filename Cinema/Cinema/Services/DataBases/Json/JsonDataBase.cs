using CinemaApp.Models;
using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Collections.Generic;

namespace CinemaApp.Services.DataBases.Json
{
    public class JsonDataBase :IDataBase
    {
        private readonly JsonDbContext jsonDb;

        private IDocumentCollection<Cinema> _cinemas;
        private IDocumentCollection<Session> _sessions;
        public JsonDataBase()
        {
            jsonDb = new JsonDbContext();
            _cinemas=  jsonDb.dStore.GetCollection<Cinema>();
            _sessions = jsonDb.dStore.GetCollection<Session>();
        }
        public async Task<bool> Add(IModel model)
        {
            if (model == null)
            {
                return false;
            }

            if (model is Cinema)
            {
                await _cinemas.InsertOneAsync(model as Cinema);
            }

            if (model is Session)
            {
                await _sessions.InsertOneAsync(model as Session);
                return true;
            }

            return false;
        }

        public List<IModel> Get()
        {
            var list = new List<IModel>(_cinemas.AsQueryable());
            list.AddRange(_sessions.AsQueryable());
            return list;
        }

        public List<Cinema> GetCinemas()
        {
            return new List<Cinema>((_cinemas.AsQueryable()));
        }
        public List<Session> GetSessions()
        {
            return new List<Session>((_sessions.AsQueryable()));
        }

        public async Task<bool> Remove(IModel model)
        {
            if (model == null)
            {
                return false;
            }

            if (model is Cinema)
            {
                await _cinemas.DeleteOneAsync(model.Id);
            }

            if (model is Session)
            {
                await _sessions.DeleteOneAsync(model.Id);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(IModel model)
        {
            if (model is Cinema)
            {
                await _cinemas.UpdateOneAsync(model.Id, model);
                return true;
            }

            if (model is Session)
            {
                await _sessions.UpdateOneAsync(model.Id, model);
                return true;
            }

            return false;
        }



    }


}
