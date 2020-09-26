using System.ComponentModel.DataAnnotations;

namespace EAuction.Models
{
    public enum Category
    {

            [Display(Name="Antique Clocks")]
            Clocks,
            [Display(Name ="Antique Furniture")]
            Furniture,
            Antiquities,
            [Display(Name = "Arhitectural Antiques")]
            Arhitectural,
            [Display(Name = "Asian/Oriental Antiques")]
            Oriental,
            [Display(Name = "Carpets &amp; Rugs")]
            Carpets,
            [Display(Name = "Decorative Arts")]
            Decorative,
            [Display(Name = "Ethnographic Antiques")]
            Ethnographic,
            Manuscripts,
            Metalware,
            [Display(Name = "Other Antiques")]
            Other,
            Science,
            Silver,
            Woodenware,

            Drawings,
            Photographs,
            Posters,
            Print,
            Scultpures,
            [Display(Name = "Other Art")]
            OtherArt,
            Paintings,
            Accessories,
            [Display(Name = "Audio Books")]
            Audio,
            Calendars,
            [Display(Name = "Comic Books")]
            Comics,
            Fiction,
            Magazines,
            [Display(Name = "Non-fiction")]
            NonFiction,
            [Display(Name = "Other Books")]
            OtherBooks,
            Camcorders,
            [Display(Name = "Digital Cameras")]
            Digital,
            [Display(Name = "Film Photography")]
            Film,
            [Display(Name = "Other Photography")]
            OtherCameras,
            [Display(Name = "Aircraft &amp; Aviation")]
            Aircraft,
            [Display(Name = "Boats &amp; Watercraft")]
            Boats,
            Cars,
            [Display(Name = "Military Vehicles")]
            Military,
            Motorcycles,
            [Display(Name = "Other Vehicles")]
            OtherVehicles,
            Baby,
            Kids,
            Men,
            Women,
            BabyShoes,
            KidsShoes,
            MenShoes,
            WomenShoes,
            BabyAccessories,
             KidsAccessories,
            MenAccessories,
            WomenAccessories,
            [Display(Name = "DVDs &amp; Blu-rays")]
            Dvd,
            LaserDiscs,
            OtherDvd,
            Storage,
            VHS,
            [Display(Name = "Bath &amp; Body")]
            Bath,
            [Display(Name = "E-Cigarettes &amp; Vapes")]
            Cigarettes,
            [Display(Name = "Facial Skin Care")]
            Facial,
            Fragrances,
            [Display(Name = "Make-Up")]
            Makeup,
            Massage,
            [Display(Name = "Oral Care")]
            Oral,
            [Display(Name = "Other Health &amp; Beauty")]
            OtherHealth,
            [Display(Name = "Salon &amp; Spa")]
            Salon,
            [Display(Name = "Vision Care")]
            Vision,
            CDs,
            Cassettes,
            [Display(Name = "Other Formats")]
            OtherMusic,
            Records,
            StorageMusic,
            [Display(Name = "American Football")]
            American,
            Archery,
            Badminton,
            Baseball,
            Basketball,
            Bowling,
            Boxing,
            Cricket,
            Cycling,
            Darts,
            Fishing,
            Fitness,
            Football,
            Golf,
            Gymnastics,
            Hockey,
            Hunting,
            [Display(Name = "Martial Arts")]
            Martial,
            Sailing,
            Skateboarding,
            Surfing,
            Swimming,
            Tennis,
            [Display(Name = "Action Figures")]
            Action,
            Beanies,
            [Display(Name = "Educational Toys")]
            Educational,
            [Display(Name = "Electronic Pets")]
            Electronic,
            Games,
            [Display(Name = "Jigsaw &amp; Puzzles")]
            Jigsawy,
            [Display(Name = "Other Toys &amp; Games")]
            OtherSports,
            [Display(Name = "Toy Soldiers")]
            Soldiers,
            [Display(Name = "Video Game Acessories")]
            AccessoriesVideoGames,
            [Display(Name = "Video Game Consoles")]
            Consoles,
            [Display(Name = "Video Game Merchandise")]
            Merchandise,
            [Display(Name = "Video Games")]
            Video
        

    }
}
