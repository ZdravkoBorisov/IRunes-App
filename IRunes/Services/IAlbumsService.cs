namespace IRunes.Services
{
    using System;
    using System.Collections.Generic;

    using Models;
    using ViewModels.Album;


    public interface IAlbumsService
    {
        void Create(string name, string cover);

        IEnumerable<T> GetAll<T>(Func<Album, T> selectFunc);

        AlbumDetailsViewModel GetDetails(string id);
    }
}
