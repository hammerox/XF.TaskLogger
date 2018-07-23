using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskLogger.Interfaces
{
    public interface IDependencyServiceSQLite
    {
        SQLiteConnection GetConexao();
    }
}
