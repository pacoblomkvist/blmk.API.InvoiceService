using InvoiceService.Application.Common.Interfaces;
using InvoiceService.Infrastructure.Persistence.Settings;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Infrastructure.Persistence
{
    public class MongoDbContext:IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _commands;

        public MongoDbContext(IInvoiceDbSettings settings)
        {
            MongoClient = new MongoClient(settings.ConnectionString);

            Database = MongoClient.GetDatabase(settings.DatabaseName);

            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();
        }
        //public void AddCommand(Func<Task> func)
        //{
        //    _commands.Add(func);
        //}

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
