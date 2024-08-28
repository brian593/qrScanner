using System;
using qrScanner.Models;
using SQLite;

namespace qrScanner.Services
{
    public class QRCodeDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public QRCodeDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<QRCode>().Wait();
        }

        public Task<List<QRCode>> GetQRCodesAsync()
        {
            return _database.Table<QRCode>().ToListAsync();
        }

        public Task<int> SaveQRCodeAsync(QRCode code)
        {
            return _database.InsertAsync(code);
        }

        public Task<int> DeleteQRCodeAsync(QRCode code)
        {
            return _database.DeleteAsync(code);
        }
    }
}

