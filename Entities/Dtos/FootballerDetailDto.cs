using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class FootballerDetailDto : IDto
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public int LeagueId { get; set; }
        public int CountryId { get; set; }
        public int FootId { get; set; }
        public int CityId { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int FootballerValue { get; set; }
        public int PlayerNumber { get; set; }
        public string FootName { get; set; }
        public string? FootballerCountryImagePath { get; set; }
        public string? FootballerImagePath { get; set; }
        public string? FootballerCountryName { get; set; }
        public string CityName { get; set; }
        public bool? NationalTeamPlayerActive { get; set; }
        public int? NationalTeamLevel { get; set; }
        public string? FootballerClubImagePath { get; set; }
        public string ClubName { get; set; }
        public string? NameInHomeCountry { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? PlayerAgent { get; set; }
        public DateTime? DateOfLastContract { get; set; }
        public DateTime? Joined { get; set; }
        public DateTime? ContractExpires { get; set; }
    }
}
