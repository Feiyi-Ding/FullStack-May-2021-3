﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class MovieCreateResponseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [StringLength(2084)]
        public string Overview { get; set; }

        [StringLength(2084)]
        public string Tagline { get; set; }

        [Range(0, 5000000000)]
        [RegularExpression("^(\\d{1,18})(.\\d{1})?$")]
        public decimal? Revenue { get; set; }

        [Range(0, 500000000)]
        public decimal? Budget { get; set; }

        [Url]
        public string ImdbUrl { get; set; }

        [Url]
        public string TmdbUrl { get; set; }

        [Required]
        [Url]
        public string PosterUrl { get; set; }

        [Required]
        [Url]
        public string BackdropUrl { get; set; }

        public string OriginalLanguage { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public int? RunTime { get; set; }

        [Range(.99, 49)]
        public decimal? Price { get; set; }

        public List<Genre> Genres { get; set; }
    }
}
