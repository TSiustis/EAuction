using System.ComponentModel.DataAnnotations;

namespace EbayCloneTBD.Models
{
    public class Category
    {
        public int Id { get; set; }
        public enum Antiques
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
            Woodenware
        }
        public enum Art
        {
            Drawings,
            Photographs,
            Posters,
            Print,
            Scultpures,
            [Display(Name = "Other Art")]
            Other,
            Paintings
        }
        public enum Books
        {
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
            Other
            }
        public enum Cameras
        {
            Camcorders,
            [Display(Name = "Digital Cameras")]
            Digital,
            [Display(Name = "Film Photography")]
            Film,
            [Display(Name = "Other Photography")]
            Other
        }
        public enum Vehicles
        {
            [Display(Name = "Aircraft &amp; Aviation")]
            Aircraft,
            [Display(Name = "Boats &amp; Watercraft")]
            Boats,
            Cars,
            [Display(Name = "Military Vehicles")]
            Military,
            Motorcycles,
            [Display(Name = "Other Vehicles")]
            Other
        }

        public enum Clothes
        {
            Baby,
            Kids,
            Men,
            Women
        }
        public enum Shoes
        {
            Baby,
            Kids,
            Men,
            Women
        }
        public enum Accessories
        {
            Baby,
            Kids,
            Men,
            Women
        }
        public enum Dvds
        {
            [Display(Name = "DVDs &amp; Blu-rays")]
            Dvd,
            LaserDiscs,
            Other,
            Storage,
            VHS
        }
        public enum Health
        {
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
            Other,
            [Display(Name = "Salon &amp; Spa")]
            Salon,
            [Display(Name = "Vision Care")]
            Vision
        }
        public enum Music
        {
            CDs,
            Cassettes,
            [Display(Name = "Other Formats")]
            Other,
            Records,
            Storage
        }
        public enum Sporting
        {
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
            Tennis
        }
        public enum Toys
        {
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
            Other,
            [Display(Name = "Toy Soldiers")]
            Soldiers

        }
        public enum VideoGames
        {
            [Display(Name = "Video Game Acessories")]
            Accessories,
            [Display(Name = "Video Game Consoles")]
            Consoles,
            [Display(Name = "Video Game Merchandise")]
            Merchandise,
            [Display(Name = "Video Games")]
            Video
        }

    }
}
