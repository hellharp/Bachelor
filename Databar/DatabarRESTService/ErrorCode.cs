using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabarRESTService
{
    public enum ErrorCode
    {
        DatabarItemNameAndNotesRequired,
        DatabarItemIDInUse,
        RecordNotFound,
        CouldNotCreateItem,
        CouldNotUpdateItem,
        CouldNotDeleteItem
    }
}