using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Infrastructure.Persistence.Settings
{
    public class InvoiceDbSettings : IInvoiceDbSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string InvoiceCollectionName { get; set; }
        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString

        {
            get
            {
                if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password))
                    return $@"mongodb://{Host}:{Port}";
                return $@"mongodb://{User}:{Password}@{Host}:{Port}";
            }
        }

    }

    public interface IInvoiceDbSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string InvoiceCollectionName { get; set; }
        public string ConnectionString { get; }
        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
