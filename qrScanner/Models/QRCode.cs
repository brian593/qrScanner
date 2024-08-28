using System;
using SQLite;

namespace qrScanner.Models
{
    public class QRCode
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateScanned { get; set; }
    }
}

