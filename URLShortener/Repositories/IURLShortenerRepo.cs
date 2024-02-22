﻿using URLShortener.Models;

namespace URLShortener.Repositories
{
    public interface IURLShortenerRepo
    {
        URLShortenerViewModel GetUrl(Guid smallUrlId);
        bool SaveSmallUrl(URLShortenerViewModel entity);
    }
}
