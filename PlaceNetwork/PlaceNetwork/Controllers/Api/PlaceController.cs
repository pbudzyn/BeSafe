using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using PlaceNetwork.BusinessLogic.Services.Interfaces;
using PlaceNetwork.Data.Models;
using PlaceNetwork.Models;

namespace PlaceNetwork.Controllers.Api
{
    [IsAuthorize]
    public class PlaceController : ApiController
    {
        private readonly IPlaceService _placesService;
        private readonly IUserService _userService;
        private readonly ITrustedPeopleService _trustedPeopleService;

        public PlaceController(IPlaceService placesService, IUserService userService, ITrustedPeopleService trustedPeopleService)
        {
            _placesService = placesService;
            _userService = userService;
            _trustedPeopleService = trustedPeopleService;
        }

        public IHttpActionResult Post(PlaceModel placeModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            var place = new Place
            {
                Latitude = placeModel.Latitude,
                Longitude = placeModel.Longitude,
                Title = placeModel.Title,
                Description = placeModel.Description,
                UserAddedId = _userService.GetByUsername(HttpContext.Current.User.Identity.Name).Id,
                LikeNumber = 0,
                DislikeNumber = 0
            };
            try
            {
                _placesService.Add(place);
                return Ok();
            }
            catch { return BadRequest(); }
        }

        public List<Points> Get()
        {
            var usersPoints = new List<Points>();
            var id = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            var trustedPeoples = _trustedPeopleService.GetByTrustedUserId(id);
            foreach (var trustedPeople in trustedPeoples)
            {
                var userId = trustedPeople.UserId;
                var point = new Points();
                point.UserId = userId;
                point.UserPoints = _placesService.GetByUserId(userId);
                usersPoints.Add(point);
            }

            return usersPoints;
            //return _placesService.GetAll();
        }

        public List<Points> Get(int id)
        {
            var usersPoints = new List<Points>();
            var trustedPeoples = _trustedPeopleService.GetByUserId(id);
            foreach (var trustedPeople in trustedPeoples)
            {
                var userId = trustedPeople.TrustedUserId;
                var point = new Points();
                point.UserId = userId;
                point.UserPoints = _placesService.GetByUserId(userId);
                usersPoints.Add(point);
            }
            
            return usersPoints;
        }

        [Route("api/Place/MyPlaces")]
        [HttpGet]
        public List<Place> GetMyPlaces()
        {
            return _placesService.GetByUserId(_userService.GetByUsername(HttpContext.Current.User.Identity.Name).Id);
        }
    }
}
