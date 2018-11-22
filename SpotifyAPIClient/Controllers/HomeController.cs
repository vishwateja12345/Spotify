using Newtonsoft.Json;
using RestSharp;
using SpotifyAPIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SpotifyAPIClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetAlbums()
        {
            try
            {
                var baseUrl = "https://api.spotify.com/v1/albums/0sNOF9WDwhWunNAHPD3Baj";
                var resultSpotify = GetSpotifyData(baseUrl);

                var albumModel = JsonConvert.DeserializeObject<RootobjectAlbum>(resultSpotify.Content);

                TempData["data"] = resultSpotify.StatusCode;

                return View(albumModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("");
            }
        }
        public ActionResult GetArtists()
        {
            try
            {
                var baseUrl = "https://api.spotify.com/v1/artists/0OdUWJ0sBjDrqHygGUXeCF";
                var resultSpotify = GetSpotifyData(baseUrl);

                var artistModel = JsonConvert.DeserializeObject<RootobjectArtist>(resultSpotify.Content);

                TempData["data"] = resultSpotify.StatusCode;

                return View(artistModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("");
            }
        }
        public IRestResponse GetSpotifyData(string baseUrl)
        {
            try
            {
                var spotifyPostclient = new RestClient("https://accounts.spotify.com/api/token");
                var requestSpotify = new RestRequest(Method.POST);

                spotifyPostclient.Proxy = WebRequest.DefaultWebProxy;
                spotifyPostclient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                requestSpotify.AddHeader("authorization", "Basic ZGM2YTA2MWE0M2ZmNDMzMTk1YmZkZWJjZjc0ODJiOWY6NTc3MTUwZjdjMzViNDMwNmE1YTU3ZGNjNTc3MzEzNDQ=");
                requestSpotify.AddHeader("content-type", "application/x-www-form-urlencoded");
                requestSpotify.AddParameter("undefined", "grant_type=client_credentials", ParameterType.RequestBody);
                var spotifyResponse = spotifyPostclient.Execute(requestSpotify);


                var jsonToken = JsonConvert.DeserializeObject<Album>(spotifyResponse.Content);

                var token = jsonToken.access_token;


                var spotifyGetclient = new RestClient(baseUrl);


                var spotifyrequest = new RestRequest(Method.GET);
                spotifyrequest.AddHeader("authorization", "Bearer " + token);
                var resultSpotify = spotifyGetclient.Execute(spotifyrequest);

                return resultSpotify;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return null;
            }

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}