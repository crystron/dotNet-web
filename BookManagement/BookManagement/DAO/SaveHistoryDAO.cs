using BookManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookManagement.DAO
{
    public class SaveHistoryDAO
    {
        BookDb db = null;
        public SaveHistoryDAO()
        {
            db = new BookDb();
        }
        public List<SaveHistory> dsLichSu()
        {
            return db.SaveHistories.ToList();
        }
    }
}