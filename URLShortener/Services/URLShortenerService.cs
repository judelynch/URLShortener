﻿using URLShortener.Models;
using URLShortener.Repositories;

namespace URLShortener.Services
{
    public class URLShortenerService : IURLShortenerService
    {
        private readonly IURLShortenerRepo _uRLShortenerRepo;
        private readonly ILogger<URLShortenerService> _logger;

        public URLShortenerService(IURLShortenerRepo uRLShortenerRepo,
                                   ILogger<URLShortenerService> logger)
        {
            _uRLShortenerRepo = uRLShortenerRepo;
            _logger = logger;
        }

        public string GetUrl(string UrlId)
        {

            StringConvert StringConvertor = new StringConvert();

            try
            {
                //Get Url From Database
                URLStringIdViewModel CodedUrl = _uRLShortenerRepo.GetUrl(UrlId);
                //Check if its null
                if (CodedUrl == null)
                {
                    //throw not found
                    throw new Exception("404");
                }
                //Decode and Return Long Url
                return StringConvertor.DecodeString(CodedUrl.Url);
            }
            catch (Exception ex)
            {
                //Only log if not a 404.
                if (ex.Message != "404")
                {
                    //Log Error
                    _logger.LogError(ex.Message);
                }
                throw;
            }
        }

        public string PostUrl(string url)
        {
            ValidateURL valUrl = new ValidateURL();

            if (valUrl.IsValid(url))
            {

                StringConvert StringConvertor = new StringConvert();
                string EncodedUrl = "";
                string UrlId = "";

                try
                {
                    // encode url 
                    EncodedUrl = StringConvertor.EncodeString(url);
                }
                catch (Exception ex)
                {
                    //Log Error
                    _logger.LogError(ex.Message);
                    throw;
                }

                try
                {
                    //Generat Id 
                    UrlId = StringGenerator.Create(EncodedUrl);
                }
                catch (Exception ex)
                {
                    //Log Error
                    _logger.LogError(ex.Message);
                    throw;
                }

                try
                {
                    // Check if it already exists. 
                    URLStringIdViewModel CurrentUrl = _uRLShortenerRepo.GetUrl(UrlId);
                    if (CurrentUrl == null)
                    {
                        //Add if not exists 
                        _uRLShortenerRepo.SaveUrl(new URLStringIdViewModel(UrlId, EncodedUrl));
                    }

                    return "https://localhost:7056/" + UrlId.ToString();
                }
                catch (Exception ex)
                {
                    //Log Error
                    _logger.LogError(ex.Message);
                    throw;
                }
                // return "small" Url

            }
            else
            {
                return "Please enter a valid URL!";
            }
        }
    }
}
