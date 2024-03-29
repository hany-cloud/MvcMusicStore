﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    //Bind – Lists fields to exclude or include when binding parameter or form values to model properties
    //[Bind(Exclude = "AlbumId")]
    /* By excluding AlbumId, you will not be able to edit the Album because in post operation 
     * the albumId will be sent as 0, 
     * so the "System.Data.Entity.Infrastructure.DbUpdateConcurrencyException" exception will be thrown.
    */
    public class Album
    {
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }

        [DisplayName("Genre")]
        public int GenreId { get; set; }

        [DisplayName("Artist")]
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }


        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}