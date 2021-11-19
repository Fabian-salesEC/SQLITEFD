using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLITEFD
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
