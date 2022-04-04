using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMVVM.db
{
    public interface ISqlite
    {
        string GetDatabasePath(string filename);
    }
}
